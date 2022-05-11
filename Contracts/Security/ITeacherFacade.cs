using Havit.ComponentModel;

namespace MensaGymnazium.IntranetGen3.Contracts.Security;

[ApiContract]
public interface ITeacherFacade
{
	Task<List<TeacherReferenceDto>> GetAllTeacherReferencesAsync(CancellationToken cancellationToken = default);
	Task<List<TeacherDto>> GetAllAsync(CancellationToken cancellationToken = default);
	Task DeleteTeacherAsync(Dto<int> teacherId, CancellationToken cancellationToken = default);
	Task<Dto<int>> CreateTeacherAsync(TeacherDto teacherDto, CancellationToken cancellationToken = default);
	Task UpdateTeacherAsync(TeacherDto teacherDto, CancellationToken cancellationToken = default);
}
