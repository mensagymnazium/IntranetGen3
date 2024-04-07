using System.Security;
using Havit;
using Havit.Services.TimeServices;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.DataEntries.Common;
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
	private readonly IApplicationAuthenticationService applicationAuthenticationService;
	private readonly IStudentSubjectRegistrationRepository studentSubjectRegistrationRepository;
	private readonly IUnitOfWork unitOfWork;
	private readonly ITimeService timeService;
	private readonly IApplicationSettingsEntries applicationSettingsEntries;

	public SubjectRegistrationsManagerFacade(
		IApplicationAuthenticationService applicationAuthenticationService,
		IStudentSubjectRegistrationRepository studentSubjectRegistrationRepository,
		IUnitOfWork unitOfWork,
		ITimeService timeService,
		IApplicationSettingsEntries applicationSettingsEntries)
	{
		this.applicationAuthenticationService = applicationAuthenticationService;
		this.studentSubjectRegistrationRepository = studentSubjectRegistrationRepository;
		this.unitOfWork = unitOfWork;
		this.timeService = timeService;
		this.applicationSettingsEntries = applicationSettingsEntries;
	}

	private bool RegistrationIsWithinValidDate()
	{
		var allowedFrom = applicationSettingsEntries.Current.SubjectRegistrationAllowedFrom;
		var allowedTo = applicationSettingsEntries.Current.SubjectRegistrationAllowedTo;
		var today = timeService.GetCurrentDate();

		if (allowedFrom is not null && today < allowedFrom)
		{
			return false;
		}

		if (allowedTo is not null && today > allowedTo)
		{
			return false;
		}

		return true;
	}

	[Authorize(Roles = nameof(Role.Student))]
	public async Task<StudentSubjectRegistrationDto> GetCurrentUserRegistrationForSubject(Dto<int> subjectId, CancellationToken cancellationToken = default)
	{
		var user = applicationAuthenticationService.GetCurrentUser();
		Contract.Requires<InvalidOperationException>(user.StudentId is not null);

		// Todo: change to query?
		var registration = await studentSubjectRegistrationRepository.GetByStudentForSubject(
			studentId: user.Id,
			subjectId: subjectId.Value,
			cancellationToken: cancellationToken);

		if (registration is null) // No registration
		{
			return new();
		}

		// Map
		return new StudentSubjectRegistrationDto()
		{
			RegistrationType = registration.RegistrationType,
			Created = registration.Created,
			Id = registration.Id,
			StudentId = registration.StudentId, // Should be same as input
			SubjectId = registration.SubjectId // Should be same as input
		};
	}

	[Authorize(Roles = nameof(Role.Student))]
	public async Task CancelRegistrationAsync(Dto<int> studentSubjectRegistrationId, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(studentSubjectRegistrationId is not null);
		Contract.Requires<ArgumentException>(studentSubjectRegistrationId.Value != default);

		var studentSubjectRegistration = await studentSubjectRegistrationRepository.GetObjectAsync(studentSubjectRegistrationId.Value, cancellationToken);

		var currentUser = applicationAuthenticationService.GetCurrentUser();
		Contract.Requires<SecurityException>(studentSubjectRegistration.StudentId == currentUser.StudentId);

		// Verify registration dat
		Contract.Requires<OperationFailedException>(RegistrationIsWithinValidDate(), "Přihlášku není možné zrušit. Je před, nebo již po termínu přihlašování");

		unitOfWork.AddForDelete(studentSubjectRegistration);
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
		Contract.Requires<OperationFailedException>(RegistrationIsWithinValidDate(), "Přihlášku není možné založit. Je před, nebo již po termínu přihlašování");

		// create registration
		var currentUser = applicationAuthenticationService.GetCurrentUser();
		Contract.Requires<SecurityException>(currentUser.StudentId is not null);

		var studentSubjectRegistration = new StudentSubjectRegistration
		{
			StudentId = currentUser.StudentId.Value,
			SubjectId = studentSubjectRegistrationCreateDto.SubjectId.Value,
			RegistrationType = studentSubjectRegistrationCreateDto.RegistrationType.Value
		};

		unitOfWork.AddForInsert(studentSubjectRegistration);
		await unitOfWork.CommitAsync(cancellationToken);
	}
}
