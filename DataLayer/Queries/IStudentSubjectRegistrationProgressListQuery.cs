using MensaGymnazium.IntranetGen3.Contracts;

namespace MensaGymnazium.IntranetGen3.DataLayer.Queries;

public interface IStudentSubjectRegistrationProgressListQuery
{
	StudentSubjectRegistrationProgressListFilter Filter { get; set; }

	Task<DataFragmentResult<StudentSubjectRegistrationProgressListItemDto>> GetDataFragmentResultAsync(int startIndex, int? count, CancellationToken cancellationToken = default);
}