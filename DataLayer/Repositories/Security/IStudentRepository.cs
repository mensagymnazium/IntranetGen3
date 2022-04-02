using MensaGymnazium.IntranetGen3.Model.Security;

namespace MensaGymnazium.IntranetGen3.DataLayer.Repositories.Security;

public partial interface IStudentRepository
{
	Task<List<Student>> GetAllIncludingDeletedAsync(CancellationToken cancellationToken);
}
