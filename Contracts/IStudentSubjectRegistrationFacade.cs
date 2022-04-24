namespace MensaGymnazium.IntranetGen3.Contracts;

[ApiContract]
public interface IStudentSubjectRegistrationFacade
{
	Task<DataFragmentResult<StudentSubjectRegistrationDto>> GetStudentSubjectRegistrationListAsync(DataFragmentRequest<StudentSubjectRegistrationListQueryFilter> studentSubjectRegistrationListRequest, CancellationToken cancellationToken = default);
	Task<Dto<int>> CreateRegistrationAsync(StudentSubjectRegistrationDto model, CancellationToken cancellationToken = default);
	Task UpdateRegistrationAsync(StudentSubjectRegistrationDto model, CancellationToken cancellationToken = default);
}