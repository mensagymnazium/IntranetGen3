using System.Security;
using System.Security.Claims;
using MensaGymnazium.IntranetGen3.Contracts.Infrastructure.Security;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories.Security;
using MensaGymnazium.IntranetGen3.Model.Security;
using MensaGymnazium.IntranetGen3.Services.Infrastructure;
using MensaGymnazium.IntranetGen3.Services.Security;

namespace MensaGymnazium.IntranetGen3.Facades.Infrastructure.Security.Claims;

[Service(Profile = ServiceProfiles.WebServer)]
public class CustomClaimsBuilder : ICustomClaimsBuilder
{
	private readonly IUserRepository userRepository;
	private readonly IUserManager userManager;
	private readonly IUserOnboarder userOnboarder;
	private readonly IUserContextInfoBuilder userContextInfoBuilder;

	public CustomClaimsBuilder(
		IUserContextInfoBuilder userContextInfoBuilder,
		IUserRepository userRepository,
		IUserManager userManager,
		IUserOnboarder userOnboarder)
	{
		this.userContextInfoBuilder = userContextInfoBuilder;
		this.userRepository = userRepository;
		this.userManager = userManager;
		this.userOnboarder = userOnboarder;
	}

	/// <summary>
	/// Získá custom claims pro daný principal.
	/// </summary>
	public async Task<List<Claim>> GetCustomClaimsAsync(ClaimsPrincipal principal)
	{
		Contract.Requires<SecurityException>(principal.Identity.IsAuthenticated);

		List<Claim> result = new List<Claim>();

		UserContextInfo userContextInfo = userContextInfoBuilder.GetUserContextInfo(principal);

		User user = await userRepository.GetByOidAsync(userContextInfo.Oid);

		if (user == null)
		{
			user = await userOnboarder.TryOnboardUserAsync(userContextInfo.Oid, principal);
			if (user == null)
			{
				throw new SecurityException("Onboarding uživatele nebyl úspěšný.");
			}
		}

		// user.Id
		result.Add(new Claim(ClaimConstants.UserIdClaim, user.Id.ToString(), null, ClaimConstants.ApplicationIssuer));

		// role
		var roles = await userManager.GetRolesAsync(user);
		foreach (var role in roles)
		{
			result.Add(new Claim(ClaimTypes.Role, role.ToString("g"), null, ClaimConstants.ApplicationIssuer));
		}

		return result;
	}
}
