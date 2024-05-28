using System.Security;
using System.Security.Claims;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.Queries;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories;
using MensaGymnazium.IntranetGen3.Facades.Infrastructure.Security.Authentication;
using MensaGymnazium.IntranetGen3.Model;
using MensaGymnazium.IntranetGen3.Primitives;
using MensaGymnazium.IntranetGen3.Services;
using MensaGymnazium.IntranetGen3.Services.Security;

namespace MensaGymnazium.IntranetGen3.Facades;

[Service]
[Authorize]
public class SubjectFacade : ISubjectFacade
{
	private readonly ISubjectListQuery _subjectListQuery;
	private readonly ISubjectRepository _subjectRepository;
	private readonly IStudentSubjectRegistrationRepository _studentSubjectRegistrationRepository;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IApplicationAuthenticationService _applicationAuthenticationService;
	private readonly IUserManager _userManager;
	private readonly ISubjectMapper _subjectMapper;

	public SubjectFacade(
		ISubjectListQuery subjectListQuery,
		ISubjectRepository subjectRepository,
		IStudentSubjectRegistrationRepository studentSubjectRegistrationRepository,
		IUnitOfWork unitOfWork,
		IApplicationAuthenticationService applicationAuthenticationService,
		IUserManager userManager,
		ISubjectMapper subjectMapper)
	{
		_subjectListQuery = subjectListQuery;
		_subjectRepository = subjectRepository;
		_studentSubjectRegistrationRepository = studentSubjectRegistrationRepository;
		_unitOfWork = unitOfWork;
		_applicationAuthenticationService = applicationAuthenticationService;
		_userManager = userManager;
		_subjectMapper = subjectMapper;
	}

	public async Task<DataFragmentResult<SubjectListItemDto>> GetSubjectListAsync(DataFragmentRequest<SubjectListQueryFilter> subjectListRequest, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(subjectListRequest is not null);

		_subjectListQuery.Filter = subjectListRequest.Filter;
		_subjectListQuery.Sorting = subjectListRequest.Sorting;

		return await _subjectListQuery.GetDataFragmentResultAsync(subjectListRequest.StartIndex, subjectListRequest.Count, cancellationToken);
	}

	public async Task<SubjectDto> GetSubjectDetailAsync(Dto<int> subjectIdDto, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentException>(subjectIdDto.Value != default);

		var subject = await _subjectRepository.GetObjectAsync(subjectIdDto.Value, cancellationToken);

		return await _subjectMapper.MapToSubjectDtoAsync(subject, cancellationToken);
	}

	[Authorize(Roles = nameof(Role.Administrator))]
	public async Task<Dto<int>> CreateSubjectAsync(SubjectDto subjectDto, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(subjectDto != null);
		Contract.Requires<ArgumentException>(subjectDto.Id == default);

		var subject = new Subject();
		await _subjectMapper.MapFromSubjectDtoAsync(subjectDto, subject, cancellationToken);

		_unitOfWork.AddForInsert(subject);
		await _unitOfWork.CommitAsync(cancellationToken);

		return Dto.FromValue(subject.Id);
	}

	[Authorize(Roles = $"{nameof(Role.Administrator)},{nameof(Role.Teacher)}")]
	public async Task UpdateSubjectAsync(SubjectDto subjectDto, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(subjectDto != null);
		Contract.Requires<ArgumentException>(subjectDto.Id != default);

		var subject = await _subjectRepository.GetObjectAsync(subjectDto.Id, cancellationToken);

		var currentUser = _applicationAuthenticationService.GetCurrentUser();
		var roles = await _userManager.GetRolesAsync(currentUser, ClaimsPrincipal.Current, cancellationToken);
		if (!roles.Contains(Role.Administrator))
		{
			if (!subject.Teachers.Any(t => t.Id == currentUser.TeacherId))
			{
				throw new SecurityException("Access Denied. Not your subject.");
			}
		}


		await _subjectMapper.MapFromSubjectDtoAsync(subjectDto, subject, cancellationToken);

		_unitOfWork.AddForUpdate(subject);
		await _unitOfWork.CommitAsync(cancellationToken);
	}

	[Authorize(Roles = nameof(Role.Administrator))]
	public async Task DeleteSubjectAsync(Dto<int> subjectIdDto, CancellationToken cancellationToken = default)
	{
		var subject = await _subjectRepository.GetObjectAsync(subjectIdDto.Value, cancellationToken);
		_unitOfWork.AddForDelete(subject);

		var registrations = await _studentSubjectRegistrationRepository.GetBySubjectAsync(subjectIdDto.Value, cancellationToken);
		_unitOfWork.AddRangeForDelete(registrations);

		await _unitOfWork.CommitAsync(cancellationToken);
	}

	public async Task<List<SubjectReferenceDto>> GetAllSubjectReferencesAsync(CancellationToken cancellationToken = default)
	{
		return (await _subjectRepository.GetAllIncludingDeletedAsync(cancellationToken))
			.Select(s => new SubjectReferenceDto()
			{
				Id = s.Id,
				Name = s.Name,
				IsDeleted = s.Deleted is not null,
				CategoryId = s.CategoryId,
				ScheduleDayOfWeek = s.ScheduleDayOfWeek,
				ScheduleSlotInDay = s.ScheduleSlotInDay
			})
			.ToList();
	}
}
