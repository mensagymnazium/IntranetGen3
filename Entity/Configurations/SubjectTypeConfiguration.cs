using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MensaGymnazium.IntranetGen3.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MensaGymnazium.IntranetGen3.Entity.Configurations;

public class SubjectTypeConfiguration : IEntityTypeConfiguration<SubjectType>
{
	public void Configure(EntityTypeBuilder<SubjectType> builder)
	{
		builder.Property(st => st.Id).ValueGeneratedNever();
	}
}
