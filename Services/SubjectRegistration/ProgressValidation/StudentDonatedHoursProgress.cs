namespace MensaGymnazium.IntranetGen3.Services.SubjectRegistration.ProgressValidation;

public record StudentHoursPerWeekProgress(
	int AmountOfHoursPerWeekExcludingLanguages,
	int RequiredAmountOfHoursPerWeekExcludingLanguages)
{
	public bool IsProgressComplete =>
		AmountOfHoursPerWeekExcludingLanguages == RequiredAmountOfHoursPerWeekExcludingLanguages;
}