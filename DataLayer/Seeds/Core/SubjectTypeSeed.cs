using MensaGymnazium.IntranetGen3.Model;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core;

public class SubjectTypeSeed : DataSeed<CoreProfile>
{
	public override void SeedData()
	{
		var data = new[]
		{
			new SubjectType() { Name = "Placeholder type", Id = (int)SubjectType.Entry.Informatics },
			/*new SubjectType() { Name = "jazyk a jazyková komunikace", Id = (int)SubjectType.Entry.LanguageCommunication },
			new SubjectType() { Name = "matematika a její aplikace", Id= (int)SubjectType.Entry.MathApplication },
			new SubjectType() { Name = "informační a komunikační technologie", Id = (int)SubjectType.Entry.Informatics },
			new SubjectType() { Name = "člověk a společnost", Id = (int)SubjectType.Entry.HumanSociety },
			new SubjectType() { Name = "člověk a příroda", Id = (int)SubjectType.Entry.HumanNature },
			new SubjectType() { Name = "umění a kultura", Id = (int)SubjectType.Entry.ArtCulture },
			new SubjectType() { Name = "člověk a zdraví", Id = (int)SubjectType.Entry.HumanHealth },
			new SubjectType() { Name = "člověk a svět práce", Id = (int)SubjectType.Entry.HumanWork },*/
		};

		Seed(For(data).PairBy(st => st.Id));
	}
}
