namespace MensaGymnazium.IntranetGen3.Contracts;

public record RegistrationsDto : SigningRuleDto
{
	public List<StudentSubjectRegistrationDto> Registrations { get; set; } = new();
}