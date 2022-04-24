namespace MensaGymnazium.IntranetGen3.Contracts;
public record StudentWithSigningRuleListItemDto
{
	public int StudentId { get; set; }
	public int SigningRuleId { get; set; }
	public int MainRegistrationsCount { get; set; }
	public int SecondaryRegistrationsCount { get; set; }
	public int? SigningRuleQuantity { get; set; }
}
