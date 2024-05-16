using MensaGymnazium.IntranetGen3.Model;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core;

public class SubjectCategorySeed : DataSeed<CoreProfile>
{
	public override void SeedData()
	{
		var data = new[]
		{
			new SubjectCategory() { Id = (int)SubjectCategoryEntry.GraduationSeminar, Name = "maturitní seminář" },
			new SubjectCategory() { Id = (int)SubjectCategoryEntry.ExtensionSeminar, Name = "nadstavbový seminář" },
			new SubjectCategory() { Id = (int)SubjectCategoryEntry.SpecialisationSeminar, Name = "specializační seminář" },
			new SubjectCategory() { Id = (int)SubjectCategoryEntry.ForeignLanguage, Name = "cizí jazyk" },
		};

		Seed(For(data).PairBy(st => st.Id));
	}
}
