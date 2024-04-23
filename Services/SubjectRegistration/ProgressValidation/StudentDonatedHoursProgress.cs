namespace MensaGymnazium.IntranetGen3.Services.SubjectRegistration.ProgressValidation;

public record StudentDonatedHoursProgress(
	int AmountOfDonatedHoursExcludingLanguages,
	int RequiredAmountOfDonatedHoursExcludingLanguages)
{
	public bool MeetsCriteria =>
		AmountOfDonatedHoursExcludingLanguages == RequiredAmountOfDonatedHoursExcludingLanguages;
}