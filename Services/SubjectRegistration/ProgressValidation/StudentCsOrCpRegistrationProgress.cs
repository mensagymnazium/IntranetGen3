namespace MensaGymnazium.IntranetGen3.Services.SubjectRegistration.ProgressValidation;

public record StudentCsOrCpRegistrationProgress(
	bool DoesRequireCsOrCpValidation,
	int AmountOfDonatedHoursInCsOrCp,
	int RequiredAmountOfDonatedHoursInCsOrCp)
{
	/// <summary>
	/// Does the rule about needing N subjects from fields CSP or CP apply?
	/// For 2023-2024 this applied to Septima, Oktava
	/// </summary>
	public bool DoesRequireCsOrCpValidation { get; init; } = DoesRequireCsOrCpValidation;

	public bool MeetsCriteria => AmountOfDonatedHoursInCsOrCp == RequiredAmountOfDonatedHoursInCsOrCp;
}