using Havit.ComponentModel;

namespace MensaGymnazium.IntranetGen3.Contracts;

[ApiContract]
public interface ISubjectFacade
{
	Task<DataFragmentResult<SubjectListItemDto>> GetSubjectListAsync(DataFragmentRequest<SubjectListQueryFilter> subjectListRequest, CancellationToken cancellationToken = default);
	Task DeleteSubjectAsync(Dto<int> subjectId, CancellationToken cancellationToken = default);
	Task<Dto<int>> CreateSubjectAsync(SubjectDto subjectEditDto, CancellationToken cancellationToken = default);
	Task UpdateSubjectAsync(SubjectDto subjectEditDto, CancellationToken cancellationToken = default);
	Task<SubjectDto> GetSubjectDetailAsync(Dto<int> subjectIdDto, CancellationToken cancellationToken = default);
}
