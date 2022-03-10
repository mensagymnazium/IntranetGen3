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
		public int CategoryId { get; set; }
		public int Capacity { get; set; }
		public int SubjectTypeId { get; set; }
		public Primitives.ScheduleSlotInDay ScheduleSlotInDay { get; set; }
	}
}
