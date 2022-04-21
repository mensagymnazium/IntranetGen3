using Havit.ComponentModel;

namespace MensaGymnazium.IntranetGen3.Contracts.Security;

[ApiContract]
public interface ITeacherFacade
{
	Task<List<TeacherReferenceDto>> GetAllTeacherReferencesAsync(CancellationToken cancellationToken = default);
}
