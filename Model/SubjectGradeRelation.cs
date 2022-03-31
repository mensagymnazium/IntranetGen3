namespace MensaGymnazium.IntranetGen3.Model;

/// <summary>
/// M:N relationship - Subject : Grade
/// </summary>
public class SubjectGradeRelation
{
	public Subject Subject { get; set; }
	public int SubjectId { get; set; }

	public Grade Grade { get; set; }
	public int GradeId { get; set; }
}
