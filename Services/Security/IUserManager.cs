using MensaGymnazium.IntranetGen3.Model.Security;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Services.Security;

public interface IUserManager
{
	Task<IList<Role>> GetRolesAsync(User user, CancellationToken cancellationToken = default);
	//Task<bool> IsInRolesAsync(User user, Role role, CancellationToken cancellationToken = default);
}
