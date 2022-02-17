using System.Security.Claims;

namespace MensaGymnazium.IntranetGen3.Facades.Infrastructure.Security.Claims;

public interface ICustomClaimsBuilder
{
	Task<List<Claim>> GetCustomClaimsAsync(ClaimsPrincipal principal);
}
