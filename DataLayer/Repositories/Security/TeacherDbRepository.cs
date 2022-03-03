using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Havit.Data.EntityFrameworkCore;
using Havit.Data.EntityFrameworkCore.Patterns.Repositories;
using Havit.Data.EntityFrameworkCore.Patterns.SoftDeletes;
using Havit.Data.Patterns.DataEntries;
using Havit.Data.Patterns.DataLoaders;
using MensaGymnazium.IntranetGen3.Model.Security;
using Microsoft.EntityFrameworkCore;

namespace MensaGymnazium.IntranetGen3.DataLayer.Repositories.Security
{
	public partial class TeacherDbRepository : ITeacherRepository
	{
		public async Task<List<Teacher>> GetAllIncludingDeletedAsync(CancellationToken cancellationToken = default)
		{
			return await DataIncludingDeleted.Include(t => t.User).ToListAsync(cancellationToken);
		}

		protected override IEnumerable<Expression<Func<Teacher, object>>> GetLoadReferences()
		{
			yield return t => t.User;
		}
	}
}