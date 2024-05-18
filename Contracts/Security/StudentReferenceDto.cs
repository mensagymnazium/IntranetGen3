namespace MensaGymnazium.IntranetGen3.Contracts.Security;

public record StudentReferenceDto
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string LastName { get; set; }
	public int UserId { get; set; }
	public int GradeId { get; set; }
	public bool IsDeleted { get; set; }
}
