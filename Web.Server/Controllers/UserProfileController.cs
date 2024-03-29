﻿using System.Security.Claims;
using MensaGymnazium.IntranetGen3.Contracts.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MensaGymnazium.IntranetGen3.Web.Server.Controllers;

[Authorize]
public class UserProfileController : ControllerBase
{
	[HttpGet("/user-claims")]
	public IEnumerable<KeyValuePair<string, string>> GetAdditionalClaims()
	{
		return HttpContext.User
			.FindAll(c => c.Type.Equals(ClaimTypes.Role)
						|| c.Type.Equals(ClaimConstants.UserIdClaimType)
						|| c.Type.Equals(ClaimConstants.StudentGradeIdClaimType)
					)
			.Select(c => new KeyValuePair<string, string>(c.Type, c.Value ?? String.Empty));
	}
}
