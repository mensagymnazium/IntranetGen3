namespace MensaGymnazium.IntranetGen3.Services.SubjectRegistration.ProgressValidation;

/// <param name="IsRegistrationValid">
/// When true, the student has registered all of his subjects correctly,
/// meaning he meets all the signing criteria, or a combination of them,
/// that results in a valid registration
/// </param>
/// <param name="HoursPerWeekProgress">
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
/// <param name="CanUseLanguageInsteadOfHoursPerWeek">
/// If true, the student may choose a language instead of completing the donated hours mark.
/// Applied to Sekunda (2023/2024) and stated:
/// '1 volitelný předmět (může být i druhý cizí 
/// jazyk s dotací 2 hodiny týdně)'
/// </param>
public record StudentRegistrationProgress(
	StudentHoursPerWeekProgress HoursPerWeekProgress,
	StudentCsOrCpRegistrationProgress CsOrCpRegistrationProgress,
	StudentLanguageRegistrationProgress LanguageRegistrationProgress,
	bool CanUseLanguageInsteadOfHoursPerWeek)
{
	/// <summary>
	/// Returns true if student registered either too many hours
	/// or when he registered both a language and hours when he should only pick one
	/// </summary>
	public bool RegisteredTooMuch
		=>
		(HoursPerWeekProgress.AmountOfHoursPerWeekExcludingLanguages > HoursPerWeekProgress.RequiredAmountOfHoursPerWeekExcludingLanguages)
		|| (CanUseLanguageInsteadOfHoursPerWeek && HoursPerWeekProgress.IsProgressComplete && LanguageRegistrationProgress.HasRegisteredLanguage);

	/// <summary>
	/// Determines, whether the combination of "rule progresses" (i.e. <see cref="StudentCsOrCpRegistrationProgress"/>)
	/// results in a valid registration (<see cref="StudentRegistrationProgress.IsRegistrationValid"/>).
	/// 
	/// This will be useful, when exceptions in the criteria are made, such as - Prima can choose a second language
	/// instead of filling the donated hours with regular subjects, so he won't fill the donated hours criteria,
	/// but it will still result in a valid registration.
	/// </summary>
	public bool IsRegistrationValid()
	{
		var isRegistrationValid = true;

		// Determine based on csOrCp
		if (CsOrCpRegistrationProgress.DoesRequireCsOrCpValidation)
		{
			isRegistrationValid &= CsOrCpRegistrationProgress.IsProgressComplete;
		}

		// Determine based on if student can use language instead of donated hours
		if (CanUseLanguageInsteadOfHoursPerWeek
			&& LanguageRegistrationProgress.HasRegisteredLanguage)
		{
			// If language progress is sufficient, we should check, that the student doesn't have any other donated hours
			isRegistrationValid &= HoursPerWeekProgress.AmountOfHoursPerWeekExcludingLanguages == 0;
		}
		else
		{
			// -> Cannot skip donated hours validation (more common)
			isRegistrationValid &= HoursPerWeekProgress.IsProgressComplete;
		}

		// Determine based on language
		if (LanguageRegistrationProgress.IsLanguageRequired)
		{
			isRegistrationValid &= LanguageRegistrationProgress.HasRegisteredLanguage;
		}

		return isRegistrationValid;
	}
}
