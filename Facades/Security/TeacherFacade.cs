using System.Threading;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Contracts.Security;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories.Security;
using MensaGymnazium.IntranetGen3.Model;
using MensaGymnazium.IntranetGen3.Model.Security;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Facades.Security;

[Service]
[Authorize]
public class TeacherFacade : ITeacherFacade
{
	private readonly ITeacherRepository _teacherRepository;
	private readonly IUserRepository _userRepository;
	private readonly IUnitOfWork _unitOfWork;

	public TeacherFacade(
		ITeacherRepository teacherRepository,
		IUserRepository userRepository,
		IUnitOfWork unitOfWork)
	{
		_teacherRepository = teacherRepository;
		_userRepository = userRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<List<TeacherReferenceDto>> GetAllTeacherReferencesAsync(CancellationToken cancellationToken = default)
	{
		var data = await _teacherRepository.GetAllIncludingDeletedAsync(cancellationToken);
		return data.Select(t => new TeacherReferenceDto()
		{
			TeacherId = t.Id,
			UserId = t.User.Id,
			Name = t.User.Name,
			IsDeleted = (t.Deleted != null)
		}).ToList();
	}

	[Authorize(Roles = nameof(Role.Administrator))]
	public async Task<List<TeacherDto>> GetAllAsync(CancellationToken cancellationToken = default)
	{
		// GetAllAsync() is not able to handle loading User reference (backreference not supported by DataLoader)
		var data = await _teacherRepository.GetAllIncludingDeletedAsync(cancellationToken);
		return data
			.Where(t => t.Deleted is null)
			.Select(t => new TeacherDto()
			{
				Id = t.Id,
				UserId = t.User.Id,
				Name = t.User.Name,
				Email = t.User.Email,
				FunFact = t.FunFact
			})
			.ToList();
	}

	[Authorize(Roles = nameof(Role.Administrator))]
	public async Task DeleteTeacherAsync(Dto<int> teacherId, CancellationToken cancellationToken = default)
	{
		var teacher = await _teacherRepository.GetObjectAsync(teacherId.Value, cancellationToken);
		_unitOfWork.AddForDelete(teacher);

		await _unitOfWork.CommitAsync(cancellationToken);
	}

	[Authorize(Roles = nameof(Role.Administrator))]
	public async Task<Dto<int>> CreateTeacherAsync(TeacherDto teacherDto, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(teacherDto != null);
		Contract.Requires<ArgumentException>(teacherDto.Id == default);

		var teacher = new Teacher();
		MapTeacherFromDto(teacherDto, teacher);

		_unitOfWork.AddForInsert(teacher);
		await _unitOfWork.CommitAsync(cancellationToken);

		return Dto.FromValue(teacher.Id);
	}

	[Authorize(Roles = nameof(Role.Administrator))]
	public async Task UpdateTeacherAsync(TeacherDto teacherDto, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(teacherDto != null);
		Contract.Requires<ArgumentException>(teacherDto.Id != default);
		Contract.Requires<ArgumentException>(teacherDto.UserId != default);

		var user = await _userRepository.GetObjectAsync(teacherDto.UserId, cancellationToken);

		MapTeacherFromDto(teacherDto, user.Teacher);

		_unitOfWork.AddForUpdate(user);
		await _unitOfWork.CommitAsync(cancellationToken);
	}

	private void MapTeacherFromDto(TeacherDto teacherDto, Teacher teacher)
	{
		Contract.Assert<InvalidOperationException>((teacher.User is null && teacherDto.UserId == default) || (teacher.User is not null && teacherDto.UserId != default));

		teacher.FunFact = teacherDto.FunFact;
		teacher.User ??= new User();
		teacher.User.Email = teacherDto.Email;
		teacher.User.Name = teacherDto.Name;
	}
}
