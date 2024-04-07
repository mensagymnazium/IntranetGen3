namespace MensaGymnazium.IntranetGen3.Contracts;

[ApiContract]
public interface ISubjectRegistrationsManagerFacade
{
	/// <summary>
	/// Returns the users registration for a subject
	/// // TODO: Change to query that can be cached inside data store
	/// </summary>
	/// <param name="subjectId"></param>
	/// <param name="cancellationToken"></param>
	/// <returns>Always returns a registration. If there is no registration, it returns the DTO with no data set</returns>
	Task<StudentSubjectRegistrationDto> GetCurrentUserRegistrationForSubject(Dto<int> subjectId, CancellationToken cancellationToken = default);
	Task CancelRegistrationAsync(Dto<int> studentSubjectRegistrationId, CancellationToken cancellationToken = default);
	Task CreateRegistrationAsync(StudentSubjectRegistrationCreateDto studentSubjectRegistrationCreateDto, CancellationToken cancellationToken = default);
}
