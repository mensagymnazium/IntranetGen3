using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensaGymnazium.IntranetGen3.Model
{
	public class SigningRules
	{
		public int Id { get; set; }

		public Grade Grade { get; set; }

		public List<SigningRulesCategory> CategoryRelations { get; set; }

		public List<SigningRulesType> TypeRelations { get; set; }
	}
}
