using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensaGymnazium.IntranetGen3.Contracts
{
	public class SigningRuleDto
	{
		public int SigningRuleId { get; set; }

		public string Name { get; set; }

		public int Quantity { get; set; }

		public List<int> SubjectTypesId { get; set; }

		public List<int> SubjectCategoriesId { get; set; }

		public int GradeId { get; set; }

	}
}
