using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

namespace MensaGymnazium.IntranetGen3.Web.Client.Components.Pickers;

public class GradeMultiPicker : HxMultiSelect<int, GradeDto>
{
	[Inject] protected IGradesDataStore GradesDataStore { get; set; }

	public GradeMultiPicker()
	{
		this.EmptyText = "-vyberte-";
		this.ValueSelector = (c => c.Id);
		this.TextSelector = (c => c.Name);
		this.SortKeySelector = (c => -c.Id);
	}

	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();

		this.Data = (await GradesDataStore.GetAllAsync()).ToList();
	}
}
