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
				new Grade() { Name = "prima" },
				new Grade() { Name = "sekunda" },
				new Grade() { Name = "tercie" },
				new Grade() { Name = "kvarta" },
				new Grade() { Name = "kvinta" },
				new Grade() { Name = "sexta" },
				new Grade() { Name = "septima" },
				new Grade() { Name = "oktáva" }
			};

			Seed(For(data).PairBy(grade => grade.Name));
		}
	}
}
