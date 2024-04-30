using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;
using Microsoft.AspNetCore.Components;

namespace MensaGymnazium.IntranetGen3.Web.Client.Components.Pickers;

public class GraduationSubjectPicker : HxSelectBase<int?, GraduationSubjectDto>
{
	[Parameter] public string NullText { get => NullTextImpl; set => NullTextImpl = value; }

	[Inject] protected IGraduationSubjectsDataStore GraduationSubjectsDataStore { get; set; }

	public GraduationSubjectPicker()
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

		this.DataImpl = (await GraduationSubjectsDataStore.GetAllAsync()).ToList();
	}
}