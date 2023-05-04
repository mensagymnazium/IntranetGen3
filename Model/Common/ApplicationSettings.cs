using System.ComponentModel.DataAnnotations.Schema;

namespace MensaGymnazium.IntranetGen3.Model.Common;

public class ApplicationSettings
{
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int Id { get; set; }

	public DateTime? CanRegisterSubjectFrom { get; set; }
	public DateTime? CanRegisterSubjectTo { get; set; }

	public enum Entry
	{
		Current = -1
	}
}
