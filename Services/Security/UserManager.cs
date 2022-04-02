using MensaGymnazium.IntranetGen3.Model.Security;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Services.Security;

[Service]
public class UserManager : IUserManager
{
	public Task<IList<Role>> GetRolesAsync(User user, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(user != null);

		var roles = new List<Role>();

		if (user.StudentId != null)
		{
			roles.Add(Role.Student);
		}

		if (user.TeacherId != null)
		{
			roles.Add(Role.Teacher);
		}

#if DEBUG
		roles = Enum.GetValues<Role>().ToList();
#endif

		return Task.FromResult<IList<Role>>(roles);
	}
}
