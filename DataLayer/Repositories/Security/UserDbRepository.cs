using System.Linq.Expressions;
using Havit.Data.EntityFrameworkCore.Patterns.Repositories;
using MensaGymnazium.IntranetGen3.Model.Security;

namespace MensaGymnazium.IntranetGen3.DataLayer.Repositories.Security;

public partial class UserDbRepository : IUserRepository
{
	public async Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentException>(!String.IsNullOrEmpty(email));

		return await Data
			.Include(GetLoadReferences)
			.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
	}

	public async Task<User> GetByOidAsync(Guid oid, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentException>(oid != default);

		return await Data
			.Include(GetLoadReferences)
			.FirstOrDefaultAsync(u => u.Oid == oid, cancellationToken);
	}

	protected override IEnumerable<Expression<Func<User, object>>> GetLoadReferences()
	{
		yield return u => u.Student;
		yield return u => u.Teacher;
	}
}
