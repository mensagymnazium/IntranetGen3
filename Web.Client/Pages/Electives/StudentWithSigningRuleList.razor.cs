//using Havit.Collections;
//using MensaGymnazium.IntranetGen3.Contracts;
//using MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

//namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Electives;
//public partial class StudentWithSigningRuleList
//{
//	[Inject] protected IStudentsDataStore StudentsDataStore { get; set; }
//	[Inject] protected ISigningRulesDataStore SigningRulesDataStore { get; set; }
//	[Inject] protected ISubjectRegistrationsManagerFacade SubjectRegistrationsManagerFacade { get; set; }

//	private StudentWithSigningRuleGrid gridComponent;
//	private StudentWithSigningRuleListQueryFilter filterModel = new() { IncompleteOnly = true };

//	protected override async Task OnInitializedAsync()
//	{
//		await StudentsDataStore.EnsureDataAsync();
//		await SigningRulesDataStore.EnsureDataAsync();
//	}

//	private async Task<GridDataProviderResult<StudentWithSigningRuleListItemDto>> GetGridData(GridDataProviderRequest<StudentWithSigningRuleListItemDto> request)
//	{
//		var facadeRequest = new DataFragmentRequest<StudentWithSigningRuleListQueryFilter>()
//		{
//			Filter = filterModel,
//			StartIndex = request.StartIndex,
//			Count = request.Count,
//			Sorting = request.Sorting?.Select(s => new SortItem(s.SortString, s.SortDirection)).ToArray()
//		};

//		var signingRuleListResult = await SubjectRegistrationsManagerFacade.GetStudentWithSigningRuleListAsync(facadeRequest, request.CancellationToken);

//		return new()
//		{
//			Data = signingRuleListResult.Data ?? new(),
//			TotalCount = signingRuleListResult.TotalCount
//		};
//	}

//	private async Task HandleFilterModelChanged(StudentWithSigningRuleListQueryFilter newFilterModel)
//	{
//		filterModel = newFilterModel;
//		await gridComponent.RefreshDataAsync();
//	}

//	private async Task HandleIncompleteOnlyValueChanged(bool newValue)
//	{
//		filterModel.IncompleteOnly = newValue;
//		await gridComponent.RefreshDataAsync();
//	}
//}