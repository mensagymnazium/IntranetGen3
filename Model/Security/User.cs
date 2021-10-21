using System;
using System.ComponentModel.DataAnnotations;
using Havit.Data.EntityFrameworkCore.Attributes;

namespace MensaGymnazium.IntranetGen3.Model.Security
{
	[Cache]
	public class User
	{
		public int Id { get; set; }

		public Guid? Oid { get; set; }

		[MaxLength(64)] // Same as in AD
		public string Name { get; set; }

		public Student Student { get; set; }

		public int? StudentId { get; set; }

		public Teacher Teacher { get; set; }

		public int? TeacherId { get; set; }

		public DateTime Created { get; set; }

		public DateTime? Deleted { get; set; }
	}
}
