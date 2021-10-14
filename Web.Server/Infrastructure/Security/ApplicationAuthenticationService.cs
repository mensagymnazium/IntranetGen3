using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Havit.Diagnostics.Contracts;
using MensaGymnazium.IntranetGen3.Facades.Infrastructure.Security.Authentication;
using MensaGymnazium.IntranetGen3.Model.Security;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories.Security;

namespace MensaGymnazium.IntranetGen3.Web.Server.Infrastructure.Security
{
	/// <summary>
	/// Poskytuje uživatele z HttpContextu.
	/// </summary>
	public class ApplicationAuthenticationService : IApplicationAuthenticationService
	{
		private readonly IHttpContextAccessor httpContextAccessor;

		private readonly Lazy<User> userLazy;

		public ApplicationAuthenticationService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
		{
			this.httpContextAccessor = httpContextAccessor;

			userLazy = new Lazy<User>(() => GetOrCreateUser());
		}

		public ClaimsPrincipal GetCurrentClaimsPrincipal()
		{
			return httpContextAccessor.HttpContext.User;
		}

		public User GetCurrentUser() => userLazy.Value;

		private int GetCurrentUserAadObjectId()
		{
			var principal = GetCurrentClaimsPrincipal();
			Claim userIdClaim = principal.Claims.Single(claim => (claim.Type == "oid"));
			return Int32.Parse(userIdClaim.Value);
		}

		private User GetOrCreateUser()
		{
			throw new NotImplementedException();
			/* TODO userRepository.GetByAadObjectId(GetCurrentUserAadObjectId())); */
		}
	}
}
