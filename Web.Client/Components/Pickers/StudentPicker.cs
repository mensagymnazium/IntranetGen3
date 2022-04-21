using MensaGymnazium.IntranetGen3.Contracts.Security;
using MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;
using Microsoft.AspNetCore.Components;

namespace MensaGymnazium.IntranetGen3.Web.Client.Components.Pickers;

public class StudentPicker : HxSelectBase<int?, StudentReferenceDto>
{
	[Parameter] public string NullText { get => NullTextImpl; set => NullTextImpl = value; }

	[Inject] protected IStudentsDataStore StudentsDataStore { get; set; }

	public StudentPicker()
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

		this.DataImpl = (await StudentsDataStore.GetAllAsync()).Where(t => !t.IsDeleted).ToList();
	}
}
