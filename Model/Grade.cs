using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MensaGymnazium.IntranetGen3.Model.Security;

namespace MensaGymnazium.IntranetGen3.Model
{
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
			Prima,
			Sekunda,
			Tercie,
			Kvarta,
			Kvinta,
			Sexta,
			Septima,
			Oktava
		}
	}
}
