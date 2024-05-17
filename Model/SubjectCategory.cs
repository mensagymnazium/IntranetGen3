using System.ComponentModel.DataAnnotations;
using Havit.Data.EntityFrameworkCore.Attributes;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Model;

[Cache]
public class SubjectCategory
{
	public int Id { get; set; }

	[MaxLength(50)]
	public string Name { get; set; }

	public static bool IsEntry(SubjectCategory subjectCategory, SubjectCategoryEntry subjectCategoryEntry)
	{
		return subjectCategory.Id == (int)subjectCategoryEntry;
	}
}
