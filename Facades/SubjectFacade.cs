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
	private readonly ISubjectListQuery subjectListQuery;
	private readonly ISubjectRepository subjectRepository;
	private readonly IStudentSubjectRegistrationRepository studentSubjectRegistrationRepository;
	private readonly IUnitOfWork unitOfWork;
	private readonly IApplicationAuthenticationService applicationAuthenticationService;
	private readonly IUserManager userManager;
	private readonly ISubjectMapper subjectMapper;

	public SubjectFacade(
		ISubjectListQuery subjectListQuery,
		ISubjectRepository subjectRepository,
		IStudentSubjectRegistrationRepository studentSubjectRegistrationRepository,
		IUnitOfWork unitOfWork,
		IApplicationAuthenticationService applicationAuthenticationService,
		IUserManager userManager,
		ISubjectMapper subjectMapper)
	{
		this.subjectListQuery = subjectListQuery;
		this.subjectRepository = subjectRepository;
		this.studentSubjectRegistrationRepository = studentSubjectRegistrationRepository;
		this.unitOfWork = unitOfWork;
		this.applicationAuthenticationService = applicationAuthenticationService;
		this.userManager = userManager;
		this.subjectMapper = subjectMapper;
	}

	public async Task<DataFragmentResult<SubjectListItemDto>> GetSubjectListAsync(DataFragmentRequest<SubjectListQueryFilter> subjectListRequest, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(subjectListRequest is not null);

		subjectListQuery.Filter = subjectListRequest.Filter;
		subjectListQuery.Sorting = subjectListRequest.Sorting;

		return await subjectListQuery.GetDataFragmentResultAsync(subjectListRequest.StartIndex, subjectListRequest.Count, cancellationToken);
	}

	public async Task<SubjectDto> GetSubjectDetailAsync(Dto<int> subjectIdDto, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentException>(subjectIdDto.Value != default);

		var subject = await subjectRepository.GetObjectAsync(subjectIdDto.Value, cancellationToken);

		return await subjectMapper.MapToSubjectDtoAsync(subject);
	}

	[Authorize(Roles = nameof(Role.Administrator))]
	public async Task<Dto<int>> CreateSubjectAsync(SubjectDto subjectDto, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(subjectDto != null);
		Contract.Requires<ArgumentException>(subjectDto.Id == default);

		var subject = new Subject();
		await subjectMapper.MapFromSubjectDtoAsync(subjectDto, subject, cancellationToken);

		unitOfWork.AddForInsert(subject);
		await unitOfWork.CommitAsync(cancellationToken);

		return Dto.FromValue(subject.Id);
	}

	[Authorize(Roles = nameof(Role.Administrator))]
	public async Task UpdateSubjectAsync(SubjectDto subjectDto, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(subjectDto != null);
		Contract.Requires<ArgumentException>(subjectDto.Id != default);

		var subject = await subjectRepository.GetObjectAsync(subjectDto.Id, cancellationToken);

		// TODO FUTURE - Teacher can edit own subjects
		//var currentUser = applicationAuthenticationService.GetCurrentUser();
		//if (!await userManager.IsInRolesAsync(currentUser, Role.Administrator))
		//{
		//	if (!subject.Teachers.Any(t => t.Id == currentUser.TeacherId))
		//	{
		//		throw new SecurityException("Access Denied. Not your subject.");
		//	}
		//}

		await subjectMapper.MapFromSubjectDtoAsync(subjectDto, subject, cancellationToken);

		unitOfWork.AddForUpdate(subject);
		await unitOfWork.CommitAsync(cancellationToken);
	}

	[Authorize(Roles = nameof(Role.Administrator))]
	public async Task DeleteSubjectAsync(Dto<int> subjectIdDto, CancellationToken cancellationToken = default)
	{
		var subject = await subjectRepository.GetObjectAsync(subjectIdDto.Value, cancellationToken);
		unitOfWork.AddForDelete(subject);

		var registrations = await studentSubjectRegistrationRepository.GetBySubjectAsync(subjectIdDto.Value, cancellationToken);
		unitOfWork.AddRangeForDelete(registrations);

		await unitOfWork.CommitAsync(cancellationToken);
	}

	public async Task<List<SubjectReferenceDto>> GetAllSubjectReferencesAsync(CancellationToken cancellationToken = default)
	{
		return (await subjectRepository.GetAllIncludingDeletedAsync(cancellationToken))
			.Select(s => new SubjectReferenceDto()
			{
				Id = s.Id,
				Name = s.Name,
				IsDeleted = s.Deleted is not null
			})
			.ToList();
	}
}
