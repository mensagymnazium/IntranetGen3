using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Contracts;

public record SubjectReferenceDto
{
	public int Id { get; set; }
	public string Name { get; set; }
	public bool IsDeleted { get; set; }
	public int? CategoryId { get; set; }
	public DayOfWeek? ScheduleDayOfWeek { get; set; }
	public ScheduleSlotInDay? ScheduleSlotInDay { get; set; }
}
