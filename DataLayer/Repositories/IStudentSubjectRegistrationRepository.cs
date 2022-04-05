using MensaGymnazium.IntranetGen3.Model;

namespace MensaGymnazium.IntranetGen3.DataLayer.Repositories;

public partial interface IStudentSubjectRegistrationRepository
{
	Task<List<StudentSubjectRegistration>> GetBySubjectAsync(int id, CancellationToken cancellationToken = default);
}
