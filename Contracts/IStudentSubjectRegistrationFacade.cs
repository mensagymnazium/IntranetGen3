namespace MensaGymnazium.IntranetGen3.Contracts;

[ApiContract]
public interface IStudentSubjectRegistrationFacade
{
	Task<Dto<int>> CreateRegistrationAsync(StudentSubjectRegistrationDto registrationDto, CancellationToken cancellationToken = default);
	Task UpdateRegistrationAsync(StudentSubjectRegistrationDto registrationDto, CancellationToken cancellationToken = default);
	Task DeleteRegistrationAsync(Dto<int> registrationIdDto, CancellationToken cancellationToken = default);
	Task<DataFragmentResult<StudentSubjectRegistrationDto>> GetStudentSubjectActiveRegistrationsListAsync(DataFragmentRequest<StudentSubjectRegistrationListQueryFilter> studentSubjectRegistrationListRequest, CancellationToken cancellationToken = default);

	// Xopa: Todo? Rename this method to GetAllActiveRegistrationsOfCurrentStudentAsync (now I don't want to cause MERGE CONFLICTS for KL3P :D)
	Task<List<StudentSubjectRegistrationDto>> GetAllRegistrationsOfCurrentStudentAsync(CancellationToken cancellationToken = default);
}