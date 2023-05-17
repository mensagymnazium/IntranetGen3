using Havit.Blazor.Components.Web.Bootstrap;
using Havit.Collections;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Contracts.Security;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Admin;

public partial class TeacherList
{
	[Inject] protected ITeacherFacade TeacherFacade { get; set; }
	[Inject] protected IHxMessengerService Messenger { get; set; }

	private HxGrid<TeacherDto> gridComponent;
	private TeacherEdit editComponent;
	private TeacherDto itemInEdit = new();
	private TeacherDto itemSelected;

	private async Task<GridDataProviderResult<TeacherDto>> GetData(GridDataProviderRequest<TeacherDto> request)
	{
		var data = await TeacherFacade.GetAllAsync();
		return request.ApplyTo(data);
	}

	private async Task HandleSelectedDataItemChanged(TeacherDto selection)
	{
		itemSelected = selection;
		itemInEdit = selection ?? new();
		await editComponent.ShowAsync();
	}

	private async Task HandleNewItemClicked()
	{
		itemInEdit = new();
		await editComponent.ShowAsync();
	}

	private async Task HandleEditClosed()
	{
		itemSelected = null;
		itemInEdit = new();
		await gridComponent.RefreshDataAsync();
	}

	private async Task HandleDeleteItemClicked(TeacherDto item)
	{
		await TeacherFacade.DeleteTeacherAsync(Dto.FromValue(item.Id));
		Messenger.AddInformation("Učitel smazán.");
		await gridComponent.RefreshDataAsync();
	}

}