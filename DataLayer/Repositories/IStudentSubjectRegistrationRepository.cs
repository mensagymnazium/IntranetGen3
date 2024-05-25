using MensaGymnazium.IntranetGen3.Model;
using MensaGymnazium.IntranetGen3.Model.Security;

namespace MensaGymnazium.IntranetGen3.DataLayer.Repositories;

public partial interface IStudentSubjectRegistrationRepository
{
	public Task<List<StudentSubjectRegistration>> GetBySubjectAsync(int subjectId, CancellationToken cancellationToken = default);

	/// <returns>Active (not deleted) registrations made by a student for a subject</returns>
	Task<List<StudentSubjectRegistration>> GetActiveRegistrationsByStudentAsync(int studentId, CancellationToken cancellationToken = default);
	Task<int> CountMainRegistrationsForSubjectAsync(int subjectId, CancellationToken cancellationToken = default);

	///// <returns>Active (not deleted) registrations made by students for a subject. Key: <see cref="Student.Id"/>, Value: His registrations</returns>
	//Task<Dictionary<int, List<StudentSubjectRegistration>>> GetActiveRegistrationsForStudentsAsync(
	//	int[] studentIds,
	//	CancellationToken cancellationToken = default);
}
