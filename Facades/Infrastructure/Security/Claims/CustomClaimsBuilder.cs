using System.Security;
using System.Security.Claims;
using MensaGymnazium.IntranetGen3.Contracts.Security;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories.Security;
using MensaGymnazium.IntranetGen3.Model.Security;
using MensaGymnazium.IntranetGen3.Services.Infrastructure;
using MensaGymnazium.IntranetGen3.Services.Security;

namespace MensaGymnazium.IntranetGen3.Facades.Infrastructure.Security.Claims;

[Service(Profile = ServiceProfiles.WebServer)]
public class CustomClaimsBuilder : ICustomClaimsBuilder
{
	private readonly IUserRepository _userRepository;
	private readonly IUserManager _userManager;
	private readonly IUserOnboarder _userOnboarder;
	private readonly IUserContextInfoBuilder _userContextInfoBuilder;

	public CustomClaimsBuilder(
		IUserContextInfoBuilder userContextInfoBuilder,
		IUserRepository userRepository,
		IUserManager userManager,
		IUserOnboarder userOnboarder)
	{
		_userContextInfoBuilder = userContextInfoBuilder;
		_userRepository = userRepository;
		_userManager = userManager;
		_userOnboarder = userOnboarder;
	}

	/// <summary>
	/// Získá custom claims pro daný principal.
	/// </summary>
	public async Task<List<Claim>> GetCustomClaimsAsync(ClaimsPrincipal principal)
	{
		Contract.Requires<SecurityException>(principal.Identity.IsAuthenticated);

		List<Claim> result = new List<Claim>();

		UserContextInfo userContextInfo = _userContextInfoBuilder.GetUserContextInfo(principal);

		User user = await _userRepository.GetByOidAsync(userContextInfo.Oid);

		if (user == null)
		{
			user = await _userOnboarder.TryOnboardUserAsync(userContextInfo.Oid, principal);
			if (user == null)
			{
				throw new SecurityException("Onboarding uživatele nebyl úspěšný.");
			}
		}
		else
		{
			await _userOnboarder.UpdateUserAsync(user, principal);
		}

		// user.Id
		result.Add(new Claim(ClaimConstants.UserIdClaimType, user.Id.ToString(), null, ClaimConstants.ApplicationIssuer));

		// StudentGradeId
		if (user.Student != null)
		{
			result.Add(new Claim(ClaimConstants.StudentGradeIdClaimType, user.Student.GradeId.ToString(), null, ClaimConstants.ApplicationIssuer));
		}

		// role
		var roles = await _userManager.GetRolesAsync(user, principal);
		foreach (var role in roles)
		{
			result.Add(new Claim(ClaimTypes.Role, role.ToString("g"), null, ClaimConstants.ApplicationIssuer));
		}

		return result;
	}
}
