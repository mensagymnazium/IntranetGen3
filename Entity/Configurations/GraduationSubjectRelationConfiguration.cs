using MensaGymnazium.IntranetGen3.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MensaGymnazium.IntranetGen3.Entity.Configurations;

public class GraduationSubjectRelationConfiguration : IEntityTypeConfiguration<GraduationSubjectRelation>
{
	public void Configure(EntityTypeBuilder<GraduationSubjectRelation> builder)
	{
		builder.HasKey(str => new { str.SubjectId, GraduationSubjectID = str.GraduationSubjectId });

		builder
			.HasOne(ur => ur.Subject)
			.WithMany(u => u.GraduationSubjectRelations)
			.HasForeignKey(ur => ur.SubjectId);
	}
}