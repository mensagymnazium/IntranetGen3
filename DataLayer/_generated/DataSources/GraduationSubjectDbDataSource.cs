using Havit.Data.EntityFrameworkCore;
using Havit.Data.EntityFrameworkCore.Patterns.DataSources;
using Havit.Data.EntityFrameworkCore.Patterns.SoftDeletes;

namespace MensaGymnazium.IntranetGen3.DataLayer.DataSources;

public class GraduationSubjectDbDataSource : DbDataSource<MensaGymnazium.IntranetGen3.Model.GraduationSubject>, IGraduationSubjectDataSource
{
	public GraduationSubjectDbDataSource(IDbContext dbContext, ISoftDeleteManager softDeleteManager)
		: base(dbContext, softDeleteManager)
	{
	}
}