namespace MensaGymnazium.IntranetGen3.Services.SubjectRegistration.ProgressValidation;

/// <param name="DoesRequireCsOrCpValidation">
/// Does the rule about needing N subjects from fields CSP or CP apply?
/// For 2023-2024 this applied to Septima, Oktava
/// </param>
/// <param name="AmountOfDonatedHoursInCsOrCp"></param>
/// <param name="RequiredMinimalAmountOfDonatedHoursInCsOrCp"></param>
public readonly record struct StudentCsOrCpRegistrationProgress(
	bool DoesRequireCsOrCpValidation,
	int AmountOfDonatedHoursInCsOrCp,
	int RequiredMinimalAmountOfDonatedHoursInCsOrCp)
{
	public bool IsProgressComplete =>
		AmountOfDonatedHoursInCsOrCp >= RequiredMinimalAmountOfDonatedHoursInCsOrCp;
}