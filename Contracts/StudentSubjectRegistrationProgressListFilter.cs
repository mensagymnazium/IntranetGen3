namespace MensaGymnazium.IntranetGen3.Contracts;

public record StudentSubjectRegistrationProgressListFilter
{
	public int? StudentId { get; set; }
	public int? GradeId { get; set; }
	/// <summary>
	/// True: only valid,
	/// False: only invalid registrations,
	/// Null: Property is omitted in filter -> both valid and invalid
	/// </summary>
	public bool? ValidationState { get; set; }
}