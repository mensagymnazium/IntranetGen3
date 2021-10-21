using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Havit.Diagnostics.Contracts;
using MensaGymnazium.IntranetGen3.Model.Security;
using Havit.Data.EntityFrameworkCore.Attributes;

namespace MensaGymnazium.IntranetGen3.Model
{
	[Cache]
	public class Subject
	{
		public int Id { get; set; }
		[MaxLength(50)]
		public string Name { get; set; }
		[MaxLength(2000)]
		public string Description { get; set; }
		public int Capacity { get; set; }
		// public List<Grade> IntendedGrades { get; set; }

		public List<SubjectTypeRelation> TypeRelations { get; } = new List<SubjectTypeRelation>();
		[NotMapped]
		public IEnumerable<SubjectType> Types
		{
			get
			{
				Contract.Requires<InvalidOperationException>(TypeRelations.TrueForAll(m => m.SubjectType is not null), $"Unable to access {nameof(Types)} without loading the {nameof(TypeRelations)}.");
				return TypeRelations.Select(m => m.SubjectType);
			}
		}

		public int TypeId { get; set; }
		public SubjectCategory Category { get; set; }
		public int CategoryId { get; set; }
	}
}
