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
		//Contract.Requires<ArgumentException>(studentSubjectRegistrationCreateDto.SigningRuleId != default);
		Contract.Requires<ArgumentException>(studentSubjectRegistrationCreateDto.SubjectId != default);
		Contract.Requires<ArgumentException>(studentSubjectRegistrationCreateDto.RegistrationType != default);

		// Verify registration date
		Contract.Requires<OperationFailedException>(RegistrationIsWithinValidDate(), "Přihlášku není možné založit. Je před, nebo již po termínu přihlašování");

		//// Verify registration requirements
		//var signingRulesForRegistration = await GetCurrentUserSubjectSigningRulesForRegistrationAsync(Dto.FromValue(studentSubjectRegistrationCreateDto.SubjectId.Value), cancellationToken);
		//var signingRuleForRegistrationDto = signingRulesForRegistration.Single(sr => sr.Id == studentSubjectRegistrationCreateDto.SigningRuleId);
		//Contract.Requires<ArgumentException>(signingRuleForRegistrationDto is not null);

		//switch (studentSubjectRegistrationCreateDto.RegistrationType)
		//{
		//	case StudentRegistrationType.Main:
		//		Contract.Requires<OperationFailedException>(signingRuleForRegistrationDto.MainRegistrationAllowed, signingRuleForRegistrationDto.MainRegistrationNotAllowedReason);
		//		break;
		//	case StudentRegistrationType.Secondary:
		//		Contract.Requires<OperationFailedException>(signingRuleForRegistrationDto.SecondaryRegistrationAllowed, signingRuleForRegistrationDto.SecondaryRegistrationNotAllowedReason);
		//		break;
		//	default:
		//		throw new InvalidOperationException($"Unknown {nameof(StudentRegistrationType)} value: {studentSubjectRegistrationCreateDto.RegistrationType}.");
		//}

		// create registration
		var currentUser = applicationAuthenticationService.GetCurrentUser();
		Contract.Requires<SecurityException>(currentUser.StudentId is not null);

		var studentSubjectRegistration = new StudentSubjectRegistration
		{
			StudentId = currentUser.StudentId.Value,
			//UsedSigningRuleId = studentSubjectRegistrationCreateDto.SigningRuleId.Value,
			SubjectId = studentSubjectRegistrationCreateDto.SubjectId.Value,
			RegistrationType = studentSubjectRegistrationCreateDto.RegistrationType.Value
		};

		unitOfWork.AddForInsert(studentSubjectRegistration);
		await unitOfWork.CommitAsync(cancellationToken);
	}



	//[Authorize(Roles = nameof(Role.Student))]
	//public async Task<List<StudentRegistrationsDto>> GetCurrentUserSubjectSigningRulesForRegistrationAsync(Dto<int> subjectId, CancellationToken cancellationToken = default)
	//{
	//	var signingRulesWithRegistrations = await GetCurrentUserSigningRulesWithRegistrationsAsync(Dto.FromValue((int?)subjectId.Value), cancellationToken);

	//	List<StudentRegistrationsDto> result = new();

	//	var subjectRegistered = signingRulesWithRegistrations.SelectMany(x => x.Registrations).Any(ssr => ssr.SubjectId == subjectId.Value);
	//	var subject = await subjectRepository.GetObjectAsync(subjectId.Value, cancellationToken);
	//	var registrationCount = await studentSubjectRegistrationRepository.CountBySubjectAndTypeAsync(subjectId.Value, StudentRegistrationType.Main, cancellationToken);

	//	var user = applicationAuthenticationService.GetCurrentUser();
	//	Contract.Assert<InvalidOperationException>(user.Student is not null);

	//	var collisions = await studentSubjectRegistrationRepository.GetByStudentAndTimeAsync(user.Student.Id, subject.ScheduleDayOfWeek, subject.ScheduleSlotInDay, cancellationToken);

	//	foreach (var item in signingRulesWithRegistrations)
	//	{
	//		var resultItem = new StudentRegistrationsDto();
	//		resultItem.Id = item.Id;
	//		resultItem.Name = item.Name;

	//		// main
	//		resultItem.MainRegistration = item.Registrations.FirstOrDefault(r => (r.SubjectId == subjectId.Value)
	//															&& (r.RegistrationType == StudentRegistrationType.Main));
	//		if (resultItem.MainRegistration is not null)
	//		{
	//			resultItem.MainRegistrationAllowed = false;
	//			resultItem.MainRegistrationNotAllowedReason = "Primární registrace tohoto předmětu k tomu pravidlu již existuje.";
	//		}
	//		else if (item.Registrations.Count(r => r.RegistrationType == StudentRegistrationType.Main) >= item.Quantity)
	//		{
	//			resultItem.MainRegistrationAllowed = false;
	//			resultItem.MainRegistrationNotAllowedReason = "Počet primárních registrací tohoto pravidla vyčerpán.";
	//		}
	//		else if (subjectRegistered)
	//		{
	//			resultItem.MainRegistrationAllowed = false;
	//			resultItem.MainRegistrationNotAllowedReason = "Předmět je již registrován.";
	//		}
	//		else if (subject.Capacity != null && registrationCount >= subject.Capacity)
	//		{
	//			resultItem.MainRegistrationAllowed = false;
	//			resultItem.MainRegistrationNotAllowedReason = "Kapacita předmětu je naplněna.";
	//		}
	//		else if (collisions.Count > 0)
	//		{
	//			resultItem.MainRegistrationAllowed = false;
	//			resultItem.MainRegistrationNotAllowedReason = "Předmět koliduje časově s jiným předmětem.";
	//		}
	//		else
	//		{
	//			resultItem.MainRegistrationAllowed = true;
	//		}

	//		// secondary
	//		resultItem.SecondaryRegistration = item.Registrations.FirstOrDefault(r => (r.SubjectId == subjectId.Value) && (r.RegistrationType == StudentRegistrationType.Secondary));
	//		if (resultItem.SecondaryRegistration is not null)
	//		{
	//			resultItem.SecondaryRegistrationAllowed = false;
	//			resultItem.SecondaryRegistrationNotAllowedReason = "Náhradní registrace tohoto předmětu k tomu pravidlu již existuje.";
	//		}
	//		else if (item.Registrations.Count(r => r.RegistrationType == StudentRegistrationType.Secondary) >= item.Quantity)
	//		{
	//			resultItem.SecondaryRegistrationAllowed = false;
	//			resultItem.SecondaryRegistrationNotAllowedReason = "Počet náhradních registrací tohoto pravidla vyčerpán.";
	//		}
	//		else if (subjectRegistered)
	//		{
	//			resultItem.SecondaryRegistrationAllowed = false;
	//			resultItem.SecondaryRegistrationNotAllowedReason = "Předmět je již registrován.";
	//		}
	//		else
	//		{
	//			resultItem.SecondaryRegistrationAllowed = true;
	//		}

	//		result.Add(resultItem);
	//	}

	//	return result;
	//}

	//[Authorize(Roles = nameof(Role.Student))]
	//public async Task<List<RegistrationsDto>> GetCurrentUserSigningRulesWithRegistrationsAsync(Dto<int?> onlySubjectId, CancellationToken cancellationToken = default)
	//{
	//	var user = applicationAuthenticationService.GetCurrentUser();
	//	Contract.Assert<InvalidOperationException>(user.Student is not null);

	//	Subject subjectFilter = null;
	//	if (onlySubjectId.Value.HasValue)
	//	{
	//		subjectFilter = await subjectRepository.GetObjectAsync(onlySubjectId.Value.Value, cancellationToken);
	//		await dataLoader.LoadAsync(subjectFilter, s => s.GradeRelations, cancellationToken);
	//		await dataLoader.LoadAsync(subjectFilter, s => s.TypeRelations, cancellationToken);
	//	}

	//	return await studentSigningRulesWithRegistrationsQuery.GetDataAsync(user.Student, subjectFilter, cancellationToken);
	//}

	//public async Task<DataFragmentResult<StudentWithSigningRuleListItemDto>> GetStudentWithSigningRuleListAsync(DataFragmentRequest<StudentWithSigningRuleListQueryFilter> facadeRequest, CancellationToken cancellationToken)
	//{
	//	if (facadeRequest.Filter.CurrentStudentOnly)
	//	{
	//		var user = applicationAuthenticationService.GetCurrentUser();
	//		Contract.Requires<InvalidOperationException>(user.StudentId is not null);
	//		facadeRequest.Filter.StudentId = user.StudentId;
	//	}

	//	studentWithSigningRuleListQuery.Filter = facadeRequest.Filter;
	//	studentWithSigningRuleListQuery.Sorting = facadeRequest.Sorting;

	//	return await studentWithSigningRuleListQuery.GetDataFragmentAsync(facadeRequest.StartIndex, facadeRequest.Count, cancellationToken);
	//}
}
