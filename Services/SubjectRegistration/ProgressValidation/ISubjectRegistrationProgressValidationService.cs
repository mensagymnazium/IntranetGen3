
namespace MensaGymnazium.IntranetGen3.Services.SubjectRegistration.ProgressValidation;

/// <summary>
/// Responsible for determining, whether a student has fulfilled the registration criteria
/// for his grade. Gives back feedback about the progress.
/// </summary>
public interface ISubjectRegistrationProgressValidationService
{
	Task<StudentRegistrationProgress> GetRegistrationProgressOfStudentAsync(int studentId, CancellationToken cancellationToken = default);
	Task<> GetStudentRegistrationProgressListAsync(CancellationToken cancellationToken = default);
}