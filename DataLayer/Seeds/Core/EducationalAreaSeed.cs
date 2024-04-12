using MensaGymnazium.IntranetGen3.Model;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core;

public class EducationalAreaSeed : DataSeed<CoreProfile>
{
	public override void SeedData()
	{
		var data = new[]
		{
			new EducationalArea() { Name = "jazyk a jazyková komunikace", Id = (int)EducationalArea.Entry.LanguageCommunication },
			new EducationalArea() { Name = "matematika a její aplikace", Id= (int)EducationalArea.Entry.MathApplication },
			new EducationalArea() { Name = "informační a komunikační technologie", Id = (int)EducationalArea.Entry.Informatics },
			new EducationalArea() { Name = "člověk a společnost", Id = (int)EducationalArea.Entry.HumanSociety },
			new EducationalArea() { Name = "člověk a příroda", Id = (int)EducationalArea.Entry.HumanNature },
			new EducationalArea() { Name = "umění a kultura", Id = (int)EducationalArea.Entry.ArtCulture },
			new EducationalArea() { Name = "člověk a zdraví", Id = (int)EducationalArea.Entry.HumanHealth },
			new EducationalArea() { Name = "člověk a svět práce", Id = (int)EducationalArea.Entry.HumanWork },
		};

		Seed(For(data).PairBy(st => st.Id));
	}
}
