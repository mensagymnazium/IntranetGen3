using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

namespace MensaGymnazium.IntranetGen3.Web.Client.Components.Pickers;

public class GradePicker : HxSelectBase<int?, GradeDto>
{
	[Inject] protected IGradesDataStore GradesDataStore { get; set; }

	public GradePicker()
	{
		this.NullTextImpl = "-vyberte-";
		this.ValueSelectorImpl = (c => c.Id);
		this.TextSelectorImpl = (c => c.Name);
		this.SortKeySelectorImpl = (c => -c.Id);
	}

	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();

		this.DataImpl = (await GradesDataStore.GetAllAsync()).ToList();
	}
}
