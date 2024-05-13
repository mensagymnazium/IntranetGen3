namespace MensaGymnazium.IntranetGen3.Contracts;

[ApiContract]
public interface ISubjectRegistrationProgressValidationFacade
{
	public Task<StudentRegistrationProgressDto> GetProgressOfCurrentStudentAsync();
	public Task<StudentRegistrationProgressDto> GetProgressOfStudentAsync(Dto<int> studentId);
}