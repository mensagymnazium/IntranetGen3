using System.ComponentModel.DataAnnotations;
using Havit.Data.EntityFrameworkCore.Attributes;

namespace MensaGymnazium.IntranetGen3.Model;

[Cache]
public class SubjectCategory
{
	public int Id { get; set; }

	[MaxLength(50)]
	public string Name { get; set; }

	public enum Entry
	{
		GraduationSeminar = 1,
		ExtensionSeminar = 2,
		SpecialisationSeminar = 4,
		ForeignLanguage = 8
	}

	public static bool IsEntry(SubjectCategory subjectCategory, Entry entry)
	{
		return subjectCategory.Id == (int)entry;
	}
}
