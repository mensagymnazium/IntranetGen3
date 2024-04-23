using MensaGymnazium.IntranetGen3.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MensaGymnazium.IntranetGen3.Entity.Configurations;

public class GradeRegistrationCrietireaConfiguration : IEntityTypeConfiguration<GradeRegistrationCriteria>
{
	public void Configure(EntityTypeBuilder<GradeRegistrationCriteria> builder)
	{
		builder.Property(c => c.Id).ValueGeneratedNever();
	}
}