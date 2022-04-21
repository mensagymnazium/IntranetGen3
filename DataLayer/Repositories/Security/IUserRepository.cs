using MensaGymnazium.IntranetGen3.Model.Security;

namespace MensaGymnazium.IntranetGen3.DataLayer.Repositories.Security;

public partial interface IUserRepository
{
	Task<User> GetByOidAsync(Guid oid, CancellationToken cancellationToken = default);
	Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
}
