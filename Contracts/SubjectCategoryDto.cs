namespace MensaGymnazium.IntranetGen3.Contracts;

public record SubjectCategoryDto
{
	public int Id { get; set; }
	public string Name { get; set; }
	public DtoEntry Entry => (DtoEntry)Id;

	/// <summary>
	/// Numbered same as in application
	/// </summary>
	public enum DtoEntry
	{
		GraduationSeminar = 1,
		ExtensionSeminar = 2,
		SpecialisationSeminar = 4,
		ForeignLanguage = 8
	}
}
