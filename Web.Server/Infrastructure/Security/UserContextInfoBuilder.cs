using System.Security.Claims;
using MensaGymnazium.IntranetGen3.Facades.Infrastructure.Security.Claims;

namespace MensaGymnazium.IntranetGen3.Web.Server.Infrastructure.Security;

public class UserContextInfoBuilder : IUserContextInfoBuilder
{
	/// <summary>
	/// Vrací informace o přihlášeném uživateli.
	/// Pro nepřihlášeného uživatele vrací null.
	/// </summary>
	public UserContextInfo GetUserContextInfo(ClaimsPrincipal principal)
	{
		// nelze použít httpContextAccessor.HttpContext.User.Identity.IsAuthenticated, protože jeho Identity.IsAuthenticated v tento okamžik 
		// ještě false (ačkoliv pro principal z parametru je true).
		if (!principal.Identity.IsAuthenticated)
		{
			return null;
		}

		if (userContextInfo == null)
		{
			Claim externalIdClaim = principal.Claims.Single(claim => claim.Type == "oid");

			userContextInfo = new UserContextInfo(Guid.Parse(externalIdClaim.Value));
		}

		return userContextInfo;
	}

	private UserContextInfo userContextInfo;
}
