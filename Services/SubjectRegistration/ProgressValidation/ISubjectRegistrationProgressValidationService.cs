using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Model.Security;

namespace MensaGymnazium.IntranetGen3.Services.SubjectRegistration.ProgressValidation;

/// <summary>
/// Responsible for determining, whether a student has fulfilled the registration criteria
/// for his grade. Gives back feedback about the progress.
/// </summary>
public interface ISubjectRegistrationProgressValidationService
{
	/// <returns>The progress of a single student</returns>
	Task<StudentRegistrationProgress> GetRegistrationProgressOfStudentAsync(
		int studentId,
		CancellationToken cancellationToken = default);

	/// <returns>Progress of multiple students. Key: <see cref="Student.Id"/>, Value: His progress</returns>
	Task<Dictionary<int, StudentRegistrationProgress>> GetRegistrationProgressOfAllStudentsAsync(
		StudentSubjectRegistrationProgressListFilter filter,
		CancellationToken cancellationToken = default);
}