namespace MensaGymnazium.IntranetGen3.Contracts;

public class SigningRuleDto
{
	public int? SigningRuleId { get; set; }

	public string Name { get; set; }

	public int? Quantity { get; set; }

	public List<int> SubjectTypeIds { get; set; }

	public List<int> SubjectCategoryIds { get; set; }

	public int GradeId { get; set; }

	// TODO SigningRuleDtoValidator

}
