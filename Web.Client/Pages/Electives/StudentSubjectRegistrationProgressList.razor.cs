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

	protected override async Task OnInitializedAsync()
	{
		await StudentsDataStore.EnsureDataAsync();
		await GradesDataStore.EnsureDataAsync();
	}

	private async Task<GridDataProviderResult<StudentSubjectRegistrationProgressListItemDto>> DataProvider(
		GridDataProviderRequest<StudentSubjectRegistrationProgressListItemDto> request)
	{
		var data = await ProgressValidationFacade
			.GetProgressListAsync(_filterModel, request.CancellationToken);

		// Due to deserialization, sometimes we receive empty lists,
		// so 'List<>MissingCriteria' may be null

		return request.ApplyTo(data);
	}

	private string GetStudentName(int studentId)
	{
		return StudentsDataStore.GetByKey(studentId).Name;
	}

	private string GetStudentLastName(int studentId)
	{
		return StudentsDataStore.GetByKey(studentId).LastName ?? "-příjmení nenačteno-";
	}

	private string GetStudentGradeName(int studentId)
	{
		var gradeId = StudentsDataStore.GetByKeyOrDefault(studentId)?.GradeId;
		return gradeId is not null
			? GradesDataStore.GetByKey(gradeId.Value)?.Name
			: null;
	}

	private int? GetStudentGradeId(int studentId)
	{
		var gradeId = StudentsDataStore.GetByKeyOrDefault(studentId)?.GradeId;
		return gradeId;
	}
}