using System.Security;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Facades.Infrastructure.Security.Authentication;
using MensaGymnazium.IntranetGen3.Primitives;
using MensaGymnazium.IntranetGen3.Services.SubjectRegistration.ProgressValidation;

namespace MensaGymnazium.IntranetGen3.Facades;

[Service]
[Authorize]
public class SubjectRegistrationProgressValidationFacade : ISubjectRegistrationProgressValidationFacade
{
	private readonly ISubjectRegistrationProgressValidationService subjectRegistrationProgressValidationService;
	private readonly IApplicationAuthenticationService applicationAuthenticationService;
	public SubjectRegistrationProgressValidationFacade(
		ISubjectRegistrationProgressValidationService subjectRegistrationProgressValidationService,
		IApplicationAuthenticationService applicationAuthenticationService)
	{
		this.subjectRegistrationProgressValidationService = subjectRegistrationProgressValidationService;
		this.applicationAuthenticationService = applicationAuthenticationService;
	}

	[Authorize(Roles = nameof(Role.Student))]
	public async Task<StudentRegistrationProgressDto> GetProgressOfCurrentStudentAsync()
	{
		var currentUser = applicationAuthenticationService.GetCurrentUser();
		Contract.Requires<SecurityException>(currentUser.StudentId is not null);

		var progress = await subjectRegistrationProgressValidationService.GetRegistrationProgressOfStudentAsync(currentUser.StudentId.Value);

		return MapToDto(progress);
	}

	[Authorize(Roles = nameof(Role.Administrator))]
	public Task<StudentRegistrationProgressDto> GetProgressOfStudentAsync(Dto<int> studentId)
	{
		//Todo: Implement
		throw new NotImplementedException();
	}

	private StudentRegistrationProgressDto MapToDto(StudentRegistrationProgress obj)
	{
		return new StudentRegistrationProgressDto(
			obj.IsRegistrationValid,

			obj.DonatedHoursProgress.AmountOfDonatedHoursExcludingLanguages,
			obj.DonatedHoursProgress.RequiredAmountOfDonatedHoursExcludingLanguages,
			obj.DonatedHoursProgress.MeetsCriteria,

			obj.CsOrCpRegistrationProgress.DoesRequireCsOrCpValidation,
			obj.CsOrCpRegistrationProgress.AmountOfDonatedHoursInCsOrCp,
			obj.CsOrCpRegistrationProgress.RequiredAmountOfDonatedHoursInCsOrCp,
			obj.CsOrCpRegistrationProgress.MeetsCriteria,

			obj.LanguageRegistrationProgress.IsLanguageRequired,
			obj.LanguageRegistrationProgress.HasRegisteredLanguage,
			obj.LanguageRegistrationProgress.MeetsCriteria,

			obj.CanUseLanguageInsteadOfDonatedHours
		);
	}
}