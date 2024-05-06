namespace MensaGymnazium.IntranetGen3.Contracts;

public record StudentRegistrationProgressDto
{
	public StudentRegistrationProgressDto(
		bool isRegistrationValid,
		int amOfDonatedHoursExcludingLanguages,
		int requiredAmOfDonatedHoursExcludingLanguages,
		bool isDonatedHoursProgressComplete,
		bool requiresCspOrCpValidation,
		int amOfDonatedHoursInCspOrCp,
		int requiredMinimalAmOfDonatedHoursInCspOrCp,
		bool isCsOrCpProgressComplete,
		bool isLanguageRequired,
		bool hasRegisteredLanguage,
		bool canUseLanguageInsteadOfDonatedHours)
	{
		IsRegistrationValid = isRegistrationValid;
		RequiresCspOrCpValidation = requiresCspOrCpValidation;
		AmOfDonatedHoursInCspOrCp = amOfDonatedHoursInCspOrCp;
		RequiredMinimalAmOfDonatedHoursInCspOrCp = requiredMinimalAmOfDonatedHoursInCspOrCp;
		IsCsOrCpProgressComplete = isCsOrCpProgressComplete;
		IsLanguageRequired = isLanguageRequired;
		HasRegisteredLanguage = hasRegisteredLanguage;
		AmOfDonatedHoursExcludingLanguages = amOfDonatedHoursExcludingLanguages;
		RequiredAmOfDonatedHoursExcludingLanguages = requiredAmOfDonatedHoursExcludingLanguages;
		IsDonatedHoursProgressComplete = isDonatedHoursProgressComplete;
		CanUseLanguageInsteadOfDonatedHours = canUseLanguageInsteadOfDonatedHours;
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

	public int AmOfDonatedHoursExcludingLanguages { get; set; }
	public int RequiredAmOfDonatedHoursExcludingLanguages { get; set; }
	public bool IsDonatedHoursProgressComplete { get; set; }

	public bool RequiresCspOrCpValidation { get; set; }
	public int AmOfDonatedHoursInCspOrCp { get; set; }
	public int RequiredMinimalAmOfDonatedHoursInCspOrCp { get; set; }
	public bool IsCsOrCpProgressComplete { get; set; }

	public bool IsLanguageRequired { get; set; }
	public bool HasRegisteredLanguage { get; set; }
	public bool CanUseLanguageInsteadOfDonatedHours { get; set; }
}