using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Contracts.Security;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories.Security;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Facades.Security;

[Service]
[Authorize]
public class TeacherFacade : ITeacherFacade
{
	private readonly ITeacherRepository teacherRepository;
	private readonly IUnitOfWork unitOfWork;

	public TeacherFacade(ITeacherRepository teacherRepository, IUnitOfWork unitOfWork)
	{
		this.teacherRepository = teacherRepository;
		this.unitOfWork = unitOfWork;
	}

	public async Task<List<TeacherReferenceDto>> GetAllTeacherReferencesAsync(CancellationToken cancellationToken = default)
	{
		var data = await teacherRepository.GetAllIncludingDeletedAsync(cancellationToken);
		return data.Select(t => new TeacherReferenceDto()
		{
			TeacherId = t.Id,
			UserId = t.User.Id,
			Name = t.User.Name,
			IsDeleted = (t.Deleted != null)
		}).ToList();
	}

	public async Task<TeacherDto> GetTeacherDetailAsync(Dto<int> teacherIdDto, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(teacherIdDto != null);

		var teacher = await teacherRepository.GetByIdIncludingDeletedAsync(teacherIdDto.Value, cancellationToken);
		return new TeacherDto
		{
			TeacherId = teacher.Id,
			Name = teacher.User.Name,
			Email = teacher.User.Email,
			FunFact = teacher.FunFact,
			IsDeleted = teacher.Deleted != null
		};
	}

	[Authorize(Roles = nameof(Role.Administrator))]
	public async Task UpdateTeacherAsync(TeacherDto teacherDto, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(teacherDto != null);
		Contract.Requires<ArgumentException>(teacherDto.TeacherId != default);

		var teacher = await teacherRepository.GetByIdIncludingDeletedAsync(teacherDto.TeacherId, cancellationToken);

		teacher.User.Name = teacherDto.Name;
		teacher.User.Email = teacherDto.Email;
		teacher.FunFact = teacherDto.FunFact;

		if (teacherDto.IsDeleted && teacher.Deleted == null)
		{
			teacher.Deleted = DateTime.UtcNow;
		}
		else if (!teacherDto.IsDeleted && teacher.Deleted != null)
		{
			teacher.Deleted = null;
		}

		unitOfWork.AddForUpdate(teacher.User);
		unitOfWork.AddForUpdate(teacher);
		await unitOfWork.CommitAsync(cancellationToken);
	}
}
