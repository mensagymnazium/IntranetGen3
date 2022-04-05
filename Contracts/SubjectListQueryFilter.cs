namespace MensaGymnazium.IntranetGen3.Contracts;

public record SubjectListQueryFilter
{
	public string Name { get; set; }
	public int? SubjectTypeId { get; set; }
	public int? SubjectCategoryId { get; set; }
	public int? TeacherId { get; set; }
	public int? SigningRuleId { get; set; }
}
