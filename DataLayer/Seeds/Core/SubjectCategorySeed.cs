using MensaGymnazium.IntranetGen3.Model;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core;

public class SubjectCategorySeed : DataSeed<CoreProfile>
{
	public override void SeedData()
	{
		var data = new[]
		{
			new SubjectCategory() { Id = (int)SubjectCategory.Entry.GraduationSeminar, Name = "Maturitní semináře" },
			new SubjectCategory() { Id = (int)SubjectCategory.Entry.ExtensionSeminar, Name = "Nadstavbový seminář" },
			new SubjectCategory() { Id = (int)SubjectCategory.Entry.SpecialisationSeminar, Name = "Specializační semináře" },
			new SubjectCategory() { Id = (int)SubjectCategory.Entry.ForeignLanguage, Name = "Cizí jazyk" },
		};

		Seed(For(data).PairBy(st => st.Id));
	}
}
