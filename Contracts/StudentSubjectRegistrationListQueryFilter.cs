using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Contracts;

public record StudentSubjectRegistrationListQueryFilter
{
	public int? SubjectId { get; set; }
	public int? GradeId { get; set; }
	public int? StudentId { get; set; }
	public StudentRegistrationType? RegistrationType { get; set; }
}
