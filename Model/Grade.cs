using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MensaGymnazium.IntranetGen3.Model.Security;
using Havit.Data.EntityFrameworkCore.Attributes;

namespace MensaGymnazium.IntranetGen3.Model
{
	[Cache]
	public class Grade
	{
		public int Id { get; set; }

		[MaxLength(20)]
		public string Name { get; set; }

		/// <summary>
		/// Mapping to Grade.Entry
		/// </summary>
		[MaxLength(20)]
		public string Symbol { get; set; }

		public ICollection<Student> Students { get; } = new List<Student>();

		public enum Entry
		{
			Prima = -1,
			Sekunda = -2,
			Tercie = -3,
			Kvarta = -4,
			Kvinta = -5,
			Sexta = -6,
			Septima = -7,
			Oktava = -8
		}
	}
}
