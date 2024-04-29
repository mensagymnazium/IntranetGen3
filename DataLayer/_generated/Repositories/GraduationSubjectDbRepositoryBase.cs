using Havit.Data.EntityFrameworkCore;
using Havit.Data.EntityFrameworkCore.Patterns.Caching;
using Havit.Data.EntityFrameworkCore.Patterns.Repositories;
using Havit.Data.EntityFrameworkCore.Patterns.SoftDeletes;
using Havit.Data.Patterns.DataEntries;
using Havit.Data.Patterns.DataLoaders;
using Havit.Data.Patterns.Infrastructure;

namespace MensaGymnazium.IntranetGen3.DataLayer.Repositories;

public abstract class GraduationSubjectDbRepositoryBase : DbRepository<MensaGymnazium.IntranetGen3.Model.GraduationSubject>
{
	protected GraduationSubjectDbRepositoryBase(IDbContext dbContext, MensaGymnazium.IntranetGen3.DataLayer.DataSources.IGraduationSubjectDataSource dataSource, IEntityKeyAccessor<MensaGymnazium.IntranetGen3.Model.GraduationSubject, int> entityKeyAccessor, IDataLoader dataLoader, ISoftDeleteManager softDeleteManager, IEntityCacheManager entityCacheManager)
		: base(dbContext, dataSource, entityKeyAccessor, dataLoader, softDeleteManager, entityCacheManager)
	{
	}
}