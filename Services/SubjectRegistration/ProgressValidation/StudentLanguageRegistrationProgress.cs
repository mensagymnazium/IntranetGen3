namespace MensaGymnazium.IntranetGen3.Services.SubjectRegistration.ProgressValidation;

public record StudentLanguageRegistrationProgress(
	bool IsLanguageRequired,
	bool HasRegisteredLanguage)
{
	public bool MeetsCriteria
		=> (IsLanguageRequired && HasRegisteredLanguage)
		   || (!IsLanguageRequired);
}