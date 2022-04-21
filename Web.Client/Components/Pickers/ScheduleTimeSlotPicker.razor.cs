using Microsoft.AspNetCore.Components;
using MensaGymnazium.IntranetGen3.Primitives;
using System.Linq.Expressions;

namespace MensaGymnazium.IntranetGen3.Web.Client.Components.Pickers;

public partial class ScheduleTimeSlotPicker
{
	[Parameter] public DayOfWeek? Day { get; set; }
	[Parameter] public EventCallback<DayOfWeek?> DayChanged { get; set; }
	[Parameter] public Expression<Func<DayOfWeek?>> DayExpression { get; set; }


	[Parameter] public ScheduleSlotInDay? Slot { get; set; }
	[Parameter] public EventCallback<ScheduleSlotInDay?> SlotChanged { get; set; }
	[Parameter] public Expression<Func<ScheduleSlotInDay?>> SlotExpression { get; set; }
}
