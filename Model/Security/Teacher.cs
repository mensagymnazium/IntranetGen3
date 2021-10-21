using System;

namespace MensaGymnazium.IntranetGen3.Model.Security
{
	public class Teacher
	{
		public int Id { get; set; }

		public User User { get; set; }

		public int? SeededEntityId { get; set; }

		public DateTime Created { get; set; }

		public DateTime? Deleted { get; set; }
	}
}
