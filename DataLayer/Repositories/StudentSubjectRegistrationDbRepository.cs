using MensaGymnazium.IntranetGen3.Model;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.DataLayer.Repositories;

public partial class StudentSubjectRegistrationDbRepository : IStudentSubjectRegistrationRepository
{
	public Task<List<StudentSubjectRegistration>> GetBySubjectAsync(int subjectId, CancellationToken cancellationToken = default)
	{
		return Data.Where(ssr => ssr.SubjectId == subjectId).ToListAsync(cancellationToken);
	}

	public Task<List<StudentSubjectRegistration>> GetRegistrationsByStudentAsync(int studentId, CancellationToken cancellationToken = default)
	{
		return Data
			.Include(ssr => ssr.Subject)
			.ThenInclude(s => s.EducationalAreaRelations)
			.ThenInclude(r => r.EducationalArea)
			.Include(ssr => ssr.Subject.Category)
			.Where(ssr => ssr.StudentId == studentId)
			.ToListAsync(cancellationToken);
	}

	public async Task<int> CountMainRegistrationsForSubjectAsync(int subjectId, CancellationToken cancellationToken = default)
	{
		return await Data.CountAsync(ssr => (ssr.SubjectId == subjectId) && (ssr.RegistrationType == StudentRegistrationType.Main), cancellationToken);
	}
}
