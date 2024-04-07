using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Model;
using MensaGymnazium.IntranetGen3.Model.Security;

namespace MensaGymnazium.IntranetGen3.DataLayer.Queries;

public interface IStudentRegistrationsQuery
{
	Task<List<RegistrationsDto>> GetDataAsync(Student student, Subject subjectFilter = null, CancellationToken cancellationToken = default);
}