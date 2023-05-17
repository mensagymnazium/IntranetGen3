using MensaGymnazium.IntranetGen3.Contracts.Infrastructure;
using Microsoft.AspNetCore.Components;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Admin.Components;

public partial class DataSeeds : ComponentBase
{
	[Inject] protected IDataSeedFacade DataSeedFacade { get; set; }
	[Inject] protected IHxMessengerService Messenger { get; set; }
	[Inject] protected IHxMessageBoxService MessageBox { get; set; }

	private IEnumerable<string> seedProfiles;
	private string selectedSeedProfile;
	private HxOffcanvas offcanvasComponent;

	private async Task HandleSeedClick()
	{
		if (selectedSeedProfile is not null && await MessageBox.ConfirmAsync($"Do you really want to seed {selectedSeedProfile}?"))
		{
			await DataSeedFacade.SeedDataProfile(selectedSeedProfile);
			Messenger.AddInformation($"Seed successful: {selectedSeedProfile}");

			await offcanvasComponent.HideAsync();
		}
	}

	public async Task ShowAsync()
	{
		seedProfiles ??= await DataSeedFacade.GetDataSeedProfiles();

		await offcanvasComponent.ShowAsync();
	}
}
