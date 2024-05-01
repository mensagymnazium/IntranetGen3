namespace MensaGymnazium.IntranetGen3.Services.SubjectRegistration.ProgressValidation;

/// <summary>
/// 
/// </summary>
/// <param name="IsRegistrationValid">
/// When true, the student has registered all of his subjects correctly,
/// meaning he meets all the signing criteria, or a combination of them,
/// that results in a valid registration
/// </param>
/// <param name="DonatedHoursProgress">
/// Progress of the rule about weekly donated hours
/// </param>
/// <param name="CsOrCpRegistrationProgress">
/// Progress of the rule:
/// 'N musí být ze vzdělávacích oblastí „Člověk a
/// společnost“ či „Člověk a příroda“'
/// </param>
/// <param name="LanguageRegistrationProgress">
/// Progress of the rule about having a language
/// </param>
public record StudentRegistrationProgress(
	bool IsRegistrationValid,
	StudentDonatedHoursProgress DonatedHoursProgress,
	StudentCsOrCpRegistrationProgress CsOrCpRegistrationProgress,
	StudentLanguageRegistrationProgress LanguageRegistrationProgress);
