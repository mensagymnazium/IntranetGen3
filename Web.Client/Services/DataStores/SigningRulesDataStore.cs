//using Havit.Blazor.Components.Web.Services.DataStores;
//using MensaGymnazium.IntranetGen3.Contracts;
//using MensaGymnazium.IntranetGen3.Contracts.Security;

//namespace MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

//public class SigningRulesDataStore : DictionaryStaticDataStore<int, SigningRuleReferenceDto>, ISigningRulesDataStore
//{
//	private readonly ISigningRuleFacade signingRuleFacade;

//	public SigningRulesDataStore(ISigningRuleFacade signingRuleFacade)
//	{
//		this.signingRuleFacade = signingRuleFacade;
//	}

//	protected override Func<SigningRuleReferenceDto, int> KeySelector => (s) => s.Id;
//	protected override bool ShouldRefresh() => false; // just hit F5 :-D

//	protected async override Task<IEnumerable<SigningRuleReferenceDto>> LoadDataAsync()
//	{
//		var dto = await signingRuleFacade.GetAllSigningRuleReferencesAsync();
//		return dto ?? new List<SigningRuleReferenceDto>();
//	}
//}
