using MensaGymnazium.IntranetGen3.Model;

namespace MensaGymnazium.IntranetGen3.DataLayer.Repositories;

public partial class SubjectDbRepository : ISubjectRepository
{
	public Task<List<Subject>> GetAllIncludingDeletedAsync(CancellationToken cancellationToken)
	{
		return this.DataIncludingDeleted.ToListAsync(cancellationToken);
	}
}
