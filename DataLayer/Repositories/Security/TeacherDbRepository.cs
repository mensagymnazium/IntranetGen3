using System.Linq.Expressions;
using Havit.Data.EntityFrameworkCore.Patterns.Repositories;
using MensaGymnazium.IntranetGen3.Model.Security;

namespace MensaGymnazium.IntranetGen3.DataLayer.Repositories.Security;

public partial class TeacherDbRepository : ITeacherRepository
{
	public async Task<List<Teacher>> GetAllIncludingDeletedAsync(CancellationToken cancellationToken = default)
	{
		return await DataIncludingDeleted.Include(t => t.User).ToListAsync(cancellationToken);
	}
}