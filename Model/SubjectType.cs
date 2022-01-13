using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Havit.Data.EntityFrameworkCore.Attributes;

namespace MensaGymnazium.IntranetGen3.Model
{
	[Cache]
	public class SubjectType
	{
		public SubjectType.Entry Id { get; set; }

		[MaxLength(50)]
		public string Name { get; set; }

		public enum Entry
		{
			NotDefined = 0,
			LanguageCommunication = 1,
			MathApplication = 2,
			Informatics = 4,
			HumanSociety = 8,
			HumanNature = 16,
			ArtCulture = 32,
			HumanHealth = 64,
			HumanWork = 128,
		}
	}
}
