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
	private readonly ISubjectRegistrationProgressValidationService _subjectRegistrationProgressValidationService;
	private readonly IApplicationAuthenticationService _applicationAuthenticationService;
	public SubjectRegistrationProgressValidationFacade(
		ISubjectRegistrationProgressValidationService subjectRegistrationProgressValidationService,
		IApplicationAuthenticationService applicationAuthenticationService)
	{
		_subjectRegistrationProgressValidationService = subjectRegistrationProgressValidationService;
		_applicationAuthenticationService = applicationAuthenticationService;
	}

	[Authorize(Roles = nameof(Role.Student))]
	public async Task<StudentRegistrationProgressDto> GetProgressOfCurrentStudentAsync(CancellationToken cancellationToken = default)
	{
		var currentUser = _applicationAuthenticationService.GetCurrentUser();
		Contract.Requires<SecurityException>(currentUser.StudentId is not null);

		var progress = await _subjectRegistrationProgressValidationService.GetRegistrationProgressOfStudentAsync(
			currentUser.StudentId.Value,
			cancellationToken);

		return MapToDto(progress);
	}

	[Authorize(Roles = nameof(Role.Administrator))]
	public Task<List<StudentRegistrationProgressListItemDto>> GetStudentRegistrationProgressListAsync(CancellationToken cancellationToken = default)
	{
		var 
	}

	private StudentRegistrationProgressDto MapToDto(StudentRegistrationProgress obj)
	{
		return new StudentRegistrationProgressDto(
			obj.IsRegistrationValid,

			obj.HoursPerWeekProgress.AmountOfHoursPerWeekExcludingLanguages,
			obj.HoursPerWeekProgress.RequiredAmountOfHoursPerWeekExcludingLanguages,
			obj.HoursPerWeekProgress.IsProgressComplete,

			obj.CsOrCpRegistrationProgress.DoesRequireCsOrCpValidation,
			obj.CsOrCpRegistrationProgress.AmountOfHoursPerWeekInCsOrCp,
			obj.CsOrCpRegistrationProgress.RequiredMinimalAmountOfHoursPerWeekInCsOrCp,
			obj.CsOrCpRegistrationProgress.IsProgressComplete,

			obj.LanguageRegistrationProgress.IsLanguageRequired,
			obj.LanguageRegistrationProgress.HasRegisteredLanguage,

			obj.CanUseLanguageInsteadOfHoursPerWeek
		);
	}
}