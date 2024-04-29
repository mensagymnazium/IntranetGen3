using MensaGymnazium.IntranetGen3.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MensaGymnazium.IntranetGen3.Entity.Configurations;

public class GraduationSubjectConfiguration : IEntityTypeConfiguration<GraduationSubject>
{
	public void Configure(EntityTypeBuilder<GraduationSubject> builder)
	{
		builder.Property(st => st.Id).ValueGeneratedNever();
	}
}