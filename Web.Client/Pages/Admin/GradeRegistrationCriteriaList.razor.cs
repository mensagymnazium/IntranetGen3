using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Admin;

public partial class GradeRegistrationCriteriaList
{
	[Inject] protected IGradeFacade GradeFacade { get; set; }
	[Inject] protected IGradesDataStore GradesDataStore { get; set; }

	private HxGrid<GradeRegistrationCriteriaDto> gridComponent; // @ref
	private GradeRegistrationCriteriaEdit editComponent; // @ref
	private GradeRegistrationCriteriaDto itemInEdit = new();
	private GradeRegistrationCriteriaDto itemSelected;

	protected override async Task OnInitializedAsync()
	{
		await GradesDataStore.EnsureDataAsync();
	}

	private async Task<GridDataProviderResult<GradeRegistrationCriteriaDto>> GetData(GridDataProviderRequest<GradeRegistrationCriteriaDto> request)
	{
		var data = await GradeFacade.GetGradeRegistrationCriteriasAsync(request.CancellationToken);
		return request.ApplyTo(data);
	}

	private string GetGradeName(int gradeId)
	{
		return GradesDataStore.GetByKeyOrDefault(gradeId)?.Name;
	}
	private async Task HandleSelectedDataItemChanged()
	{
		itemInEdit = itemSelected ?? new();
		await editComponent.ShowAsync();
	}

	private async Task HandleEditClosed()
	{
		itemSelected = null;
		itemInEdit = new();
		await gridComponent.RefreshDataAsync();
	}
}