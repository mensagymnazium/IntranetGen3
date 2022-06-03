using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Development
{
	public class Lesson
	{
		public DayOfWeek DayOfWeek { get; set; }
		public string Name { get; set; }
		public string Block { get; set; }
		public Lesson(string name, string block, DayOfWeek dayOfWeeks)
		{
			this.DayOfWeek = dayOfWeeks;
			this.Name = name;
			this.Block = block;
		}
	}
}
