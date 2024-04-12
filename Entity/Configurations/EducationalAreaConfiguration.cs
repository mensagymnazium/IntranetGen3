using MensaGymnazium.IntranetGen3.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MensaGymnazium.IntranetGen3.Entity.Configurations;

public class EducationalAreaConfiguration : IEntityTypeConfiguration<EducationalArea>
{
	public void Configure(EntityTypeBuilder<EducationalArea> builder)
	{
		builder.Property(st => st.Id).ValueGeneratedNever();
	}
}
