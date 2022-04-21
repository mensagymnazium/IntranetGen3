using Havit.ComponentModel;

namespace MensaGymnazium.IntranetGen3.Contracts;

[ApiContract]
public interface ISigningRuleFacade
{
	Task<List<SigningRuleReferenceDto>> GetAllSigningRuleReferencesAsync(CancellationToken cancellationToken = default);
	Task<DataFragmentResult<SigningRuleDto>> GetSigningRuleListAsync(DataFragmentRequest<SigningRuleListQueryFilter> signingRuleListRequest, CancellationToken cancellationToken = default);
	Task DeleteSigningRuleAsync(Dto<int> SigningRuleId, CancellationToken cancellationToken = default);
	Task<Dto<int>> CreateSigningRuleAsync(SigningRuleDto SigningRuleEditDto, CancellationToken cancellationToken = default);
	Task UpdateSigningRuleAsync(SigningRuleDto SigningRuleEditDto, CancellationToken cancellationToken = default);
	Task<SigningRuleDto> GetSigningRuleDetailAsync(Dto<int> SigningRuleIdDto, CancellationToken cancellationToken = default);
}
