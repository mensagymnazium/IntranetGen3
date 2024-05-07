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
	private readonly IApplicationAuthenticationService _applicationAuthenticationService;
	private readonly IUnitOfWork _unitOfWork;
	private readonly ISubjectRegistrationsManagerService _subjectRegistrationsManagerService;


	public SubjectRegistrationsManagerFacade(
		IApplicationAuthenticationService applicationAuthenticationService,
		IUnitOfWork unitOfWork, ISubjectRegistrationsManagerService subjectRegistrationsManagerService)
	{
		_applicationAuthenticationService = applicationAuthenticationService;
		_unitOfWork = unitOfWork;
		_subjectRegistrationsManagerService = subjectRegistrationsManagerService;
	}



	[Authorize(Roles = nameof(Role.Student))]
	public async Task CancelRegistrationAsync(Dto<int> studentSubjectRegistrationId, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(studentSubjectRegistrationId is not null);
		Contract.Requires<ArgumentException>(studentSubjectRegistrationId.Value != default);

		// Verify registration date
		if (!_subjectRegistrationsManagerService.IsRegistrationPeriodActive())
		{
			throw new OperationFailedException(
				"Přihlášku není možné zrušit. Je před, nebo již po termínu přihlašování");
		}

		// Cancel
		var currentUser = _applicationAuthenticationService.GetCurrentUser();
		Contract.Requires<SecurityException>(currentUser.StudentId is not null);
		await _subjectRegistrationsManagerService.CancelRegistrationAsync(studentSubjectRegistrationId.Value, currentUser.StudentId.Value, cancellationToken);

		await _unitOfWork.CommitAsync(cancellationToken);
	}

	[Authorize(Roles = nameof(Role.Student))]
	public async Task CreateRegistrationAsync(StudentSubjectRegistrationCreateDto studentSubjectRegistrationCreateDto, CancellationToken cancellationToken = default)
	{
		// Verify request
		Contract.Requires<ArgumentNullException>(studentSubjectRegistrationCreateDto is not null);
		Contract.Requires<ArgumentException>(studentSubjectRegistrationCreateDto.SubjectId != default);
		Contract.Requires<ArgumentException>(studentSubjectRegistrationCreateDto.RegistrationType != default);

		// Verify registration date
		if (!_subjectRegistrationsManagerService.IsRegistrationPeriodActive())
		{
			throw new OperationFailedException(
								"Přihlášku není možné vytvořit. Je před, nebo již po termínu přihlašování");
		}

		// Verify student isn't already registered for this subject
		var currentUser = _applicationAuthenticationService.GetCurrentUser();
		if (await _subjectRegistrationsManagerService.IsSubjectRegisteredForStudent(studentSubjectRegistrationCreateDto.SubjectId.Value, currentUser.StudentId.Value))
		{
			throw new OperationFailedException("Student už je přihlášený");
		}

		// Verify subject isn't full
		if (await _subjectRegistrationsManagerService
				.IsSubjectCapacityFullAsync(studentSubjectRegistrationCreateDto.SubjectId.Value))
		{
			throw new OperationFailedException("Předmět je již plný");
		}

		// Create registration
		Contract.Requires<SecurityException>(currentUser.StudentId is not null);

		_subjectRegistrationsManagerService.CreateNewSubjectRegistration(
			studentId: currentUser.StudentId.Value,
			subjectId: studentSubjectRegistrationCreateDto.SubjectId.Value,
			registrationType: studentSubjectRegistrationCreateDto.RegistrationType.Value);

		await _unitOfWork.CommitAsync(cancellationToken);
	}
}
