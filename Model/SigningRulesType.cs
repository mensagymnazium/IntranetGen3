using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensaGymnazium.IntranetGen3.Model
{
	public class SigningRulesType
	{
		public SubjectType SubjectType { get; set; }

		public SigningRules SigningRules { get; set; }

		public int? Quantity { get; set; }
	}
}
