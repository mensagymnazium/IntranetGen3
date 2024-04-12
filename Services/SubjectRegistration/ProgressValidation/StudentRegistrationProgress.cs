namespace MensaGymnazium.IntranetGen3.Services.SubjectRegistration.ProgressValidation;

public record StudentRegistrationProgress(
	StudentCsOrCpRegistrationProgress CsOrCpRegistrationProgress)
{
	/// <summary>
	/// When true, the student has registered all of his subjects correctly,
	/// meaning he meets all the signing criteria
	/// </summary>
	public bool DoesMeetAllCriteria => CsOrCpRegistrationProgress.MeetsCriteria;

	public StudentCsOrCpRegistrationProgress CsOrCpRegistrationProgress { get; init; } = CsOrCpRegistrationProgress;
}