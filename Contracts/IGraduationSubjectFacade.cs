using Havit.ComponentModel;

namespace MensaGymnazium.IntranetGen3.Contracts;

[ApiContract]
public interface IGraduationSubjectFacade
{
	Task<List<GraduationSubjectDto>> GetAllGraduationSubjectsAsync(CancellationToken cancellationToken = default);
}