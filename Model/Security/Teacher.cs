using System;
using Havit.Data.EntityFrameworkCore.Attributes;

namespace MensaGymnazium.IntranetGen3.Model.Security
{
	[Cache]
	public class Teacher
	{
		public int Id { get; set; }

		public User User { get; set; }

		public DateTime Created { get; set; }

		public DateTime? Deleted { get; set; }
	}
}
