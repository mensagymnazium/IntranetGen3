using System.Security.Claims;
using MensaGymnazium.IntranetGen3.Model.Security;

namespace MensaGymnazium.IntranetGen3.Facades.Infrastructure.Security.Authentication
{
	/// <summary>
	/// Vrací aktuálně přihlášeného uživatele jako ClaimsPrincipal nebo LoginAccount.
	/// Implementace interface ve Web.Server.
	/// </summary>
	public interface IApplicationAuthenticationService
	{
		ClaimsPrincipal GetCurrentClaimsPrincipal();
		User GetCurrentUser();
	}
}
