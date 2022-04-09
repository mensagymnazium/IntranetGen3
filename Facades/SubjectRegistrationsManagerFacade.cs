using System.Security;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.Queries;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories;
using MensaGymnazium.IntranetGen3.Facades.Infrastructure.Security.Authentication;
using MensaGymnazium.IntranetGen3.Model;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Facades;

[Service]
[Authorize]
public class SubjectRegistrationsManagerFacade : ISubjectRegistrationsManagerFacade
{
	private readonly IStudentSigningRulesWithRegistrationsQuery studentSigningRulesWithRegistrationsQuery;
	private readonly IApplicationAuthenticationService applicationAuthenticationService;
	private readonly ISubjectRepository subjectRepository;
	private readonly IStudentSubjectRegistrationRepository studentSubjectRegistrationRepository;
	private readonly IUnitOfWork unitOfWork;
	private readonly IDataLoader dataLoader;

	public SubjectRegistrationsManagerFacade(
		IStudentSigningRulesWithRegistrationsQuery studentSigningRulesWithRegistrationsQuery,
		IApplicationAuthenticationService applicationAuthenticationService,
		ISubjectRepository subjectRepository,
		IStudentSubjectRegistrationRepository studentSubjectRegistrationRepository,
		IUnitOfWork unitOfWork,
		IDataLoader dataLoader)
	{
		this.studentSigningRulesWithRegistrationsQuery = studentSigningRulesWithRegistrationsQuery;
		this.applicationAuthenticationService = applicationAuthenticationService;
		this.subjectRepository = subjectRepository;
		this.studentSubjectRegistrationRepository = studentSubjectRegistrationRepository;
		this.unitOfWork = unitOfWork;
		this.dataLoader = dataLoader;
	}

	[Authorize(Roles = nameof(Role.Student))]
	public async Task CancelRegistrationAsync(Dto<int> studentSubjectRegistrationId, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(studentSubjectRegistrationId is not null);
		Contract.Requires<ArgumentException>(studentSubjectRegistrationId.Value != default);

		var studentSubjectRegistration = await studentSubjectRegistrationRepository.GetObjectAsync(studentSubjectRegistrationId.Value, cancellationToken);

		var currentUser = applicationAuthenticationService.GetCurrentUser();
		Contract.Requires<SecurityException>(studentSubjectRegistration.StudentId == currentUser.StudentId);

		unitOfWork.AddForDelete(studentSubjectRegistration);
		await unitOfWork.CommitAsync(cancellationToken);
	}

	[Authorize(Roles = nameof(Role.Student))]
	public async Task CreateRegistrationAsync(StudentSubjectRegistrationCreateDto studentSubjectRegistrationCreateDto, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(studentSubjectRegistrationCreateDto is not null);
		Contract.Requires<ArgumentException>(studentSubjectRegistrationCreateDto.SigningRuleId != default);
		Contract.Requires<ArgumentException>(studentSubjectRegistrationCreateDto.SubjectId != default);
		Contract.Requires<ArgumentException>(studentSubjectRegistrationCreateDto.RegistrationType != default);

		var currentUser = applicationAuthenticationService.GetCurrentUser();
		Contract.Requires<SecurityException>(currentUser.StudentId is not null);

		// TODO Check if student is allowed to sign up for this subject

		var studentSubjectRegistration = new StudentSubjectRegistration
		{
			StudentId = currentUser.StudentId.Value,
			UsedSigningRuleId = studentSubjectRegistrationCreateDto.SigningRuleId,
			SubjectId = studentSubjectRegistrationCreateDto.SubjectId,
			RegistrationType = studentSubjectRegistrationCreateDto.RegistrationType
		};

		unitOfWork.AddForInsert(studentSubjectRegistration);
		await unitOfWork.CommitAsync(cancellationToken);
	}

	[Authorize(Roles = nameof(Role.Student))]
	public async Task<List<SigningRuleWithRegistrationsDto>> GetCurrentUserSigningRulesWithRegistrationsAsync(Dto<int?> onlySubjectId, CancellationToken cancellationToken = default)
	{
		var user = applicationAuthenticationService.GetCurrentUser();
		Contract.Assert<InvalidOperationException>(user.Student is not null);

		Subject subjectFilter = null;
		if (onlySubjectId.Value.HasValue)
		{
			subjectFilter = await subjectRepository.GetObjectAsync(onlySubjectId.Value.Value, cancellationToken);
			await dataLoader.LoadAsync(subjectFilter, s => s.GradeRelations, cancellationToken);
			await dataLoader.LoadAsync(subjectFilter, s => s.TypeRelations, cancellationToken);
		}

		return await studentSigningRulesWithRegistrationsQuery.GetDataAsync(user.Student, subjectFilter, cancellationToken);
	}
}
