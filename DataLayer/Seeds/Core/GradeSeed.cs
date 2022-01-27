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
				new Grade() { Id = (int) Grade.Entry.Prima,  Symbol = Grade.Entry.Prima.ToString(), Name = "prima" },
				new Grade() { Id = (int) Grade.Entry.Sekunda,  Symbol = Grade.Entry.Sekunda.ToString(), Name = "sekunda" },
				new Grade() { Id = (int) Grade.Entry.Tercie,  Symbol = Grade.Entry.Tercie.ToString(), Name = "tercie" },
				new Grade() { Id = (int) Grade.Entry.Kvarta,  Symbol = Grade.Entry.Kvarta.ToString(), Name = "kvarta" },
				new Grade() { Id = (int) Grade.Entry.Kvinta,  Symbol = Grade.Entry.Kvinta.ToString(), Name = "kvinta" },
				new Grade() { Id = (int) Grade.Entry.Sexta,  Symbol = Grade.Entry.Sexta.ToString(), Name = "sexta" },
				new Grade() { Id = (int) Grade.Entry.Septima,  Symbol = Grade.Entry.Septima.ToString(), Name = "septima" },
				new Grade() { Id = (int) Grade.Entry.Oktava,  Symbol = Grade.Entry.Oktava.ToString(), Name = "oktáva" }
			};

			Seed(For(data).PairBy(grade => grade.Name)); // TODO později přepojit na grade.Symbol?
		}
	}
}
