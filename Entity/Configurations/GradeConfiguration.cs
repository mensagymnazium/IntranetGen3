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
	public class GradeConfiguration : IEntityTypeConfiguration<Grade>
	{
		public void Configure(EntityTypeBuilder<Grade> builder)
		{
			builder.Property(g => g.Id).ValueGeneratedNever();
		}
	}
}
