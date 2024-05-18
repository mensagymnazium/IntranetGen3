using System.Diagnostics;
using Havit.Collections;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Primitives;
using MensaGymnazium.IntranetGen3.Web.Client.Services;
using MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Electives;

public partial class SubjectList
{
	[Inject] protected IHxMessengerService Messenger { get; set; }
	[Inject] protected ISubjectFacade SubjectFacade { get; set; }
	[Inject] protected ISubjectRegistrationsManagerFacade SubjectRegistrationsManagerFacade { get; set; }
	[Inject] protected NavigationManager NavigationManager { get; set; }
	[Inject] protected ISubjectCategoriesDataStore SubjectCategoriesDataStore { get; set; }
	[Inject] protected IEducationalAreasDataStore EducationalAreasDataStore { get; set; }
	[Inject] protected ITeachersDataStore TeachersDataStore { get; set; }
	[Inject] protected IGradesDataStore GradesDataStore { get; set; }
	[Inject] protected IClientAuthService ClientAuthService { get; set; }
	[Inject] protected IStudentSubjectRegistrationsDataStore StudentSubjectRegistrationsDataStore { get; set; }

	private HxGrid<SubjectListItemDto> subjectsGrid; // @ref
	private SubjectListItemDto subjectSelected;
	private SubjectEdit subjectEditComponent;

	private List<StudentSubjectRegistrationDto> registeredSubjects = new(); // Never null, may be empty...
	private SubjectListQueryFilter subjectListFilter = new();
	private bool showRocnikovkaWarning = false;
	private bool showExtensionSeminarWarning = false;

	protected override async Task OnInitializedAsync()
	{
		await SubjectCategoriesDataStore.EnsureDataAsync();
		await EducationalAreasDataStore.EnsureDataAsync();
		await TeachersDataStore.EnsureDataAsync();
		await GradesDataStore.EnsureDataAsync();

		if ((await ClientAuthService.GetCurrentClaimsPrincipalAsync()).IsInRole(nameof(Role.Student)))
		{
			// Get grade (shouldn't be null, user is student)
			var gradeId = await ClientAuthService.GetCurrentStudentGradeIdAsync();
			Debug.Assert(gradeId != null, nameof(gradeId) + " != null");

			// Use grade filter
			// Xopa: Todo: the filter was used, but I couldn't make it appear in the UI. I didn't find a way to refresh the list layout filter ui.
			//subjectListFilter.GradeId = (int)gradeId.Value;

			var nextGradeId = gradeId.Value.NextGrade();
			if (nextGradeId is not null)
			{
				// Determine "rocnikovka warning"
				showRocnikovkaWarning = (nextGradeId is GradeEntry.Sexta or GradeEntry.Septima);

				// Determine "extension seminar warning"
				showExtensionSeminarWarning = (nextGradeId is GradeEntry.Kvinta or GradeEntry.Sexta);
			}

			// Get registered subjects
			await StudentSubjectRegistrationsDataStore.EnsureDataAsync();
			registeredSubjects = (await StudentSubjectRegistrationsDataStore.GetAllAsync()).ToList();
		}
	}

	protected bool IsStudentRegistered(int subjectId, StudentRegistrationType registrationType)
	{
		if (registeredSubjects.Count == 0)
		{
			return false;
		}

		// Todo: now omitting registration type, change that
		return registeredSubjects.Any(reg => reg.SubjectId == subjectId);
	}

	protected string GetRowCssClass(SubjectListItemDto item)
	{
		if (IsStudentRegistered(item.Id, StudentRegistrationType.Main))
		{
			return "reg-main";
		}
		else if (IsStudentRegistered(item.Id, StudentRegistrationType.Secondary))
		{
			return "reg-secondary";
		}

		return null;
	}

	private async Task<GridDataProviderResult<SubjectListItemDto>> LoadSubjectsAsync(GridDataProviderRequest<SubjectListItemDto> request)
	{
		var subjectListRequest = new DataFragmentRequest<SubjectListQueryFilter>()
		{
			Filter = subjectListFilter,
			StartIndex = request.StartIndex,
			Count = request.Count,
			Sorting = request.Sorting?.Select(s => new SortItem(s.SortString, s.SortDirection)).ToArray()
		};

		var subjectListResult = await SubjectFacade.GetSubjectListAsync(subjectListRequest, request.CancellationToken);

		return new()
		{
			Data = subjectListResult.Data ?? new(),
			TotalCount = subjectListResult.TotalCount
		};
	}

	private Task HandleSelectedDataItemChanged(SubjectListItemDto selection)
	{
		subjectSelected = selection;
		NavigationManager.NavigateTo(Routes.Electives.GetSubjectDetail(selection.Id));
		return Task.CompletedTask;
	}

	private async Task HandleDeleteItemClicked(SubjectListItemDto subject)
	{
		await SubjectFacade.DeleteSubjectAsync(Dto.FromValue(subject.Id));
		Messenger.AddInformation(subject.Name, "Předmět smazán.");
		await subjectsGrid.RefreshDataAsync();
	}

	private async Task HandleNewItemClicked()
	{
		await subjectEditComponent.ShowAsync();
	}

	private async Task HandleSubjectEditSaved()
	{
		await subjectsGrid.RefreshDataAsync();
	}

	private string GetEducationalAreas(List<int> educationalAreasIds)
	{
		return String.Join(", ", educationalAreasIds.Select(id => EducationalAreasDataStore.GetByKey(id)?.Name))
			.Trim(',', ' ');
	}

	private string GetGrades(List<int> gradeIds)
	{
		return String.Join(", ", gradeIds.OrderBy(id => -id).Select(id => GradesDataStore.GetByKey(id)?.Name))
			.Trim(',', ' ');
	}

	private string GetTeachers(List<int> teacherIds)
	{
		return String.Join(", ", teacherIds.Select(id => TeachersDataStore.GetByKeyOrDefault(id)?.Name))
			.Trim(',', ' ');
	}
}
