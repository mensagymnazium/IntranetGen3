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
	public class SubjectCategory
	{
		public int Id { get; set; }

		[MaxLength(50)]
		public string Name { get; set; }

		public enum Entry
		{
			Graduational = 1,
			Seminars = 2,
			SpecialSeminars = 4,
			ForeignLanguage = 8
		}
	}
}
