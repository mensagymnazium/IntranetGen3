using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;
using Microsoft.AspNetCore.Components;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Electives;

public partial class SubjectDetail
{
	[Parameter] public int? SubjectId { get; set; }

	[Inject] protected ISubjectFacade SubjectFacade { get; set; }
	[Inject] protected ISubjectCategoriesDataStore SubjectCategoriesDataStore { get; set; }
	[Inject] protected ISubjectTypesDataStore SubjectTypesDataStore { get; set; }
	[Inject] protected ITeachersDataStore TeachersDataStore { get; set; }
	[Inject] protected IGradesDataStore GradesDataStore { get; set; }

	private SubjectDto subject;
	private SubjectEdit subjectEditComponent;
	private int? loadedSubjectId;

	protected override async Task OnInitializedAsync()
	{
		await SubjectCategoriesDataStore.EnsureDataAsync();
		await SubjectTypesDataStore.EnsureDataAsync();
		await TeachersDataStore.EnsureDataAsync();
		await GradesDataStore.EnsureDataAsync();
	}

	protected override async Task OnParametersSetAsync()
	{
		if (SubjectId != loadedSubjectId)
		{
			if (SubjectId.HasValue)
			{
				loadedSubjectId = SubjectId;
				await LoadSubjectAsync();
			}
			else
			{
				loadedSubjectId = null;
			}
		}
	}

	private async Task LoadSubjectAsync()
	{
		subject = await SubjectFacade.GetSubjectDetailAsync(Dto.FromValue(SubjectId.Value));
	}

	private async Task HandleEditClick()
	{
		await subjectEditComponent.ShowAsync();
	}

	private async Task HandleEditSaved(int subjectId)
	{
		await LoadSubjectAsync();
	}

	private string GetSubjectTypes(List<int> subjectTypesIds)
	{
		return String.Join(", ", subjectTypesIds.Select(id => SubjectTypesDataStore.GetByKey(id)?.Name))
			.Trim(',', ' ');
	}

	private string GetTeachers(List<int> teacherIds)
	{
		return String.Join(", ", teacherIds.Select(id => TeachersDataStore.GetByKey(id)?.Name))
			.Trim(',', ' ');
	}

	private string GetGrades(List<int> gradeIds)
	{
		return String.Join(", ", gradeIds.OrderBy(id => -id).Select(id => GradesDataStore.GetByKey(id)?.Name))
			.Trim(',', ' ');
	}
}
