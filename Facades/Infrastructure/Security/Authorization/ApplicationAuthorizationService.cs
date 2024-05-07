using System.Security;
using System.Security.Claims;
using MensaGymnazium.IntranetGen3.Facades.Infrastructure.Security.Authentication;

namespace MensaGymnazium.IntranetGen3.Facades.Infrastructure.Security.Authorization;

[Service]
public class ApplicationAuthorizationService : IApplicationAuthorizationService
{
	private readonly IApplicationAuthenticationService _applicationAuthenticationService;
	private readonly IAuthorizationService _authorizationService;

	public ApplicationAuthorizationService(IApplicationAuthenticationService applicationAuthenticationService, IAuthorizationService authorizationService)
	{
		_applicationAuthenticationService = applicationAuthenticationService;
		_authorizationService = authorizationService;
	}

	public bool IsAuthorized(ClaimsPrincipal user, IAuthorizationRequirement requirement, object resource = null)
	{
		Contract.Requires<ArgumentNullException>(user != null);
		Contract.Requires<ArgumentNullException>(requirement != null);

		return _authorizationService.AuthorizeAsync(user, resource, requirement).GetAwaiter().GetResult().Succeeded;
	}

	public void VerifyAuthorization(ClaimsPrincipal user, IAuthorizationRequirement requirement, object resource = null)
	{
		if (!IsAuthorized(user, requirement, resource))
		{
			throw new SecurityException();
		}
	}

	public bool IsCurrentUserAuthorized(IAuthorizationRequirement requirement, object resource = null)
	{
		return IsAuthorized(_applicationAuthenticationService.GetCurrentClaimsPrincipal(), requirement, resource);
	}

	public void VerifyCurrentUserAuthorization(IAuthorizationRequirement requirement, object resource = null)
	{
		VerifyAuthorization(_applicationAuthenticationService.GetCurrentClaimsPrincipal(), requirement, resource);
	}

	public bool IsCurrentUserAuthorized(IAuthorizationRequirement requirement)
	{
		return IsAuthorized(_applicationAuthenticationService.GetCurrentClaimsPrincipal(), null, requirement);
	}
}
