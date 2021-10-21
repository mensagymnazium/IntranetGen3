using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Havit.Data.Patterns.DataSeeds;
using MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core.Common;
using MensaGymnazium.IntranetGen3.Model;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core
{
	public class GradeSeed : DataSeed<CoreProfile>
	{
		public override void SeedData()
		{
			var data = new[]
			{
				new Grade() { Symbol = Grade.Entry.Prima.ToString(), Name = "prima" },
				new Grade() { Symbol = Grade.Entry.Sekunda.ToString(), Name = "sekunda" },
				new Grade() { Symbol = Grade.Entry.Tercie.ToString(), Name = "tercie" },
				new Grade() { Symbol = Grade.Entry.Kvarta.ToString(), Name = "kvarta" },
				new Grade() { Symbol = Grade.Entry.Kvinta.ToString(), Name = "kvinta" },
				new Grade() { Symbol = Grade.Entry.Sexta.ToString(), Name = "sexta" },
				new Grade() { Symbol = Grade.Entry.Septima.ToString(), Name = "septima" },
				new Grade() { Symbol = Grade.Entry.Oktava.ToString(), Name = "oktáva" }
			};

			Seed(For(data).PairBy(grade => grade.Name)); // TODO později přepojit na grade.Symbol?
		}
	}
}
