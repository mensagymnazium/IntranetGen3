namespace MensaGymnazium.IntranetGen3.Contracts;

public record SigningRuleWithRegistrationsDto : SigningRuleDto
{
	public List<StudentSubjectRegistrationDto> Registrations { get; set; } = new();
}