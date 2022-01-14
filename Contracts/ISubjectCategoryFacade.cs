using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Havit.ComponentModel;
using MensaGymnazium.IntranetGen3.Contracts.Security;

namespace MensaGymnazium.IntranetGen3.Contracts
{
	[ApiContract]
	public interface ISubjectCategoryFacade
	{
		Task<List<SubjectCategoryDto>> GetAllSubjectCategoriesAsync(CancellationToken cancellationToken = default);
	}
}
