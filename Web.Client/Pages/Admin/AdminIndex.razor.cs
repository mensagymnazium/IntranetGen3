using MensaGymnazium.IntranetGen3.Contracts.Infrastructure;
using MensaGymnazium.IntranetGen3.Web.Client.Pages.Admin.Components;
using Microsoft.AspNetCore.Components;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Admin;

public partial class AdminIndex : ComponentBase
{
	[Inject] protected IMaintenanceFacade MaintenanceFacade { get; set; }
	[Inject] protected IHxMessengerService Messenger { get; set; }
	[Inject] protected IHxMessageBoxService MessageBox { get; set; }

	private DataSeeds dataSeedsComponent;

	private async Task HandleClearCacheClick()
	{
		if (await MessageBox.ConfirmAsync("Opravdu chcete smazat cache serverové části aplikace?"))
		{
			await MaintenanceFacade.ClearCacheAsync();
			Messenger.AddInformation("Serverová cache vyčištěna.");
		}
	}

	private void SimulateException()
	{
		throw new InvalidOperationException("Simulated exception");
	}
}
