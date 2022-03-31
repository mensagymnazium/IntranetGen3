using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.Queries;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories;
using MensaGymnazium.IntranetGen3.Facades.Infrastructure.Security.Authentication;
using MensaGymnazium.IntranetGen3.Model;
using MensaGymnazium.IntranetGen3.Services;
using MensaGymnazium.IntranetGen3.Services.Security;

namespace MensaGymnazium.IntranetGen3.Facades;

[Service]
[Authorize]
public class SubjectFacade : ISubjectFacade
{
	private readonly ISubjectListQuery subjectListQuery;
	private readonly ISubjectRepository subjectRepository;
	private readonly IUnitOfWork unitOfWork;
	private readonly IApplicationAuthenticationService applicationAuthenticationService;
	private readonly IUserManager userManager;
	private readonly ISubjectMapper subjectMapper;

	public SubjectFacade(
		ISubjectListQuery subjectListQuery,
		ISubjectRepository subjectRepository,
		IUnitOfWork unitOfWork,
		IApplicationAuthenticationService applicationAuthenticationService,
		IUserManager userManager,
		ISubjectMapper subjectMapper)
	{
		this.subjectListQuery = subjectListQuery;
		this.subjectRepository = subjectRepository;
		this.unitOfWork = unitOfWork;
		this.applicationAuthenticationService = applicationAuthenticationService;
		this.userManager = userManager;
		this.subjectMapper = subjectMapper;
	}

	public async Task<DataFragmentResult<SubjectListItemDto>> GetSubjectListAsync(DataFragmentRequest<SubjectListQueryFilter> subjectListRequest, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(subjectListRequest is not null, nameof(subjectListRequest));

		subjectListQuery.Filter = subjectListRequest.Filter;
		subjectListQuery.Sorting = subjectListRequest.Sorting;

		return await subjectListQuery.GetDataFragmentAsync(subjectListRequest.StartIndex, subjectListRequest.Count, cancellationToken);
	}

	public async Task<SubjectDto> GetSubjectDetailAsync(Dto<int> subjectIdDto, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentException>(subjectIdDto.Value != default, nameof(subjectIdDto));

		var subject = await subjectRepository.GetObjectAsync(subjectIdDto.Value, cancellationToken);

		return await subjectMapper.MapToSubjectDtoAsync(subject);
	}

	//[Authorize(Roles = nameof(Role.Administrator))]
	public async Task<Dto<int>> CreateSubjectAsync(SubjectDto subjectDto, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(subjectDto != null, nameof(SubjectDto));
		Contract.Requires<ArgumentException>(subjectDto.SubjectId == default, nameof(SubjectDto.SubjectId));

		var subject = new Subject();
		subjectMapper.MapFromSubjectDto(subjectDto, subject);

		unitOfWork.AddForInsert(subject);
		await unitOfWork.CommitAsync(cancellationToken);

		return Dto.FromValue(subject.Id);
	}

	//[Authorize(Roles = $"{nameof(Role.Administrator)}, {nameof(Role.Teacher)}")]
	public async Task UpdateSubjectAsync(SubjectDto subjectDto, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(subjectDto != null, nameof(SubjectDto));
		Contract.Requires<ArgumentException>(subjectDto.SubjectId != default, nameof(SubjectDto.SubjectId));

		var subject = await subjectRepository.GetObjectAsync(subjectDto.SubjectId, cancellationToken);

		//var currentUser = applicationAuthenticationService.GetCurrentUser();
		//if (!await userManager.IsInRolesAsync(currentUser, Role.Administrator))
		//{
		//	if (!subject.Teachers.Any(t => t.Id == currentUser.TeacherId))
		//	{
		//		throw new SecurityException("Access Denied. Not your subject.");
		//	}
		//}

		subjectMapper.MapFromSubjectDto(subjectDto, subject);

		unitOfWork.AddForUpdate(subject);
		await unitOfWork.CommitAsync(cancellationToken);
	}

	public async Task DeleteSubjectAsync(Dto<int> subjectIdDto, CancellationToken cancellationToken = default)
	{
		var subject = await subjectRepository.GetObjectAsync(subjectIdDto.Value, cancellationToken);
		unitOfWork.AddForDelete(subject);

		await unitOfWork.CommitAsync(cancellationToken);
	}
}
