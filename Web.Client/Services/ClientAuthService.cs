using System.Security.Claims;
using MensaGymnazium.IntranetGen3.Contracts.Security;
using MensaGymnazium.IntranetGen3.Primitives;
using Microsoft.AspNetCore.Components.Authorization;

namespace MensaGymnazium.IntranetGen3.Web.Client.Services;

public class ClientAuthService : IClientAuthService
{
	private readonly AuthenticationStateProvider authenticationStateProvider;

	public ClientAuthService(AuthenticationStateProvider authenticationStateProvider)
	{
		this.authenticationStateProvider = authenticationStateProvider;
	}

	public async Task<ClaimsPrincipal> GetCurrentClaimsPrincipal()
	{
		var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
		return authState.User;
	}

	public async Task<GradeEntry?> GetCurrentStudentGradeIdAsync()
	{
		var user = await GetCurrentClaimsPrincipal();
		var claim = user.FindFirst(ClaimConstants.StudentGradeIdClaimType);
		if (claim is not null)
		{
			return Enum.Parse<GradeEntry>(claim.Value);
		}
		return null;
	}

	public async Task<int?> GetCurrentUserIdAsync()
	{
		var user = await GetCurrentClaimsPrincipal();
		var claim = user.FindFirst(ClaimConstants.UserIdClaimType);
		if (claim is not null)
		{
			return int.Parse(claim.Value);
		}
		return null;
	}
}
