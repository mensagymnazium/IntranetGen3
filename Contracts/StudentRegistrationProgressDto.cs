namespace MensaGymnazium.IntranetGen3.Contracts;

public record StudentRegistrationProgressDto
{
	public StudentRegistrationProgressDto(bool meetsAllCriteria,
		bool requiresCspOrCpValidation,
		int amOfDonatedHoursInCspOrCp,
		int requiredAmOfDonatedHoursInCspOrCp,
		bool meetsCsOrCpCriteria)
	{
		MeetsAllCriteria = meetsAllCriteria;
		RequiresCspOrCpValidation = requiresCspOrCpValidation;
		AmOfDonatedHoursInCspOrCp = amOfDonatedHoursInCspOrCp;
		RequiredAmOfDonatedHoursInCspOrCp = requiredAmOfDonatedHoursInCspOrCp;
		MeetsCsOrCpCriteria = meetsCsOrCpCriteria;
	}

	public StudentRegistrationProgressDto()
	{
		// Parameterless constructor required for serialization
	}

	public bool MeetsAllCriteria { get; set; }
	public bool RequiresCspOrCpValidation { get; set; }
	public int AmOfDonatedHoursInCspOrCp { get; set; }
	public int RequiredAmOfDonatedHoursInCspOrCp { get; set; }
	public bool MeetsCsOrCpCriteria { get; set; }
}