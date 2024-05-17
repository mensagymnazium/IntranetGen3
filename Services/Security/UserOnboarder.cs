using System.Security;
using System.Security.Claims;
using MensaGymnazium.IntranetGen3.Contracts.Security;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories.Security;
using MensaGymnazium.IntranetGen3.Model.Security;

namespace MensaGymnazium.IntranetGen3.Services.Security;

[Service]
public class UserOnboarder : IUserOnboarder
{
	private readonly IUserRepository _userRepository;
	private readonly IGradeRepository _gradeRepository;
	private readonly IUnitOfWork _unitOfWork;

	public UserOnboarder(
		IUserRepository userRepository,
		IGradeRepository gradeRepository,
		IUnitOfWork unitOfWork)
	{
		_userRepository = userRepository;
		_gradeRepository = gradeRepository;
		_unitOfWork = unitOfWork;
	}

	/// <inheritdoc />
	public async Task<User> TryOnboardUserAsync(Guid oid, ClaimsPrincipal principal, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentException>(principal != null);

		string email = principal.FindFirst(x => x.Type == ClaimConstants.EmailClaimType)?.Value;

		if (email == null)
		{
			throw new SecurityException("Email uživatele se nepodařilo vyhodnotit.");
		}

		var user = await _userRepository.GetByEmailAsync(email, cancellationToken);
		if (user != null)
		{
			_unitOfWork.AddForUpdate(user);
		}
		else
		{
			user = new User();
			_unitOfWork.AddForInsert(user);
		}

		user.Oid = oid;
		await UpdateUserCoreAsync(user, principal);

		_unitOfWork.AddForUpdate(user);

		await _unitOfWork.CommitAsync(cancellationToken);

		return user;
	}

	public async Task UpdateUserAsync(User user, ClaimsPrincipal principal)
	{
		await UpdateUserCoreAsync(user, principal);

		_unitOfWork.AddForUpdate(user);
		await _unitOfWork.CommitAsync();
	}

	private async Task UpdateUserCoreAsync(User user, ClaimsPrincipal principal)
	{
		Contract.Requires<ArgumentException>(user != null);

		user.Email = principal.FindFirst(x => x.Type == ClaimConstants.EmailClaimType)?.Value;
		user.Name = principal.FindFirst(x => x.Type == ClaimConstants.NameClaimType)?.Value;
		user.Lastname = user.Name?.Split(' ').Last();

		await UpdateTeacherAsync(user, principal);
		await UpdateStudentAsync(user, principal);
	}

	private async Task UpdateStudentAsync(User user, ClaimsPrincipal principal)
	{
		// If user is a teacher or global-admin, we cannot user grade-groups. It is not a student.
		if ((user.Teacher is not null)
			|| principal.HasClaim(ClaimConstants.GroupClaimType, AadGroupIds.Administrators))
		{
			if (user.StudentId != default)
			{
				_unitOfWork.AddForDelete(user.Student);
			}
			return;
		}

		var grades = await _gradeRepository.GetAllAsync();
		var grade = grades.FirstOrDefault(g => principal.HasClaim(ClaimConstants.GroupClaimType, g.AadGroupId));

		if (grade != null)
		{
			if (user.StudentId == default)
			{
				user.Student = new Student();
			}
			user.Student.Grade = grade;
			user.Student.Deleted = null; // případný undelete
		}
		else
		{
			if (user.StudentId != default)
			{
				_unitOfWork.AddForDelete(user.Student);
			}
		}
	}

	private Task UpdateTeacherAsync(User user, ClaimsPrincipal principal)
	{
		if (principal.HasClaim(ClaimConstants.GroupClaimType, AadGroupIds.Ucitele))
		{
			if (user.TeacherId == default)
			{
				user.Teacher = new Teacher();
			}
			// neděláme undelete, je to nestandardní situace, ať si to vyřeší support v DB
		}
		else
		{
			if (user.Teacher is not null)
			{
				_unitOfWork.AddForDelete(user.Teacher);
			}
		}

		return Task.CompletedTask;
	}
}
