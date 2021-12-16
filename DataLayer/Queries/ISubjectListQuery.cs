using System.Threading;
using System.Threading.Tasks;
using MensaGymnazium.IntranetGen3.Contracts;

namespace MensaGymnazium.IntranetGen3.DataLayer.Queries
{
	public interface ISubjectListQuery
	{
		SubjectListQueryFilter Filter { get; set; }

		Task<DataFragmentResult<SubjectListItemDto>> GetDataFragmentAsync(int startIndex, int? count, CancellationToken cancellationToken = default);
	}
}