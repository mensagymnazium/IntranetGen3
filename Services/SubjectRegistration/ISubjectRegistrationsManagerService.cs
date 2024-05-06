using MensaGymnazium.IntranetGen3.DataLayer.DataEntries.Common;
using MensaGymnazium.IntranetGen3.Model;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Services.SubjectRegistration;

public interface ISubjectRegistrationsManagerService
{
	/// <returns>Whether there can be a registration performed now. Based on dates inside <see cref="IApplicationSettingsEntries"/></returns>
	public bool IsRegistrationPeriodActive();

	// Xopa: Todo: Does registration conflict with other registrations? (time-wise)

	// Xopa: Todo: Did user already register this? (this would be implicitly solved by the top one, but it might make sense to be explicit?)

	/// <summary>
	/// Constructs the object <b>and inserts it using <see cref="IUnitOfWork.AddForInsert{TEntity}"/></b>
	/// </summary>
	/// <returns></returns>
	public StudentSubjectRegistration CreateNewSubjectRegistration(
		int studentId,
		int subjectId,
		StudentRegistrationType registrationType);

	/// <summary>
	/// Deletes a registration using <see cref="IUnitOfWork.AddForDelete{TEntity}"/>.
	/// </summary>
	/// <param name="registrationId">The registration to be canceled</param>
	/// <param name="callerStudentId">The student attempting to cancel. This is necessary to check, that the student is canceling his own registration and not some1 elses.</param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public Task CancelRegistrationAsync(int registrationId, int callerStudentId, CancellationToken cancellationToken = default);

	/// <returns>True, if the number of registrations for this subject reached the subject's capacity</returns>
	Task<bool> IsSubjectCapacityFullAsync(int subjectId, CancellationToken cancellationToken = default);

	/// <returns>True, if the student has already registered for this subject</returns>
	Task<bool> IsSubjectRegisteredForStudentAsync(int subjectId, int studentId, CancellationToken cancellationToken = default);

	/// <returns>True, if the students next year grade is within the subjects grade criteria</returns>
	Task<bool> IsStudentInAssignableGrade(int studentId, int subjectId, CancellationToken cancellationToken = default);
}
