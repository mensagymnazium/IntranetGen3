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

	private SubjectListQueryFilter subjectListFilter = new();
	private static SubjectListQueryFilter s_rememberedSubjectListFilter; // Null by default

	private GridUserState gridUserState = new(); // Sorting
	private static GridUserState s_rememberedGridUserState; // Null by default

	private List<StudentSubjectRegistrationDto> registeredSubjects = new(); // Never null, may be empty...
	private bool showRocnikovkaWarning = false;
	private bool showExtensionSeminarWarning = false;

	protected override void OnInitialized()
	{
		// Load remembered state (if we have some)
		if (s_rememberedSubjectListFilter is not null)
		{
			subjectListFilter = s_rememberedSubjectListFilter;
		}

		if (s_rememberedGridUserState is not null)
		{
			gridUserState = s_rememberedGridUserState;
		}
	}

	protected override async Task OnInitializedAsync()
	{
		await SubjectCategoriesDataStore.EnsureDataAsync();
		await EducationalAreasDataStore.EnsureDataAsync();
		await TeachersDataStore.EnsureDataAsync();
		await GradesDataStore.EnsureDataAsync();

		// Student specific setup
		if ((await ClientAuthService.GetCurrentClaimsPrincipalAsync())
			.IsInRole(nameof(Role.Student)))
		{
			var gradeEntry = await ClientAuthService.GetCurrentStudentGradeIdAsync();
			// Get grade (shouldn't be null, user is student)
			Debug.Assert(gradeEntry != null, nameof(gradeEntry) + " != null");

			var nextGradeEntry = gradeEntry.Value.NextGrade(); // Should have a value (octava isn't allowed on this page)

			// Determine "rocnikovka warning"
			showRocnikovkaWarning = (nextGradeEntry is GradeEntry.Sexta or GradeEntry.Septima);

			// Determine "extension seminar warning"
			showExtensionSeminarWarning = (nextGradeEntry is GradeEntry.Kvinta or GradeEntry.Sexta);

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
		await TrySetupFilterForFirstLoad();

		// Remember filter and sorting for next time coming to this page
		s_rememberedSubjectListFilter = subjectListFilter;
		s_rememberedGridUserState = gridUserState;

		var sorting = request.Sorting?.Select(s => new SortItem(s.SortString, s.SortDirection)).ToArray();

		var subjectListRequest = new DataFragmentRequest<SubjectListQueryFilter>()
		{
			Filter = subjectListFilter,
			StartIndex = request.StartIndex,
			Count = request.Count,
			Sorting = sorting
		};

		var subjectListResult = await SubjectFacade.GetSubjectListAsync(subjectListRequest, request.CancellationToken);

		return new()
		{
			Data = subjectListResult.Data ?? new(),
			TotalCount = subjectListResult.TotalCount
		};
	}

	/// <summary>
	/// Presets the filter for the current user for better UX
	/// If student, show subjects for next grade
	/// </summary>
	/// <returns></returns>
	private async Task TrySetupFilterForFirstLoad()
	{
		// Setup filter for the first time coming into here
		if (s_rememberedSubjectListFilter is not null)
		{
			// -> Not here for the first time
			return;
		}

		// for STUDENTS - Set grade filter to next grade
		if ((await ClientAuthService.GetCurrentClaimsPrincipalAsync())
			.IsInRole(nameof(Role.Student)))
		{
			// User is a student
			var gradeEntry = await ClientAuthService.GetCurrentStudentGradeIdAsync();
			var nextGradeEntry = gradeEntry.Value.NextGrade(); // Should have a value (octava isn't allowed on this page)
			subjectListFilter.GradeId = (int?)nextGradeEntry;
		}

		// maybe todo? : show teachers only their subjects?
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
