using System.Linq.Expressions;
using MensaGymnazium.IntranetGen3.Model;

namespace MensaGymnazium.IntranetGen3.DataLayer.Repositories;

public partial class GradeDbRepository : IGradeRepository
{
	protected override IEnumerable<Expression<Func<Grade, object>>> GetLoadReferences()
	{
		yield return g => g.RegistrationCriteria;
	}

	//public Task<Dictionary<int, Grade>> GetGradesForStudentsAsync(int[] studentIds, CancellationToken cancellationToken)
	//{
	//	return Data
	//		.Where())
	//}
}
