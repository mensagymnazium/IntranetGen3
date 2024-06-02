namespace MensaGymnazium.IntranetGen3.Contracts;

[ApiContract]
public interface ISubjectRegistrationProgressValidationFacade
{
	public Task<StudentRegistrationProgressDto> GetProgressOfCurrentStudentAsync(
		CancellationToken cancellationToken = default);

	public Task<List<StudentSubjectRegistrationProgressListItemDto>> GetProgressListAsync(
		StudentSubjectRegistrationProgressListFilter request,
		CancellationToken cancellationToken = default);
}