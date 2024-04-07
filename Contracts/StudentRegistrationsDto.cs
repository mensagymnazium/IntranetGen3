namespace MensaGymnazium.IntranetGen3.Contracts;

public record StudentRegistrationsDto
{
	public int Id { get; set; }
	public string Name { get; set; }

	public StudentSubjectRegistrationDto MainRegistration { get; set; }
	public bool MainRegistrationAllowed { get; set; }
	public string MainRegistrationNotAllowedReason { get; set; }

	public StudentSubjectRegistrationDto SecondaryRegistration { get; set; }
	public bool SecondaryRegistrationAllowed { get; set; }
	public string SecondaryRegistrationNotAllowedReason { get; set; }
}
