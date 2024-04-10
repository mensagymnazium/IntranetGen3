using System.Security;
using Havit;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Facades.Infrastructure.Security.Authentication;
using MensaGymnazium.IntranetGen3.Primitives;
using MensaGymnazium.IntranetGen3.Services.SubjectRegistration;

namespace MensaGymnazium.IntranetGen3.Facades;

[Service]
[Authorize]
public class SubjectRegistrationsManagerFacade : ISubjectRegistrationsManagerFacade
{
	private readonly IApplicationAuthenticationService applicationAuthenticationService;
	private readonly IUnitOfWork unitOfWork;
	private readonly ISubjectRegistrationsManagerService subjectRegistrationsManagerService;


	public SubjectRegistrationsManagerFacade(
		IApplicationAuthenticationService applicationAuthenticationService,
		IUnitOfWork unitOfWork, ISubjectRegistrationsManagerService subjectRegistrationsManagerService)
	{
		this.applicationAuthenticationService = applicationAuthenticationService;
		this.unitOfWork = unitOfWork;
		this.subjectRegistrationsManagerService = subjectRegistrationsManagerService;
	}



	[Authorize(Roles = nameof(Role.Student))]
	public async Task CancelRegistrationAsync(Dto<int> studentSubjectRegistrationId, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(studentSubjectRegistrationId is not null);
		Contract.Requires<ArgumentException>(studentSubjectRegistrationId.Value != default);

		// Verify registration date
		if (!subjectRegistrationsManagerService.IsRegistrationPeriodActive())
		{
			throw new OperationFailedException(
				"Přihlášku není možné zrušit. Je před, nebo již po termínu přihlašování");
		}

		// Cancel
		var currentUser = applicationAuthenticationService.GetCurrentUser();
		Contract.Requires<SecurityException>(currentUser.StudentId is not null);
		await subjectRegistrationsManagerService.CancelRegistrationAsync(studentSubjectRegistrationId.Value, currentUser.StudentId.Value, cancellationToken);

		await unitOfWork.CommitAsync(cancellationToken);
	}

	[Authorize(Roles = nameof(Role.Student))]
	public async Task CreateRegistrationAsync(StudentSubjectRegistrationCreateDto studentSubjectRegistrationCreateDto, CancellationToken cancellationToken = default)
	{
		// Verify request
		Contract.Requires<ArgumentNullException>(studentSubjectRegistrationCreateDto is not null);
		Contract.Requires<ArgumentException>(studentSubjectRegistrationCreateDto.SubjectId != default);
		Contract.Requires<ArgumentException>(studentSubjectRegistrationCreateDto.RegistrationType != default);

		// Verify registration date
		if (!subjectRegistrationsManagerService.IsRegistrationPeriodActive())
		{
			throw new OperationFailedException(
								"Přihlášku není možné vytvořit. Je před, nebo již po termínu přihlašování");
		}

		// Create registration
		var currentUser = applicationAuthenticationService.GetCurrentUser();
		Contract.Requires<SecurityException>(currentUser.StudentId is not null);

		subjectRegistrationsManagerService.CreateNewSubjectRegistration(
			studentId: currentUser.StudentId.Value,
			subjectId: studentSubjectRegistrationCreateDto.SubjectId.Value,
			registrationType: studentSubjectRegistrationCreateDto.RegistrationType.Value);

		await unitOfWork.CommitAsync(cancellationToken);
	}
}
