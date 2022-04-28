using System.Security.Claims;
using MensaGymnazium.IntranetGen3.Contracts.Security;
using MensaGymnazium.IntranetGen3.Facades.Infrastructure.Security.Authentication;
using MensaGymnazium.IntranetGen3.Model.Security;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Services.Security;

[Service]
public class UserManager : IUserManager
{
	private readonly IApplicationAuthenticationService applicationAuthenticationService;

	public UserManager(IApplicationAuthenticationService applicationAuthenticationService)
	{
		this.applicationAuthenticationService = applicationAuthenticationService;
	}

	public Task<IList<Role>> GetRolesAsync(User user, ClaimsPrincipal principal = null, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(user != null);

		var roles = new List<Role>();

		if ((user.Student != null) && (user.Student.Deleted is null))
		{
			roles.Add(Role.Student);
		}

		if ((user.TeacherId != null) && (user.Teacher.Deleted is null))
		{
			roles.Add(Role.Teacher);
		}

		principal ??= applicationAuthenticationService.GetCurrentClaimsPrincipal();
		if (principal.HasClaim(ClaimConstants.GroupClaimType, AadGroupIds.Administrators)
			|| (user.Email == "martin.truksa@mensagymnazium.cz")
			|| (user.Email == "vojtech.tvrdik@mensagymnazium.cz")
			|| (user.Email == "benjamin.swart@mensagymnazium.cz")
			|| (user.Email == "zbynek.vavra@mensagymnazium.cz"))
		{
			roles.Add(Role.Administrator);
		}

		//#if DEBUG
		//		roles = Enum.GetValues<Role>().ToList();
		//#endif

		return Task.FromResult<IList<Role>>(roles);
	}
}
