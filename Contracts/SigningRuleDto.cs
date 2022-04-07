namespace MensaGymnazium.IntranetGen3.Contracts;

public record SigningRuleDto : SigningRuleReferenceDto
{
	public int? Quantity { get; set; }

	public List<int> SubjectTypeIds { get; set; }

	public List<int> SubjectCategoryIds { get; set; }

	// TODO SigningRuleDtoValidator

}
