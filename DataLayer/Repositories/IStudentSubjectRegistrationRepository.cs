using MensaGymnazium.IntranetGen3.Model;

namespace MensaGymnazium.IntranetGen3.DataLayer.Repositories;

public partial interface IStudentSubjectRegistrationRepository
{
	public Task<List<StudentSubjectRegistration>> GetBySubjectAsync(int subjectId, CancellationToken cancellationToken = default);
	Task<List<StudentSubjectRegistration>> GetRegistrationsByStudentAsync(int studentId, CancellationToken cancellationToken = default);
	Task<int> CountMainRegistrationsForSubjectAsync(int subjectId, CancellationToken cancellationToken = default);
}
