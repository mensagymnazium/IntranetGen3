namespace MensaGymnazium.IntranetGen3.Contracts.Security;

[ApiContract]
public interface IStudentFacade
{
	Task<List<StudentReferenceDto>> GetAllStudentReferencesAsync(CancellationToken cancellationToken = default);
}