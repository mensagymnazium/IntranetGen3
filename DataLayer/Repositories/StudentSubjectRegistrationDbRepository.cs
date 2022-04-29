using MensaGymnazium.IntranetGen3.Model;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.DataLayer.Repositories;

public partial class StudentSubjectRegistrationDbRepository : IStudentSubjectRegistrationRepository
{
	public Task<List<StudentSubjectRegistration>> GetBySubjectAsync(int subjectId, CancellationToken cancellationToken = default)
	{
		return Data.Where(ssr => ssr.SubjectId == subjectId).ToListAsync(cancellationToken);
	}

	public Task<long> CountBySubjectAndTypeAsync(int subjectId, StudentRegistrationType type, CancellationToken cancellationToken = default)
	{
		return Data.Where(ssr => ssr.SubjectId == subjectId && ssr.RegistrationType == type).LongCountAsync();
	}

	public Task<List<StudentSubjectRegistration>> GetByStudentAndTimeAsync(int studentId, DayOfWeek day, ScheduleSlotInDay slot, CancellationToken cancellationToken = default)
	{
		return Data.Where(ssr =>
			ssr.StudentId == studentId &&
			ssr.Subject.ScheduleDayOfWeek == day &&
			ssr.Subject.ScheduleSlotInDay == slot
		).Include(ssr => ssr.Subject).ToListAsync();
	}
}
