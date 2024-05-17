namespace MensaGymnazium.IntranetGen3.Contracts;

public record SubjectReferenceDto
{
	public int Id { get; set; }
	public string Name { get; set; }
	public bool IsDeleted { get; set; }
	public int? CategoryId { get; set; }
}
