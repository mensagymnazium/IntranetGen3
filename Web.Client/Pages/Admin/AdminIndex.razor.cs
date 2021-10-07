using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Havit.Blazor.Components.Web;
using Havit.Blazor.Components.Web.Bootstrap;
using MensaGymnazium.IntranetGen3.Contracts.System;
using MensaGymnazium.IntranetGen3.Web.Client.Pages.Admin.Components;
using Microsoft.AspNetCore.Components;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Admin
{
	public partial class AdminIndex : ComponentBase
	{
		[Inject] protected IMaintenanceFacade MaintenanceFacade { get; set; }
		[Inject] protected IHxMessengerService Messenger { get; set; }
		[Inject] protected IHxMessageBoxService MessageBox { get; set; }

		private DataSeeds dataSeedsComponent;

		private async Task HandleClearCache()
		{
			if (await MessageBox.ConfirmAsync("Opravdu chcete smazat cache serverové části aplikace?"))
			{
				await MaintenanceFacade.ClearCache();
				Messenger.AddInformation("Serverová cache vyčištěna.");
			}
		}
	}
}
