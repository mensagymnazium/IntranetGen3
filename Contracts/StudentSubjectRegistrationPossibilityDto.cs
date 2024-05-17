namespace MensaGymnazium.IntranetGen3.Contracts;

public record StudentSubjectRegistrationPossibilityDto
{
	public bool IsRegistrationPossible { get; set; }
	public string Reason { get; set; }

	public static StudentSubjectRegistrationPossibilityDto CreateNotPossible(string reason)
	{
		return new StudentSubjectRegistrationPossibilityDto
		{
			IsRegistrationPossible = false,
			Reason = reason
		};
	}

	public static StudentSubjectRegistrationPossibilityDto CreateYesPossible()
	{
		return new StudentSubjectRegistrationPossibilityDto
		{
			IsRegistrationPossible = true,
			Reason = string.Empty
		};
	}
}