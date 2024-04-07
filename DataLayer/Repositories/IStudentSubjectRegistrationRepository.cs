using MensaGymnazium.IntranetGen3.Model;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.DataLayer.Repositories;

public partial interface IStudentSubjectRegistrationRepository
{
	public Task<StudentSubjectRegistration?> GetByStudentForSubject(
		int studentId,
		int subjectId,
		CancellationToken cancellationToken);
	public Task<List<StudentSubjectRegistration>> GetBySubjectAsync(
		int id,
		CancellationToken cancellationToken = default);

	//public Task<long> CountBySubjectAndTypeAsync(int subjectId, StudentRegistrationType type, CancellationToken cancellationToken = default);

	//public Task<List<StudentSubjectRegistration>> GetByStudentAndTimeAsync(int studentId, DayOfWeek day, ScheduleSlotInDay slot, CancellationToken cancellationToken = default);
}
