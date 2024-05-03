using Havit.Data.EntityFrameworkCore.Metadata;
using MensaGymnazium.IntranetGen3.Model.Security;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MensaGymnazium.IntranetGen3.Entity.Configurations.Security;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.HasIndex(user => user.Oid).IsUnique(true);

		builder
			.HasOne(user => user.Student)
			.WithOne(student => student.User)
			.HasForeignKey<User>(user => user.StudentId)
			.OnDelete(DeleteBehavior.SetNull);

		builder
			.HasOne(user => user.Teacher)
			.WithOne(teacher => teacher.User)
			.HasForeignKey<User>(user => user.TeacherId)
			.OnDelete(DeleteBehavior.SetNull);
	}
}
