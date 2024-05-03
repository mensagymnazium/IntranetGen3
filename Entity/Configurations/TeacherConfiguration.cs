using Havit.Data.EntityFrameworkCore.Metadata;
using MensaGymnazium.IntranetGen3.Model.Security;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MensaGymnazium.IntranetGen3.Entity.Configurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
	public void Configure(EntityTypeBuilder<Teacher> builder)
	{
		builder.Property(t => t.SeededEntityId)
			.SuppressModelValidatorRule(ModelValidatorRule.OnlyForeignKeyPropertiesCanEndWithId);
	}
}