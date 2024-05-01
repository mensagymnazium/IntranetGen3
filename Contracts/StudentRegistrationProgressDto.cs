namespace MensaGymnazium.IntranetGen3.Contracts;

public record StudentRegistrationProgressDto
{
	public StudentRegistrationProgressDto(
		bool isRegistrationValid,
		int amOfDonatedHoursExcludingLanguages,
		int requiredAmOfDonatedHoursExcludingLanguages,
		bool meetsDonatedHoursCriteria,
		bool requiresCspOrCpValidation,
		int amOfDonatedHoursInCspOrCp,
		int requiredAmOfDonatedHoursInCspOrCp,
		bool meetsCsOrCpCriteria,
		bool isLanguageRequired,
		bool hasRegisteredLanguage, bool meetsLanguageCriteria)
	{
		IsRegistrationValid = isRegistrationValid;
		RequiresCspOrCpValidation = requiresCspOrCpValidation;
		AmOfDonatedHoursInCspOrCp = amOfDonatedHoursInCspOrCp;
		RequiredAmOfDonatedHoursInCspOrCp = requiredAmOfDonatedHoursInCspOrCp;
		MeetsCsOrCpCriteria = meetsCsOrCpCriteria;
		IsLanguageRequired = isLanguageRequired;
		HasRegisteredLanguage = hasRegisteredLanguage;
		MeetsLanguageCriteria = meetsLanguageCriteria;
		AmOfDonatedHoursExcludingLanguages = amOfDonatedHoursExcludingLanguages;
		RequiredAmOfDonatedHoursExcludingLanguages = requiredAmOfDonatedHoursExcludingLanguages;
		MeetsDonatedHoursCriteria = meetsDonatedHoursCriteria;
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
	public bool MeetsDonatedHoursCriteria { get; set; }

	public bool RequiresCspOrCpValidation { get; set; }
	public int AmOfDonatedHoursInCspOrCp { get; set; }
	public int RequiredAmOfDonatedHoursInCspOrCp { get; set; }
	public bool MeetsCsOrCpCriteria { get; set; }

	public bool IsLanguageRequired { get; set; }
	public bool HasRegisteredLanguage { get; set; }
	public bool MeetsLanguageCriteria { get; set; }
}