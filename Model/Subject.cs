using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Havit.Diagnostics.Contracts;
using MensaGymnazium.IntranetGen3.Model.Security;
using Havit.Data.EntityFrameworkCore.Attributes;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Model
{
	[Cache]
	public class Subject
	{
		public int Id { get; set; }

		[MaxLength(50)]
		public string Name { get; set; }

		[MaxLength(2000)]
		public string Description { get; set; }

		public int Capacity { get; set; }


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


		public List<SubjectTypeRelation> TypeRelations { get; } = new List<SubjectTypeRelation>();

		[NotMapped]
		public IEnumerable<SubjectType> Types
		{
			get
			{
				Contract.Requires<InvalidOperationException>(TypeRelations.TrueForAll(m => m.SubjectType is not null), $"Unable to access {nameof(Types)} without loading the {nameof(TypeRelations)}.");
				return TypeRelations.Select(m => m.SubjectType);
			}
		}

		public SubjectCategory Category { get; set; }
		public int CategoryId { get; set; }

		public DayOfWeek ScheduleDayOfWeek { get; set; }
		public ScheduleSlotInDay ScheduleSlotInDay { get; set; }
	}
}
