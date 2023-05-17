using System.ComponentModel.DataAnnotations.Schema;

namespace MensaGymnazium.IntranetGen3.Model.Common;

public class ApplicationSettings
{
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int Id { get; set; }

	/// <summary>
	/// <b>Null</b> means that this parameter wont be checked
	/// </summary>
	[Column(TypeName = "datetime")]
	public DateTime? SubjectRegistrationAllowedFrom { get; set; }

	/// <summary>
	/// <b>Null</b> means that this parameter wont be checked
	/// </summary>
	[Column(TypeName = "datetime")]
	public DateTime? SubjectRegistrationAllowedTo { get; set; }

	public enum Entry
	{
		Current = -1
	}
}
