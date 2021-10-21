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
	public class SubjectCategoryConfiguration : IEntityTypeConfiguration<SubjectCategory>
	{
		public void Configure(EntityTypeBuilder<SubjectCategory> builder)
		{
			builder.Property(sc => sc.Id).ValueGeneratedNever();
		}
	}
}
