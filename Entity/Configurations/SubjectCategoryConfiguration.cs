using MensaGymnazium.IntranetGen3.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MensaGymnazium.IntranetGen3.Entity.Configurations;

public class SubjectCategoryConfiguration : IEntityTypeConfiguration<SubjectCategory>
{
	public void Configure(EntityTypeBuilder<SubjectCategory> builder)
	{
		builder.Property(sc => sc.Id).ValueGeneratedNever();
	}
}
