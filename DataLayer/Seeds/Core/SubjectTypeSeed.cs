using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Havit.Data.Patterns.DataSeeds;
using MensaGymnazium.IntranetGen3.Model;
using Microsoft.VisualBasic;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core
{
	public class SubjectTypeSeed : DataSeed<CoreProfile>
	{
		public override void SeedData()
		{
			var data = new[]
			{
				new SubjectType() { Name = "Neurčeno", Id = SubjectType.Entry.NotDefined },
				new SubjectType() { Name = "Jazyk a jazyková komunikace", Id = SubjectType.Entry.LanguageCommunication },
				new SubjectType() { Name = "Matematika a její aplikace", Id= SubjectType.Entry.MathApplication },
				new SubjectType() { Name = "Informační a komunikační technologie", Id = SubjectType.Entry.Informatics },
				new SubjectType() { Name = "Člověk a společnost", Id = SubjectType.Entry.HumanSociety },
				new SubjectType() { Name = "Člověk a příroda", Id = SubjectType.Entry.HumanNature },
				new SubjectType() { Name = "Umění a kultura", Id = SubjectType.Entry.ArtCulture },
				new SubjectType() { Name = "Člověk a zdraví", Id = SubjectType.Entry.HumanHealth },
				new SubjectType() { Name = "Člověk a svět práce", Id = SubjectType.Entry.HumanWork },
			};

			Seed(For(data).PairBy(st => st.Id));
		}
	}
}
