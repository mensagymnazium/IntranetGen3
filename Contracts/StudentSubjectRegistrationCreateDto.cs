using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Contracts;

public record StudentSubjectRegistrationCreateDto
{
	public int SubjectId { get; set; }
	public int SigningRuleId { get; set; }
	public StudentRegistrationType RegistrationType { get; set; }
}
