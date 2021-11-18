using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensaGymnazium.IntranetGen3.Contracts
{
	public record SubjectListItemDto
	{
		public int SubjectId { get; set; }
		public string Name { get; set; }
	}
}
