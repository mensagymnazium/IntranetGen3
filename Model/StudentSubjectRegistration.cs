using MensaGymnazium.IntranetGen3.Model.Security;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Model;

public class StudentSubjectRegistration
{
	public int Id { get; set; }

	public Student Student { get; set; }
	public int StudentId { get; set; }

	public Subject Subject { get; set; }
	public int SubjectId { get; set; }

	public StudentRegistrationType RegistrationType { get; set; }

	public SigningRule UsedSigningRule { get; set; }
	public int UsedSigningRuleId { get; set; }

	public DateTime Created { get; set; }
	public DateTime? Deleted { get; set; }
}
