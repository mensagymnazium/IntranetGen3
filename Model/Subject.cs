using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MensaGymnazium.IntranetGen3.Model.Security;
using Havit.Data.EntityFrameworkCore.Attributes;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Model;

[Cache]
public class Subject
{
	public int Id { get; set; }

	[MaxLength(100)]
	public string Name { get; set; }

	[MaxLength]
	public string Description { get; set; }

	public int? Capacity { get; set; }


	public List<SubjectTeacherRelation> TeacherRelations { get; } = new List<SubjectTeacherRelation>();

	[NotMapped]
	public IEnumerable<Teacher> Teachers
	{
		get
		{
			Contract.Requires<InvalidOperationException>(TeacherRelations.TrueForAll(r => r.Teacher is not null), $"Unable to access {nameof(Teachers)} without loading the {nameof(TeacherRelations)}.");
			return TeacherRelations.Select(m => m.Teacher);
		}
	}


	public List<SubjectGradeRelation> GradeRelations { get; } = new List<SubjectGradeRelation>();

	[NotMapped]
	public IEnumerable<Grade> Grades
	{
		get
		{
			Contract.Requires<InvalidOperationException>(GradeRelations.TrueForAll(r => r.Grade is not null), $"Unable to access {nameof(Grades)} without loading the {nameof(GradeRelations)}.");
			return GradeRelations.Select(m => m.Grade);
		}
	}


	public List<EducationalAreaRelation> EducationalAreaRelations { get; } = new List<EducationalAreaRelation>();

	[NotMapped]
	public IEnumerable<EducationalArea> EducationalAreas
	{
		get
		{
			Contract.Requires<InvalidOperationException>(EducationalAreaRelations.TrueForAll(m => m.EducationalArea is not null), $"Unable to access {nameof(EducationalAreas)} without loading the {nameof(EducationalAreaRelations)}.");
			return EducationalAreaRelations.Select(m => m.EducationalArea);
		}
	}

	public List<GraduationSubjectRelation> GraduationSubjectRelations { get; } = new List<GraduationSubjectRelation>();

	[NotMapped]
	public IEnumerable<GraduationSubject> GraduationSubjects
	{
		get
		{
			Contract.Requires<InvalidOperationException>(EducationalAreaRelations.TrueForAll(m => m.EducationalArea is not null), $"Unable to access {nameof(EducationalAreas)} without loading the {nameof(EducationalAreaRelations)}.");
			return GraduationSubjectRelations.Select(m => m.GraduationSubject);
		}
	}

	public SubjectCategory Category { get; set; }
	public int CategoryId { get; set; }

	public DayOfWeek ScheduleDayOfWeek { get; set; }
	public ScheduleSlotInDay ScheduleSlotInDay { get; set; }

	[MaxLength(50)]
	public string SeedIdentifier { get; set; }

	public bool CanRegisterRepeatedly { get; set; }

	public int HoursPerWeek { get; set; } = 2;

	public int MinStudentsToOpen { get; set; } = 5;

	public DateTime Created { get; set; } = DateTime.Now;
	public DateTime? Deleted { get; set; }
}
