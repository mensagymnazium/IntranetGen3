using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Contracts
{
	public record SubjectDto : SubjectListItemDto
	{
		public string Description { get; set; }
	}
}
