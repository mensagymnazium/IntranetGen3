using Havit.ComponentModel;

namespace MensaGymnazium.IntranetGen3.Contracts.Security;

[ApiContract]
public interface ITeacherFacade
{
	Task<List<TeacherReferenceDto>> GetAllTeacherReferencesAsync(CancellationToken cancellationToken = default);
	Task<TeacherDto> GetTeacherDetailAsync(Dto<int> teacherIdDto, CancellationToken cancellationToken = default);
	Task UpdateTeacherAsync(TeacherDto teacherDto, CancellationToken cancellationToken = default);
}
