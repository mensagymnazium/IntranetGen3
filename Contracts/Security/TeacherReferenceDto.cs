namespace MensaGymnazium.IntranetGen3.Contracts.Security;

public record TeacherReferenceDto
{
	public int TeacherId { get; set; }
	public string Name { get; set; }
	public int UserId { get; set; }
	public bool IsDeleted { get; set; }
}
