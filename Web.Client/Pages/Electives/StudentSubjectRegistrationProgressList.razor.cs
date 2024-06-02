using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Electives;

public partial class StudentSubjectRegistrationProgressList
{
	[Inject] protected IStudentsDataStore StudentsDataStore { get; set; }
	[Inject] protected IGradesDataStore GradesDataStore { get; set; }
	[Inject] protected ISubjectRegistrationProgressValidationFacade ProgressValidationFacade { get; set; }

	private HxGrid<StudentSubjectRegistrationProgressListItemDto> _grid; // @ref
	private StudentSubjectRegistrationProgressListFilter _filterModel = new();
	private List<StudentSubjectRegistrationProgressListItemDto> _data;

	protected override async Task OnInitializedAsync()
	{
		await StudentsDataStore.EnsureDataAsync();
		await GradesDataStore.EnsureDataAsync();
	}

	protected override async Task OnParametersSetAsync()
	{
		await RefreshDataAsync();
	}

	private Task<GridDataProviderResult<StudentSubjectRegistrationProgressListItemDto>> DataProvider(
		GridDataProviderRequest<StudentSubjectRegistrationProgressListItemDto> request)
	{
		return Task.FromResult(request.ApplyTo(_data));
	}

	private async Task RefreshDataAsync()
	{
		_data = await ProgressValidationFacade.GetProgressListAsync(_filterModel) ?? new();
		await _grid.RefreshDataAsync();
	}

	private string GetStudentName(int studentId)
	{
		return StudentsDataStore.GetByKeyOrDefault(studentId)?.Name;
	}

	private string GetStudentLastName(int studentId)
	{
		return StudentsDataStore.GetByKeyOrDefault(studentId).LastName ?? "-příjmení nenačteno-";
	}

	private string GetStudentGradeName(int studentId)
	{
		var gradeId = StudentsDataStore.GetByKeyOrDefault(studentId)?.GradeId;
		return gradeId is not null
			? GradesDataStore.GetByKeyOrDefault(gradeId.Value)?.Name
			: null;
	}

	private int? GetStudentGradeId(int studentId)
	{
		var gradeId = StudentsDataStore.GetByKeyOrDefault(studentId)?.GradeId;
		return gradeId;
	}
}