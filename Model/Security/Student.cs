using System.ComponentModel.DataAnnotations.Schema;
using Havit.Data.EntityFrameworkCore.Attributes;
using Havit.Model.Collections.Generic;

namespace MensaGymnazium.IntranetGen3.Model.Security;

[Cache]
public class Student
{
	public int Id { get; set; }

	public User User { get; set; }

	public Grade Grade { get; set; }
	public int GradeId { get; set; }

	public int? SeedEntityId { get; set; }

	public List<StudentSubjectRegistration> SubjectRegistrationsIncludingDeleted { get; } = new();

	[NotMapped]
	public FilteringCollection<StudentSubjectRegistration> SubjectRegistrations { get; }

	public DateTime Created { get; set; }

	public DateTime? Deleted { get; set; }

	public Student()
	{
		SubjectRegistrations = new FilteringCollection<StudentSubjectRegistration>(this.SubjectRegistrationsIncludingDeleted, h => h.Deleted is null);
	}
}
