using MensaGymnazium.IntranetGen3.Model;

namespace MensaGymnazium.IntranetGen3.DataLayer.Repositories;

public partial class StudentSubjectRegistrationDbRepository : IStudentSubjectRegistrationRepository
{
	public Task<List<StudentSubjectRegistration>> GetBySubjectAsync(int subjectId, CancellationToken cancellationToken = default)
	{
		return Data.Where(ssr => ssr.SubjectId == subjectId).ToListAsync(cancellationToken);
	}
}
