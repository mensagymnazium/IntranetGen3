using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MensaGymnazium.IntranetGen3.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MensaGymnazium.IntranetGen3.Entity.Configurations
{
	public class SubjectGradeRelationConfiguration : IEntityTypeConfiguration<SubjectGradeRelation>
	{
		public void Configure(EntityTypeBuilder<SubjectGradeRelation> builder)
		{
			builder.HasKey(str => new { str.SubjectId, str.GradeId });

			builder
				.HasOne(ur => ur.Subject)
				.WithMany(u => u.GradeRelations)
				.HasForeignKey(ur => ur.SubjectId);
		}
	}
}
