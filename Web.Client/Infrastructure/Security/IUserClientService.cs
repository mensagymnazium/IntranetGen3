using System.Security.Claims;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace MensaGymnazium.IntranetGen3.Web.Client.Infrastructure.Security;

public interface IUserClientService
{
	Task<IEnumerable<Claim>> FetchAdditionalUserClaimsAsync(IAccessTokenProvider accessTokenProvider, CancellationToken cancellationToken = default);
}
