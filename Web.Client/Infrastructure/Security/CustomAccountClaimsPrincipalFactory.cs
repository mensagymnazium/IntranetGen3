using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MensaGymnazium.IntranetGen3.Web.Client.Infrastructure.Security
{
	public class CustomAccountClaimsPrincipalFactory : AccountClaimsPrincipalFactory<RemoteUserAccount>
	{
		public CustomAccountClaimsPrincipalFactory(IAccessTokenProviderAccessor accessor) : base(accessor)
		{
			// NOOP
		}

		public override async ValueTask<ClaimsPrincipal> CreateUserAsync(RemoteUserAccount account, RemoteAuthenticationUserOptions options)
		{
			var user = await base.CreateUserAsync(account, options);

			// TODO role student/učitel/...?
			//if (user.Identity.IsAuthenticated)
			//{
			//	var identity = (ClaimsIdentity)user.Identity;
			//}

			return user;
		}
	}
}
