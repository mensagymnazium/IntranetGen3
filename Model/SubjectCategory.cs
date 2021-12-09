using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Havit.Data.EntityFrameworkCore.Attributes;

namespace MensaGymnazium.IntranetGen3.Model
{
	[Cache]
	public class SubjectCategory
	{
		public int Id { get; set; }

		[MaxLength(20)]
		public string Name { get; set; }

		public List<SigningRulesCategory> SigningRulesRelations { get; set; }
	}
}
