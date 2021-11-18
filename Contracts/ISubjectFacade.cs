using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Havit.ComponentModel;

namespace MensaGymnazium.IntranetGen3.Contracts
{
	[ApiContract]
	public interface ISubjectFacade
	{
		Task<DataFragmentResult<SubjectListItemDto>> GetSubjectListAsync(DataFragmentRequest<SubjectListQueryFilter> subjectListRequest, CancellationToken cancellationToken = default);
		Task DeleteSubjectAsync(Dto<int> subjectId, CancellationToken cancellationToken = default);
	}
}
