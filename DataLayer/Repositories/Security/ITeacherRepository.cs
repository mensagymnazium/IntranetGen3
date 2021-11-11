using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Havit.Data.Patterns.Repositories;
using MensaGymnazium.IntranetGen3.Model.Security;

namespace MensaGymnazium.IntranetGen3.DataLayer.Repositories.Security
{
	public partial interface ITeacherRepository
	{
		Task<List<Teacher>> GetAllIncludingDeletedAsync(CancellationToken cancellationToken = default);
	}
}