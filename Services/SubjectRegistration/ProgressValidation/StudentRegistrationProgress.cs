namespace MensaGymnazium.IntranetGen3.Services.SubjectRegistration.ProgressValidation;

public record StudentRegistrationProgress(
	bool IsRegistrationValid,
	StudentCsOrCpRegistrationProgress CsOrCpRegistrationProgress)
{
	/// <summary>
	/// When true, the student has registered all of his subjects correctly,
	/// meaning he meets all the signing criteria, or a combination of them,
	/// that results in a valid registration
	/// </summary>
	public bool IsRegistrationValid { get; init; } = IsRegistrationValid;

	/// <summary>
	/// Progress of the rule:
	/// 'N musí být ze vzdělávacích oblastí „Člověk a
	/// společnost“ či „Člověk a příroda“'
	/// </summary>
	public StudentCsOrCpRegistrationProgress CsOrCpRegistrationProgress { get; init; } = CsOrCpRegistrationProgress;
}