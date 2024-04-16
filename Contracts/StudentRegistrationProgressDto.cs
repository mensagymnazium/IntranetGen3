namespace MensaGymnazium.IntranetGen3.Contracts;

public record StudentRegistrationProgressDto
{
	public StudentRegistrationProgressDto(
		bool isRegistrationValid,
		bool requiresCspOrCpValidation,
		int amOfDonatedHoursInCspOrCp,
		int requiredAmOfDonatedHoursInCspOrCp,
		bool meetsCsOrCpCriteria)
	{
		IsRegistrationValid = isRegistrationValid;
		RequiresCspOrCpValidation = requiresCspOrCpValidation;
		AmOfDonatedHoursInCspOrCp = amOfDonatedHoursInCspOrCp;
		RequiredAmOfDonatedHoursInCspOrCp = requiredAmOfDonatedHoursInCspOrCp;
		MeetsCsOrCpCriteria = meetsCsOrCpCriteria;
	}

	public StudentRegistrationProgressDto()
	{
		// Parameterless constructor required for serialization
	}

	/// <summary>
	/// When true, the student has registered all of his subjects correctly,
	/// meaning he meets all the signing criteria, or a combination of them,
	/// that results in a valid registration
	/// </summary>
	public bool IsRegistrationValid { get; set; }
	public bool RequiresCspOrCpValidation { get; set; }
	public int AmOfDonatedHoursInCspOrCp { get; set; }
	public int RequiredAmOfDonatedHoursInCspOrCp { get; set; }
	public bool MeetsCsOrCpCriteria { get; set; }
}