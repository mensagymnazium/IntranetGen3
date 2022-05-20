using Havit.Blazor.Components.Web.Bootstrap;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Electives;

public partial class StudentSubjectRegistrationsGrid
{
	[Parameter] public GridDataProviderDelegate<StudentSubjectRegistrationDto> DataProvider { get; set; }
	[Parameter] public bool ShowSubjectColumn { get; set; } = true;
	[Parameter] public StudentSubjectRegistrationDto SelectedDataItem { get; set; }
	[Parameter] public EventCallback<StudentSubjectRegistrationDto> SelectedDataItemChanged { get; set; }
	[Parameter] public bool SelectionEnabled { get; set; } = true;

	[Inject] protected Func<IStudentSubjectRegistrationFacade> StudentSubjectRegistrationFacade { get; set; }
	[Inject] protected IStudentsDataStore StudentsDataStore { get; set; }
	[Inject] protected ISubjectsDataStore SubjectsDataStore { get; set; }
	[Inject] protected ISigningRulesDataStore SigningRulesDataStore { get; set; }
	[Inject] protected IGradesDataStore GradesDataStore { get; set; }
	[Inject] protected IHxMessengerService Messenger { get; set; }

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
		var gradeId = StudentsDataStore.GetByKeyOrDefault(item.StudentId.Value)?.GradeId;
		if (gradeId is not null)
		{
			return GradesDataStore.GetByKey(gradeId.Value)?.Name;
		}
		return null;
	}

	private async Task HandleSelectedDataItemChanged(StudentSubjectRegistrationDto selection)
	{
		SelectedDataItem = selection;
		await SelectedDataItemChanged.InvokeAsync(selection);
	}

	private async Task HandleDeleteItemClicked(StudentSubjectRegistrationDto item)
	{
		await StudentSubjectRegistrationFacade().DeleteRegistrationAsync(Dto.FromValue(item.Id));
		Messenger.AddInformation("Zápis smazán.");
		await gridComponent.RefreshDataAsync();
	}
}
