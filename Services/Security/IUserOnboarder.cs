using System.Security.Claims;
using MensaGymnazium.IntranetGen3.Model.Security;

namespace MensaGymnazium.IntranetGen3.Services.Security;

public interface IUserOnboarder
{
	/// <summary>
	/// Pokusí se založit nového uživatele, který přichází authentizovaný, ale nemáme ho dosud v DB.
	/// </summary>
	Task<User> TryOnboardUserAsync(Guid oid, ClaimsPrincipal principal, CancellationToken cancelationToken = default);
}
