using Havit.Data.EntityFrameworkCore.Attributes;

namespace MensaGymnazium.IntranetGen3.Model.Security;

[Cache]
public class Student
{
	public int Id { get; set; }

	public User User { get; set; }

	public int GradeId { get; set; }

	public Grade Grade { get; set; }

	public DateTime Created { get; set; }

	public DateTime? Deleted { get; set; }
}
