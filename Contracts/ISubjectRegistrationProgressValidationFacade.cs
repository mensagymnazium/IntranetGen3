namespace MensaGymnazium.IntranetGen3.Contracts;

[ApiContract]
public interface ISubjectRegistrationProgressValidationFacade
{
	Task<StudentRegistrationProgressDto> GetProgressOfCurrentStudentAsync(
		CancellationToken cancellationToken = default);

	Task<List<StudentSubjectRegistrationProgressListItemDto>> GetProgressListAsync(
		StudentSubjectRegistrationProgressListFilter request,
		CancellationToken cancellationToken = default);
}