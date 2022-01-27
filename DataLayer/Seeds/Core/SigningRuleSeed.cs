using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Havit.Data.Patterns.DataSeeds;
using MensaGymnazium.IntranetGen3.Model;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core
{
	public class SigningRuleSeed : DataSeed<CoreProfile>
	{
		public override void SeedData()
		{
			var data = new[]
			{
				new SigningRule() {
					Id = 1,
					Name = "Sekunda - Specializovaný seminář nebo jazyk",
					Description = "Je potřeba si zvolit jeden specialozovaný seminář nebo jazyk",
					GradeId = (int) Grade.Entry.Sekunda,
					Quantity = 1
				},

				new SigningRule() {
					Id = 2,
					Name = "Tercie - Specializovaný seminář",
					Description = "Je potřeba si zvolit jeden specialozovaný seminář",
					GradeId = (int) Grade.Entry.Tercie,
					Quantity = 1
				},

				new SigningRule()
				{
					Id = 3,
					Name = "Tercie - Jazyk",
					Description = "Je potřeba si zvolit jeden jazyk (pokud již nebyl zvolen v Sekundě)",
					GradeId = (int) Grade.Entry.Tercie,
					Quantity = 1
				},

				new SigningRule()
				{
					Id = 4,
					Name = "Kvarta - Specializovaný seminář",
					Description = "Je potřeba si zvolit jeden specialozovaný seminář",
					GradeId = (int) Grade.Entry.Kvarta,
					Quantity = 1
				},

				new SigningRule()
				{
					Id = 5,
					Name = "Kvinta - Nadstavbový seminář",
					Description = "Je potřeba si zvolit jeden Nadstavbový seminář",
					GradeId = (int) Grade.Entry.Kvarta,
					Quantity = 1
				},

				new SigningRule()
				{
					Id = 6,
					Name = "Kvinta - Druhý seminář",
					Description = "Je potřeba si zvolit jeden specialozovaný nebo nadstavbový seminář",
					GradeId = (int) Grade.Entry.Kvarta,
					Quantity = 1
				},
			};

			Seed(For(data).PairBy(st => st.Id));
		}
	}
}
