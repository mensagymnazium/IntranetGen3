using Havit.Collections;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Electives;

public partial class SubjectDetail
{
	[Parameter] public int? SubjectId { get; set; }

	[Inject] protected Func<ISubjectFacade> SubjectFacade { get; set; }
	[Inject] protected Func<IStudentSubjectRegistrationFacade> StudentSubjectRegistrationFacade { get; set; }
	[Inject] protected ISubjectCategoriesDataStore SubjectCategoriesDataStore { get; set; }
	[Inject] protected ISubjectTypesDataStore SubjectTypesDataStore { get; set; }
	[Inject] protected ITeachersDataStore TeachersDataStore { get; set; }
	[Inject] protected IGradesDataStore GradesDataStore { get; set; }

	private SubjectDto subject;
	private SubjectEdit subjectEditComponent;
	private int? loadedSubjectId;
	private StudentSubjectRegistrationsGrid registrationsGrid;

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

	private async Task<GridDataProviderResult<StudentSubjectRegistrationDto>> GetStudentRegistrations(GridDataProviderRequest<StudentSubjectRegistrationDto> request)
	{
		var response = await StudentSubjectRegistrationFacade().GetStudentSubjectRegistrationListAsync(
			new DataFragmentRequest<StudentSubjectRegistrationListQueryFilter>()
			{
				Filter = new StudentSubjectRegistrationListQueryFilter() { SubjectId = SubjectId },
				Count = request.Count,
				StartIndex = request.StartIndex,
				Sorting = request.Sorting.Select(s => new SortItem(s.SortString, s.SortDirection)).ToArray()
			});

		return new()
		{
			Data = response.Data,
			TotalCount = response.TotalCount,
		};
	}

	private async Task LoadSubjectAsync()
	{
		subject = await SubjectFacade().GetSubjectDetailAsync(Dto.FromValue(SubjectId.Value));
	}

	private async Task HandleEditClick()
	{
		await subjectEditComponent.ShowAsync();
	}

	private async Task HandleEditSaved(int subjectId)
	{
		await LoadSubjectAsync();
	}

	private async Task HandleRegistrationChanged()
	{
		await LoadSubjectAsync();
		await registrationsGrid.RefreshDataAsync();
	}

	private string GetSubjectTypes(List<int> subjectTypesIds)
	{
		return String.Join(", ", subjectTypesIds.Select(id => SubjectTypesDataStore.GetByKey(id)?.Name))
			.Trim(',', ' ');
	}

	private string GetTeachers(List<int> teacherIds)
	{
		return String.Join(", ", teacherIds.Select(id => TeachersDataStore.TryGetByKey(id)?.Name))
			.Trim(',', ' ');
	}

	private string GetGrades(List<int> gradeIds)
	{
		return String.Join(", ", gradeIds.OrderBy(id => -id).Select(id => GradesDataStore.GetByKey(id)?.Name))
			.Trim(',', ' ');
	}
}
