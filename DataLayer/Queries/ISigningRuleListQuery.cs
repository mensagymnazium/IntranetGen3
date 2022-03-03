using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MensaGymnazium.IntranetGen3.Contracts;

namespace MensaGymnazium.IntranetGen3.DataLayer.Queries
{
	public interface ISigningRuleListQuery
	{
		SigningRuleListQueryFilter Filter { get; set; }

		Task<DataFragmentResult<SigningRuleDto>> GetDataFragmentAsync(int startIndex, int? count, CancellationToken cancellationToken = default);
	}
}
