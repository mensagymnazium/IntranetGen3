namespace MensaGymnazium.IntranetGen3.Contracts;

public record StudentRegistrationProgressDto
{
	public StudentRegistrationProgressDto(
		bool isRegistrationValid,
		int amOfHoursPerWeekExcludingLanguages,
		int requiredAmOfHoursPerWeekExcludingLanguages,
		bool isHoursPerWeekProgressComplete,
		bool requiresCsOrCpValidation,
		int amOfHoursPerWeekInCsOrCp,
		int requiredMinimalAmOfHoursPerWeekInCsOrCp,
		bool isCsOrCpProgressComplete,
		bool isLanguageRequired,
		bool hasRegisteredLanguage,
		bool canUseLanguageInsteadOfHoursPerWeek)
	{
		IsRegistrationValid = isRegistrationValid;
		RequiresCsOrCpValidation = requiresCsOrCpValidation;
		AmOfHoursPerWeekInCsOrCp = amOfHoursPerWeekInCsOrCp;
		RequiredMinimalAmOfHoursPerWeekInCsOrCp = requiredMinimalAmOfHoursPerWeekInCsOrCp;
		IsCsOrCpProgressComplete = isCsOrCpProgressComplete;
		IsLanguageRequired = isLanguageRequired;
		HasRegisteredLanguage = hasRegisteredLanguage;
		AmOfHoursPerWeekExcludingLanguages = amOfHoursPerWeekExcludingLanguages;
		RequiredAmOfHoursPerWeekExcludingLanguages = requiredAmOfHoursPerWeekExcludingLanguages;
		IsHoursPerWeekProgressComplete = isHoursPerWeekProgressComplete;
		CanUseLanguageInsteadOfHoursPerWeek = canUseLanguageInsteadOfHoursPerWeek;
	}

	private StudentRegistrationProgressDto()
	{
		// Parameterless constructor required for serialization
	}

	/// <summary>
	/// When true, the student has registered all of his subjects correctly,
	/// meaning he meets all the signing criteria, or a combination of them,
	/// that results in a valid registration
	/// </summary>
	public bool IsRegistrationValid { get; set; }

	public int AmOfHoursPerWeekExcludingLanguages { get; set; }
	public int RequiredAmOfHoursPerWeekExcludingLanguages { get; set; }
	public bool IsHoursPerWeekProgressComplete { get; set; }

	public bool RequiresCsOrCpValidation { get; set; }
	public int AmOfHoursPerWeekInCsOrCp { get; set; }
	public int RequiredMinimalAmOfHoursPerWeekInCsOrCp { get; set; }
	public bool IsCsOrCpProgressComplete { get; set; }

	public bool IsLanguageRequired { get; set; }
	public bool HasRegisteredLanguage { get; set; }
	public bool CanUseLanguageInsteadOfHoursPerWeek { get; set; }
}