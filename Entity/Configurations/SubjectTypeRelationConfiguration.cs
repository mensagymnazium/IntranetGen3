using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MensaGymnazium.IntranetGen3.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MensaGymnazium.IntranetGen3.Entity.Configurations;

public class SubjectTypeRelationConfiguration : IEntityTypeConfiguration<SubjectTypeRelation>
{
	public void Configure(EntityTypeBuilder<SubjectTypeRelation> builder)
	{
		builder.HasKey(str => new { str.SubjectId, str.SubjectTypeId });

		builder
			.HasOne(ur => ur.Subject)
			.WithMany(u => u.TypeRelations)
			.HasForeignKey(ur => ur.SubjectId);
	}
}
