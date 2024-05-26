namespace MensaGymnazium.IntranetGen3.Contracts;

public record StudentSubjectRegistrationProgressListItemDto
{
	public int StudentId { get; set; }
	public bool IsRegistrationValid { get; set; }
	//public List<string> MissingCriteria { get; set; } // Todo: add
}