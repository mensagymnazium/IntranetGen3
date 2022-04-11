namespace MensaGymnazium.IntranetGen3.Contracts;

public record StudentSubjectRegistrationListQueryFilter
{
	public int? SubjectId { get; set; }
	public int? GradeId { get; set; }
	public int? SigningRuleId { get; set; }
}
