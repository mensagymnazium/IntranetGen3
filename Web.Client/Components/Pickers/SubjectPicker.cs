using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

namespace MensaGymnazium.IntranetGen3.Web.Client.Components.Pickers;

public class SubjectPicker : HxSelectBase<int?, SubjectReferenceDto>
{
	[Parameter] public string NullText { get => NullTextImpl; set => NullTextImpl = value; }

	[Inject] protected ISubjectsDataStore SubjectsDataStore { get; set; }

	public SubjectPicker()
	{
		this.NullableImpl = true;
		this.NullDataTextImpl = "načítám";
		this.NullTextImpl = "-vyberte-";
		this.ValueSelectorImpl = (c => c.Id);
		this.TextSelectorImpl = (c => c.Name);
	}

	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();

		this.DataImpl = (await SubjectsDataStore.GetAllAsync()).Where(t => !t.IsDeleted).ToList();
	}
}
