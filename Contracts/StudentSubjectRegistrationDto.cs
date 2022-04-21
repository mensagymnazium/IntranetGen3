using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Contracts;

public record StudentSubjectRegistrationDto : StudentSubjectRegistrationCreateDto
{
	public int Id { get; set; }
	public int? StudentId { get; set; }
	public DateTime Created { get; set; }
}
