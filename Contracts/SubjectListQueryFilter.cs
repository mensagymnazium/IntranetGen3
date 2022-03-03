using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensaGymnazium.IntranetGen3.Contracts
{
	public class SubjectListQueryFilter
	{
		public string Name { get; set; }
		public int? SubjectTypeId { get; set; }
	}
}
