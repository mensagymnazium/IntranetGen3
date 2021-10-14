using MensaGymnazium.IntranetGen3.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MensaGymnazium.IntranetGen3.Entity.Configurations.Security
{
	public class StudentConfiguration : IEntityTypeConfiguration<Student>
	{
		public void Configure(EntityTypeBuilder<Student> builder)
		{
			builder
				.HasOne(student => student.Grade)
				.WithMany(grade => grade.Students)
				.HasForeignKey(student => student.GradeId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
