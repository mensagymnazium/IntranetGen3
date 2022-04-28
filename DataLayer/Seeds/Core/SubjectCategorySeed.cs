using MensaGymnazium.IntranetGen3.Model;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core;

public class SubjectCategorySeed : DataSeed<CoreProfile>
{
	public override void SeedData()
	{
		var data = new[]
		{
			new SubjectCategory() { Id = (int)SubjectCategory.Entry.GraduationSeminar, Name = "přednáška" },
			/*new SubjectCategory() { Id = (int)SubjectCategory.Entry.GraduationSeminar, Name = "maturitní seminář" },
			new SubjectCategory() { Id = (int)SubjectCategory.Entry.ExtensionSeminar, Name = "nadstavbový seminář" },
			new SubjectCategory() { Id = (int)SubjectCategory.Entry.SpecialisationSeminar, Name = "specializační seminář" },
			new SubjectCategory() { Id = (int)SubjectCategory.Entry.ForeignLanguage, Name = "cizí jazyk" },*/
		};

		Seed(For(data).PairBy(st => st.Id));
	}
}
