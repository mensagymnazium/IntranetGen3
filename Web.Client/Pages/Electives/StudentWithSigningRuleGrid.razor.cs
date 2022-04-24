using Havit.Collections;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Electives;
public partial class StudentWithSigningRuleGrid
{
	[Parameter] public GridDataProviderDelegate<StudentWithSigningRuleListItemDto> DataProvider { get; set; }

	[Parameter] public bool StudentColumnVisible { get; set; } = true;

	[Inject] protected IStudentsDataStore StudentsDataStore { get; set; }
	[Inject] protected ISigningRulesDataStore SigningRulesDataStore { get; set; }
	[Inject] protected Func<ISubjectRegistrationsManagerFacade> SubjectRegistrationsManagerFacade { get; set; }

	private HxGrid<StudentWithSigningRuleListItemDto> gridComponent;
	private StudentWithSigningRuleListQueryFilter filterModel = new();

	protected override async Task OnInitializedAsync()
	{
		await StudentsDataStore.EnsureDataAsync();
		await SigningRulesDataStore.EnsureDataAsync();
	}

	public Task RefreshDataAsync() => gridComponent.RefreshDataAsync();
}