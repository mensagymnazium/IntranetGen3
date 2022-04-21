using MensaGymnazium.IntranetGen3.Contracts.Security;
using MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;
using Microsoft.AspNetCore.Components;

namespace MensaGymnazium.IntranetGen3.Web.Client.Components.Pickers;

public class TeacherMultiPicker : HxMultiSelect<int, TeacherReferenceDto>
{
	[Inject] protected ITeachersDataStore TeachersDataStore { get; set; }

	public TeacherMultiPicker()
	{
		this.EmptyText = "-vyberte-";
		this.ValueSelector = (c => c.TeacherId);
		this.TextSelector = (c => c.Name);
	}

	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();

		this.Data = (await TeachersDataStore.GetAllAsync()).Where(t => !t.IsDeleted).ToList();
	}
}
