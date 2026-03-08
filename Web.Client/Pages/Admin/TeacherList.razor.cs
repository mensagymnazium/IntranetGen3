using MensaGymnazium.IntranetGen3.Contracts.Security;
using MensaGymnazium.IntranetGen3.Web.Client.Pages.Admin.Components;
using MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;
using Microsoft.AspNetCore.Components;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Admin;

public partial class TeacherList : ComponentBase
{
	[Inject] protected ITeachersDataStore TeachersDataStore { get; set; }

	private HxGrid<TeacherReferenceDto> teachersGrid;
	private TeacherEdit teacherEditComponent;

	protected override async Task OnInitializedAsync()
	{
		await TeachersDataStore.EnsureDataAsync();
	}

	private async Task<GridDataProviderResult<TeacherReferenceDto>> LoadTeachers(GridDataProviderRequest<TeacherReferenceDto> request)
	{
		var teachers = await TeachersDataStore.GetAllAsync();
		return request.ApplyTo(teachers);
	}

	private async Task HandleEditItemClicked(TeacherReferenceDto teacher)
	{
		await teacherEditComponent.ShowAsync(teacher.TeacherId);
	}

	private async Task HandleTeacherEditSaved()
	{
		TeachersDataStore.Clear();
		await teachersGrid.RefreshDataAsync();
	}
}
