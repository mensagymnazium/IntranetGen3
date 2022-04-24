using MensaGymnazium.IntranetGen3.Contracts;

namespace MensaGymnazium.IntranetGen3.DataLayer.Queries;

public interface IStudentWithSigningRuleListQuery
{
	StudentWithSigningRuleListQueryFilter Filter { get; set; }
	SortItem[] Sorting { get; set; }

	Task<DataFragmentResult<StudentWithSigningRuleListItemDto>> GetDataFragmentAsync(int startIndex, int? count, CancellationToken cancellationToken = default);
}