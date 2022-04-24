namespace MensaGymnazium.IntranetGen3.Contracts;

public record StudentWithSigningRuleListQueryFilter
{
	public int? GradeId { get; set; }
	public int? StudentId { get; set; }
	public int? SigningRuleId { get; set; }

}
