using MensaGymnazium.IntranetGen3.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MensaGymnazium.IntranetGen3.Entity.Configurations;

public class EducationalAreaRelationConfiguration : IEntityTypeConfiguration<EducationalAreaRelation>
{
	public void Configure(EntityTypeBuilder<EducationalAreaRelation> builder)
	{
		builder.HasKey(str => new { str.SubjectId, EducationalAreaId = str.EducationalAreaId });

		builder
			.HasOne(ur => ur.Subject)
			.WithMany(u => u.EducationalAreaRelations)
			.HasForeignKey(ur => ur.SubjectId);
	}
}
