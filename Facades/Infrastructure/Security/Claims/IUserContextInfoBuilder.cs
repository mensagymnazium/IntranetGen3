using System.Security.Claims;

namespace MensaGymnazium.IntranetGen3.Facades.Infrastructure.Security.Claims;

public interface IUserContextInfoBuilder
{
	UserContextInfo GetUserContextInfo(ClaimsPrincipal principal);
}
