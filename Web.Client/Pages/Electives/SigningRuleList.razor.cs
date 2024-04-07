//using MensaGymnazium.IntranetGen3.Contracts;
//using Microsoft.AspNetCore.Components;
//using Havit.Collections;
//using MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

//namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Electives;

//public partial class SigningRuleList
//{
//	[Inject] protected IHxMessengerService Messenger { get; set; }
//	[Inject] protected ISigningRuleFacade SigningRuleFacade { get; set; }
//	[Inject] protected NavigationManager NavigationManager { get; set; }
//	[Inject] protected IGradesDataStore GradesDataStore { get; set; }
//	[Inject] protected ISubjectCategoriesDataStore SubjectCategoriesDataStore { get; set; }
//	[Inject] protected ISubjectTypesDataStore SubjectTypesDataStore { get; set; }

//	private SigningRuleListQueryFilter signingRuleListFilter = new SigningRuleListQueryFilter();
//	private HxGrid<SigningRuleDto> gridComponent;

//	protected override async Task OnInitializedAsync()
//	{
//		await GradesDataStore.EnsureDataAsync();
//		await SubjectCategoriesDataStore.EnsureDataAsync();
//		await SubjectTypesDataStore.EnsureDataAsync();
//	}

//	private async Task<GridDataProviderResult<SigningRuleDto>> LoadSigningRules(GridDataProviderRequest<SigningRuleDto> request)
//	{
//		var SigningRuleRequest = new DataFragmentRequest<SigningRuleListQueryFilter>()
//		{
//			Filter = signingRuleListFilter,
//			StartIndex = request.StartIndex,
//			Count = request.Count,
//			Sorting = request.Sorting?.Select(s => new SortItem(s.SortString, s.SortDirection)).ToArray()
//		};

//		var signingRuleListResult = await SigningRuleFacade.GetSigningRuleListAsync(SigningRuleRequest, request.CancellationToken);

//		return new()
//		{
//			Data = signingRuleListResult.Data ?? new(),
//			TotalCount = signingRuleListResult.TotalCount
//		};
//	}

//	private string GetSubjectTypes(List<int> subjectTypesIds)
//	{
//		if (subjectTypesIds.Count == SubjectTypesDataStore.GetAll()?.Count())
//		{
//			return "všechny";
//		}

//		return String.Join(", ", subjectTypesIds.Select(id => SubjectTypesDataStore.GetByKey(id)?.Name))
//			.Trim(',', ' ');
//	}

//	private string GetSubjectCategories(List<int> subjectCategoriesIds)
//	{
//		return String.Join(", ", subjectCategoriesIds.Select(id => SubjectCategoriesDataStore.GetByKey(id)?.Name))
//			.Trim(',', ' ');
//	}
//}
