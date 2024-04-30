using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Contracts.Security;
using MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;
using Microsoft.AspNetCore.Components;

namespace MensaGymnazium.IntranetGen3.Web.Client.Components.Pickers;

public class GraduationSubjectMultiPicker : HxMultiSelect<int, GraduationSubjectDto>
{
	[Inject] protected IGraduationSubjectsDataStore GraduationSubjectsDataStore { get; set; }

	public GraduationSubjectMultiPicker()
	{
		this.EmptyText = "-vyberte-";
		this.ValueSelector = (c => c.Id);
		this.TextSelector = (c => c.Name);
	}

	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();

		this.Data = (await GraduationSubjectsDataStore.GetAllAsync()).ToList();
	}
}