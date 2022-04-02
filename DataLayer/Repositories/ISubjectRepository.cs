using MensaGymnazium.IntranetGen3.Model;

namespace MensaGymnazium.IntranetGen3.DataLayer.Repositories;

public partial interface ISubjectRepository
{
	Task<List<Subject>> GetAllIncludingDeletedAsync(CancellationToken cancellationToken);
}
