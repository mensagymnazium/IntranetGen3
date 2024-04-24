using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Contracts;

public record SubjectListItemDto : SubjectReferenceDto
{
	public int? CategoryId { get; set; }
	public int? Capacity { get; set; }
	public DayOfWeek? ScheduleDayOfWeek { get; set; }
	public ScheduleSlotInDay? ScheduleSlotInDay { get; set; }
	public int HoursPerWeek { get; set; } = 2;
	public int MinStudentsToOpen { get; set; } = 5;
	public List<int> EducationalAreaIds { get; set; } = new List<int>();
	public List<int> GradeIds { get; set; } = new List<int>();
	public List<int> TeacherIds { get; set; } = new List<int>();
	public int StudentRegistrationsCountMain { get; set; }
	public int StudentRegistrationsCountSecondary { get; set; }
}
