using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Havit.Blazor.Components.Web.Bootstrap;
using Microsoft.AspNetCore.Components;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Electives
{
	public partial class SubjectEdit
	{
		[Parameter] public string SubjectId { get; set; }

		private HxOffcanvas offcanvasComponent;

		public async Task ShowAsync()
		{
			await offcanvasComponent.ShowAsync();
		}
	}
}
