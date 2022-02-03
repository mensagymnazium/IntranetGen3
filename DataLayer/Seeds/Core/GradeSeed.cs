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
				new Grade() { Id = (int) Grade.Entry.Prima, Name = "prima" },
				new Grade() { Id = (int) Grade.Entry.Sekunda, Name = "sekunda" },
				new Grade() { Id = (int) Grade.Entry.Tercie, Name = "tercie" },
				new Grade() { Id = (int) Grade.Entry.Kvarta, Name = "kvarta" },
				new Grade() { Id = (int) Grade.Entry.Kvinta, Name = "kvinta" },
				new Grade() { Id = (int) Grade.Entry.Sexta, Name = "sexta" },
				new Grade() { Id = (int) Grade.Entry.Septima, Name = "septima" },
				new Grade() { Id = (int) Grade.Entry.Oktava, Name = "oktáva" }
			};

			Seed(For(data).PairBy(grade => grade.Id));
		}
	}
}
