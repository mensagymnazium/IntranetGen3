using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using System.Security.Claims;

namespace MensaGymnazium.IntranetGen3.Web.Client.Infrastructure.Security;

public class CustomAccountClaimsPrincipalFactory : AccountClaimsPrincipalFactory<RemoteUserAccount>
{
	private readonly IUserClientService _userClientService;

	public CustomAccountClaimsPrincipalFactory(
		IAccessTokenProviderAccessor accessor,
		IUserClientService userClientService)
		: base(accessor)
	{
		_userClientService = userClientService;
		// NOOP
	}

	public override async ValueTask<ClaimsPrincipal> CreateUserAsync(RemoteUserAccount account, RemoteAuthenticationUserOptions options)
	{
		var user = await base.CreateUserAsync(account, options);

		if (user.Identity.IsAuthenticated)
		{
			var identity = (ClaimsIdentity)user.Identity;

			var claims = await _userClientService.FetchAdditionalUserClaimsAsync(this.TokenProvider);

			foreach (var claim in claims)
			{
				if (claim.Type.Equals(ClaimTypes.Role))
				{
					identity.AddClaim(new Claim(options.RoleClaim, claim.Value));
				}
				else
				{
					identity.AddClaim(claim);
				}
			}
		}

		return user;
	}
}
