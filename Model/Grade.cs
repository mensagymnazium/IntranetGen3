using System.ComponentModel.DataAnnotations;
using MensaGymnazium.IntranetGen3.Model.Security;
using Havit.Data.EntityFrameworkCore.Attributes;

namespace MensaGymnazium.IntranetGen3.Model;

[Cache]
public class Grade
{
	public int Id { get; set; }

	[Required, MaxLength(20)]
	public string Name { get; set; }

	[MaxLength(36)]
	public string AadGroupId { get; set; }

	public ICollection<Student> Students { get; } = new List<Student>();

	public GradeRegistrationCriteria RegistrationCriteria { get; set; }
	public int? RegistrationCriteriaId { get; set; }
}