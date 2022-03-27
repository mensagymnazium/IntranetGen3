using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Blazored.FluentValidation;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Web.Client;
using MensaGymnazium.IntranetGen3.Web.Client.Components;
using MensaGymnazium.IntranetGen3.Web.Client.Components.Pickers;
using MensaGymnazium.IntranetGen3.Web.Client.Shared;
using MensaGymnazium.IntranetGen3.Primitives;
using Havit.Blazor.Components.Web;
using Havit.Blazor.Components.Web.Bootstrap;
using System.Globalization;
using System.ComponentModel;
using System.Linq.Expressions;

namespace MensaGymnazium.IntranetGen3.Web.Client.Components.Pickers
{
	public partial class ScheduleTimeSlotPicker
	{
		[Parameter] public DayOfWeek? Day { get; set; }
		[Parameter] public EventCallback<DayOfWeek?> DayChanged { get; set; }
		[Parameter] public Expression<Func<DayOfWeek?>> DayExpression { get; set; }


		[Parameter] public ScheduleSlotInDay? Slot { get; set; }
		[Parameter] public EventCallback<ScheduleSlotInDay?> SlotChanged { get; set; }
		[Parameter] public Expression<Func<ScheduleSlotInDay?>> SlotExpression { get; set; }
	}
}