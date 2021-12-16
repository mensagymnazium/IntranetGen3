using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensaGymnazium.IntranetGen3.Model
{
	/// <summary>
	/// M:N relation for SigningRule.SubjectCategories
	/// </summary>
	public class SigningRuleSubjectCategoryRelation
	{
		public SigningRule SigningRule { get; set; }
		public int SigningRuleId { get; set; }

		public SubjectCategory SubjectCategory { get; set; }
		public int SubjectCategoryId { get; set; }
	}
}
