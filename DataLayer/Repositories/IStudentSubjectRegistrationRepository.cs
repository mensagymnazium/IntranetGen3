using MensaGymnazium.IntranetGen3.Model;

namespace MensaGymnazium.IntranetGen3.DataLayer.Repositories;

public partial interface IStudentSubjectRegistrationRepository
{
	public Task<List<StudentSubjectRegistration>> GetBySubjectAsync(
		int id,
		CancellationToken cancellationToken = default);

	//public Task<long> CountBySubjectAndTypeAsync(int subjectId, StudentRegistrationType type, CancellationToken cancellationToken = default);

	//public Task<List<StudentSubjectRegistration>> GetByStudentAndTimeAsync(int studentId, DayOfWeek day, ScheduleSlotInDay slot, CancellationToken cancellationToken = default);
	Task<List<StudentSubjectRegistration>> GetRegistrationsByStudent(int studentId);
	Task<int> CountMainRegistrationsForSubjectAsync(int subjectId);
}
