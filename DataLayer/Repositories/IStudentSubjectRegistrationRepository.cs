using MensaGymnazium.IntranetGen3.Model;

namespace MensaGymnazium.IntranetGen3.DataLayer.Repositories;

public partial interface IStudentSubjectRegistrationRepository
{
	public Task<List<StudentSubjectRegistration>> GetBySubjectAsync(int subjectId, CancellationToken cancellationToken = default);

	/// <returns>Active (not deleted) registrations made by a student for a subject</returns>
	Task<List<StudentSubjectRegistration>> GetActiveRegistrationsByStudentAsync(int studentId, CancellationToken cancellationToken = default);
	Task<int> CountMainRegistrationsForSubjectAsync(int subjectId, CancellationToken cancellationToken = default);
}
