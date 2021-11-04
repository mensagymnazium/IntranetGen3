using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensaGymnazium.IntranetGen3.Primitives
{
	[Flags]
	public enum ScheduleSlotInDay
	{
		/// <summary>
		/// 8:30 - 9:16
		/// </summary>
		[Description("8:30 - 9:16")]
		Hour1 = 0b_0000_0000_0000_0001,

		/// <summary>
		/// 09:20 - 10:05
		/// </summary>
		[Description("09:20 - 10:05")]
		Hour2 = 0b_0000_0000_0000_0010,

		/// <summary>
		/// 10:15 - 11:00
		/// </summary>
		[Description("10:15 - 11:00")]
		Hour3 = 0b_0000_0000_0000_0100,

		/// <summary>
		/// 11:05 - 11:50
		/// </summary>
		[Description("11:05 - 11:50")]
		Hour4 = 0b_0000_0000_0000_1000,

		/// <summary>
		/// 12:15 - 13:00
		/// </summary>
		[Description("12:15 - 13:00")]
		Hour5 = 0b_0000_0000_0001_0000,

		/// <summary>
		/// 13:05 - 13:50
		/// </summary>
		[Description("13:05 - 13:50")]
		Hour6 = 0b_0000_0000_0010_0000,

		/// <summary>
		/// 14:30 - 15:15
		/// </summary>
		[Description("14:30 - 15:15")]
		Hour7 = 0b_0000_0000_0100_0000,

		/// <summary>
		/// 15:20 - 16:05
		/// </summary>
		[Description("15:20 - 16:05")]
		Hour8 = 0b_0000_0000_1000_0000,

		/// <summary>
		/// 16:15 - 17:00
		/// </summary>
		[Description("16:15 - 17:00")]
		Hour9 = 0b_0000_0001_0000_0000,

		/// <summary>
		/// 17:05 - 17:50
		/// </summary>
		[Description("17:05 - 17:50")]
		Hour10 = 0b_0000_0010_0000_0000,

		/// <summary>
		/// 8:30 - 10:05
		/// </summary>
		[Description("8:30 - 10:05")]
		Block1 = Hour1 | Hour2,

		/// <summary>
		/// 10:15 - 11:50
		/// </summary>
		[Description("10:15 - 11:50")]
		Block2 = Hour3 | Hour4,

		/// <summary>
		/// 12:15 - 13:50
		/// </summary>
		[Description("12:15 - 13:50")]
		Block3 = Hour5 | Hour6,

		/// <summary>
		/// 14:30 - 16:05
		/// </summary>
		[Description("14:30 - 16:05")]
		Block4 = Hour7 | Hour8,

		/// <summary>
		/// 16:15 - 17:50
		/// </summary>
		[Description("16:15 - 17:50")]
		Block5 = Hour9 | Hour10
	}
}
