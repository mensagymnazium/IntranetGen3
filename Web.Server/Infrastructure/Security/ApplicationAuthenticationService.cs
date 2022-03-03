using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using MensaGymnazium.IntranetGen3.Facades.Infrastructure.Security.Authentication;
using MensaGymnazium.IntranetGen3.Model.Security;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories.Security;
using MensaGymnazium.IntranetGen3.Contracts.Infrastructure.Security;

namespace MensaGymnazium.IntranetGen3.Web.Server.Infrastructure.Security
{
	/// <summary>
	/// Poskytuje uživatele z HttpContextu.
	/// </summary>
	public class ApplicationAuthenticationService : IApplicationAuthenticationService
	{
		private readonly IHttpContextAccessor httpContextAccessor;

		private readonly Lazy<User> userLazy;

		public ApplicationAuthenticationService(
			IHttpContextAccessor httpContextAccessor,
			IUserRepository userRepository)
		{
			this.httpContextAccessor = httpContextAccessor;

			userLazy = new Lazy<User>(() => userRepository.GetObject(GetCurrentUserId()));
		}

		public ClaimsPrincipal GetCurrentClaimsPrincipal()
		{
			return httpContextAccessor.HttpContext.User;
		}

		public User GetCurrentUser() => userLazy.Value;

		private int GetCurrentUserId()
		{
			var principal = GetCurrentClaimsPrincipal();
			Claim userIdClaim = principal.Claims.Single(claim => (claim.Type == ClaimConstants.UserIdClaim));
			return Int32.Parse(userIdClaim.Value);
		}
	}
}
