using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Havit.Diagnostics.Contracts;
using Havit.Extensions.DependencyInjection.Abstractions;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.Queries;
using Microsoft.AspNetCore.Authorization;

namespace MensaGymnazium.IntranetGen3.Facades
{
	[Service]
	[Authorize]
	public class SubjectFacade : ISubjectFacade
	{
		private readonly ISubjectListQuery subjectListQuery;

		public SubjectFacade(ISubjectListQuery subjectListQuery)
		{
			this.subjectListQuery = subjectListQuery;
		}

		public async Task<DataFragmentResult<SubjectListItemDto>> GetSubjectListAsync(DataFragmentRequest<SubjectListQueryFilter> subjectListRequest, CancellationToken cancellationToken = default)
		{
			Contract.Requires<ArgumentNullException>(subjectListRequest is not null, nameof(subjectListRequest));

			subjectListQuery.Filter = subjectListRequest.Filter;
			//subjectListQuery.Sorting = subjectListRequest.Sorting;

			return await subjectListQuery.GetDataFragmentAsync(subjectListRequest.StartIndex, subjectListRequest.Count, cancellationToken);
		}

		public Task DeleteSubjectAsync(Dto<int> subjectId, CancellationToken cancellationToken = default)
		{
			// TODO
			throw new NotImplementedException();
		}
	}
}
