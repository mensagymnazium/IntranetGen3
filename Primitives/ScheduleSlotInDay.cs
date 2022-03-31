using System.ComponentModel;

namespace MensaGymnazium.IntranetGen3.Primitives;

public enum ScheduleSlotInDay
{
	/// <summary>
	/// 8:30 - 10:05
	/// </summary>
	[Description("8:30 - 10:05")]
	Block1 = 1,

	/// <summary>
	/// 10:15 - 11:50
	/// </summary>
	[Description("10:15 - 11:50")]
	Block2 = 2,

	/// <summary>
	/// 12:15 - 13:50
	/// </summary>
	[Description("12:15 - 13:50")]
	Block3 = 3,

	/// <summary>
	/// 14:30 - 16:05
	/// </summary>
	[Description("14:30 - 16:05")]
	Block4 = 4,

	/// <summary>
	/// 16:15 - 17:50
	/// </summary>
	[Description("16:15 - 17:50")]
	Block5 = 5
}
