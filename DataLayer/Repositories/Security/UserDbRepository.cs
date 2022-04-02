using MensaGymnazium.IntranetGen3.Model.Security;

namespace MensaGymnazium.IntranetGen3.DataLayer.Repositories.Security;

public partial class UserDbRepository : IUserRepository
{
	public async Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentException>(!String.IsNullOrEmpty(email));

		return await Data.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
	}

	public async Task<User> GetByOidAsync(Guid oid, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentException>(oid != default);

		return await Data.FirstOrDefaultAsync(u => u.Oid == oid, cancellationToken);
	}
}
