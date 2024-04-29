using System.ComponentModel.DataAnnotations;
using Havit.Data.EntityFrameworkCore.Attributes;

namespace MensaGymnazium.IntranetGen3.Model;

[Cache]
public class GraduationSubject
{
	public int Id { get; set; }

	[MaxLength(50)]
	public string Name { get; set; }

	public enum Entry
	{
		CzechLanguageLiterature = 1,
		Math = 2,
		Informatics = 4,
		Physics = 8,
		Chemistry = 16,
		Biology = 32,
		ArtHistory = 64,
		History = 128,
		Geography = 256,
		Philosophy = 512,
		Psychology = 1024,
		Sociology = 2048,
		Economy = 4096,
		Law = 8192,
		PoliticalScience = 16384,
		English = 32768,
		ForeignLanguage = 65536,
		HumanWork = 131072,
	}

	public static bool IsEntry(EducationalArea educationalArea, Entry entry)
	{
		return educationalArea.Id == (int)entry;
	}
}