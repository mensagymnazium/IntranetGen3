using MensaGymnazium.IntranetGen3.Model;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core;

public class SubjectTypeSeed : DataSeed<CoreProfile>
{
	public override void SeedData()
	{
		var data = new[]
		{
			new SubjectType() { Name = "Jazyk a jazyková komunikace", Id = (int)SubjectType.Entry.LanguageCommunication },
			new SubjectType() { Name = "Matematika a její aplikace", Id= (int)SubjectType.Entry.MathApplication },
			new SubjectType() { Name = "Informační a komunikační technologie", Id = (int)SubjectType.Entry.Informatics },
			new SubjectType() { Name = "Člověk a společnost", Id = (int)SubjectType.Entry.HumanSociety },
			new SubjectType() { Name = "Člověk a příroda", Id = (int)SubjectType.Entry.HumanNature },
			new SubjectType() { Name = "Umění a kultura", Id = (int)SubjectType.Entry.ArtCulture },
			new SubjectType() { Name = "Člověk a zdraví", Id = (int)SubjectType.Entry.HumanHealth },
			new SubjectType() { Name = "Člověk a svět práce", Id = (int)SubjectType.Entry.HumanWork },
		};

		Seed(For(data).PairBy(st => st.Id));
	}
}
