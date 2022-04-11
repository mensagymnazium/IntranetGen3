using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Electives;

public partial class StudentSubjectRegistrationsGrid
{
	[Parameter] public GridDataProviderDelegate<StudentSubjectRegistrationDto> DataProvider { get; set; }
	[Parameter] public bool ShowSubjectColumn { get; set; } = true;

	[Inject] protected IStudentsDataStore StudentsDataStore { get; set; }
	[Inject] protected ISubjectsDataStore SubjectsDataStore { get; set; }
	[Inject] protected ISigningRulesDataStore SigningRulesDataStore { get; set; }
	[Inject] protected IGradesDataStore GradesDataStore { get; set; }

	private HxGrid<StudentSubjectRegistrationDto> gridComponent;

	protected override async Task OnInitializedAsync()
	{
		await StudentsDataStore.EnsureDataAsync();
		await SubjectsDataStore.EnsureDataAsync();
		await SigningRulesDataStore.EnsureDataAsync();
		await GradesDataStore.EnsureDataAsync();
	}

	public Task RefreshDataAsync() => gridComponent.RefreshDataAsync();

	private string GetStudentGradeName(StudentSubjectRegistrationDto item)
	{
		var gradeId = StudentsDataStore.GetByKey(item.StudentId.Value)?.GradeId;
		if (gradeId is not null)
		{
			return GradesDataStore.GetByKey(gradeId.Value)?.Name;
		}
		return null;
	}
}
