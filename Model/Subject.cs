using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensaGymnazium.IntranetGen3.Model
{
	public class Subject
	{
		public int Id { get; set; }
		[MaxLength(50)]
		public string Name { get; set; }
		[MaxLength(2000)]
		public string Description { get; set; }
		public int Capacity { get; set; }
		// public List<Grade> IntendedGrades { get; set; }
		public SubjectType Type { get; set; }
		public int TypeId { get; set; }
		public SubjectCategory Category { get; set; }
		public int CategoryId { get; set; }
	}
}
