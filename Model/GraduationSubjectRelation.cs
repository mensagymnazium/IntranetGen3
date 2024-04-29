using Havit.Data.EntityFrameworkCore.Attributes;

namespace MensaGymnazium.IntranetGen3.Model;

/// <summary>
/// M:N relation representing Subject.GraduationSubject
/// </summary>
[Cache]
public class GraduationSubjectRelation
{
	public Subject Subject { get; set; }
	public int SubjectId { get; set; }

	public GraduationSubject GraduationSubject { get; set; }
	public int GraduationSubjectId { get; set; }
}
