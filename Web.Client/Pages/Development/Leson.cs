using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Development
{
	public class Lesson
	{
		public DayOfWeek dayOfWeek { get; set; }
		public string name { get; set; }
		public string block { get; set; }
		public Lesson(string Name, string Block, DayOfWeek dayOfWeeks)
		{
			dayOfWeek = dayOfWeeks;
			name = Name;
			block = Block;
		}
	}
}
