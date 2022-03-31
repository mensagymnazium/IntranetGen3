using MensaGymnazium.IntranetGen3.Model.Security;

namespace MensaGymnazium.IntranetGen3.DataLayer.Repositories.Security;

public partial interface ITeacherRepository
{
	Task<List<Teacher>> GetAllIncludingDeletedAsync(CancellationToken cancellationToken = default);
}
