using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Contracts;

public record SigningRuleReferenceDto
{
	public int Id { get; set; }
	public string Name { get; set; }
	public GradeEntry GradeId { get; set; }
}