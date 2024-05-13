using Havit.Collections;
using MensaGymnazium.IntranetGen3.Contracts;

namespace MensaGymnazium.IntranetGen3.DataLayer.Queries;

public interface ISubjectListQuery
{
	SubjectListQueryFilter Filter { get; set; }
	SortItem[] Sorting { get; set; }

	Task<DataFragmentResult<SubjectListItemDto>> GetDataFragmentResultAsync(int startIndex, int? count, CancellationToken cancellationToken = default);
}
