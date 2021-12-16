using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensaGymnazium.IntranetGen3.Model
{
	/// <summary>
	/// M:N relation for SigningRyle.SubjectTypes
	/// </summary>
	public class SigningRuleSubjectTypeRelation
	{
		public SigningRule SigningRule { get; set; }
		public int SigningRuleId { get; set; }

		public SubjectType SubjectType { get; set; }
		public int SubjectTypeId { get; set; }
	}
}
