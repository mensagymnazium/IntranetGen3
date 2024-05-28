using System.Linq.Expressions;
using MensaGymnazium.IntranetGen3.Model.Security;

namespace MensaGymnazium.IntranetGen3.DataLayer.Repositories.Security;

public partial class StudentDbRepository : IStudentRepository
{
	public Task<List<Student>> GetAllIncludingDeletedAsync(CancellationToken cancellationToken)
	{
		return DataIncludingDeleted.Include(s => s.User).ToListAsync(cancellationToken);
	}

	protected override IEnumerable<Expression<Func<Student, object>>> GetLoadReferences()
	{
		yield return s => s.User;
		yield return s => s.Grade;
	}

}
