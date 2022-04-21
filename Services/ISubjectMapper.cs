using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Model;

namespace MensaGymnazium.IntranetGen3.Services;

public interface ISubjectMapper
{
	Task<SubjectDto> MapToSubjectDtoAsync(Subject subject, CancellationToken cancellationToken = default);
	Task MapFromSubjectDtoAsync(SubjectDto subjectDto, Subject subject, CancellationToken cancellationToken = default);
}
