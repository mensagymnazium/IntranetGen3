using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Havit.Data.Patterns.DataSeeds;
using MensaGymnazium.IntranetGen3.Model;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core
{
	public class SubjectCategorySeed : DataSeed<CoreProfile>
	{
		public override void SeedData()
		{
			var data = new[]
			{
				new SubjectCategory() { Id = SubjectCategory.Entry.NotDefined, Name = "Neurčeno" },
				new SubjectCategory() { Id = SubjectCategory.Entry.Graduational, Name = "Maturitní semináře" },
				new SubjectCategory() { Id = SubjectCategory.Entry.Seminars, Name = "Nadstavbový seminář" },
				new SubjectCategory() { Id = SubjectCategory.Entry.SpecialSeminars, Name = "Specializační semináře" },
				new SubjectCategory() { Id = SubjectCategory.Entry.ForeignLanguage, Name = "Cizí jazyk" },
			};

			Seed(For(data).PairBy(st => st.Id));
		}
	}
}
