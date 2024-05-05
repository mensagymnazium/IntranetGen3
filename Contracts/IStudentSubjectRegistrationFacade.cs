using MensaGymnazium.IntranetGen3.Contracts.Security;

namespace MensaGymnazium.IntranetGen3.Contracts;

[ApiContract]
public interface IStudentSubjectRegistrationFacade
{
	Task<Dto<int>> CreateRegistrationAsync(StudentSubjectRegistrationDto registrationDto, CancellationToken cancellationToken = default);
	Task UpdateRegistrationAsync(StudentSubjectRegistrationDto registrationDto, CancellationToken cancellationToken = default);
	Task DeleteRegistrationAsync(Dto<int> registrationIdDto, CancellationToken cancellationToken = default);
	Task<DataFragmentResult<StudentSubjectRegistrationDto>> GetStudentSubjectRegistrationListAsync(DataFragmentRequest<StudentSubjectRegistrationListQueryFilter> studentSubjectRegistrationListRequest, CancellationToken cancellationToken = default);
	Task<List<StudentSubjectRegistrationDto>> GetAllRegistrationsOfCurrentStudentAsync(CancellationToken cancellationToken = default);  // Xopa: Todo? Change to query? It was too entangled with signing rules, but now it could be done? 
}