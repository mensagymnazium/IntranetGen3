﻿// <auto-generated />
using System;
using MensaGymnazium.IntranetGen3.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MensaGymnazium.IntranetGen3.Entity.Migrations
{
    [DbContext(typeof(IntranetGen3DbContext))]
    partial class IntranetGen3DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Havit.Data.EntityFrameworkCore.Model.DataSeedVersion", b =>
                {
                    b.Property<string>("ProfileName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Version")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProfileName")
                        .HasName("PK_DataSeed");

                    b.ToTable("__DataSeed");
                });

            modelBuilder.Entity("MensaGymnazium.IntranetGen3.Model.Common.ApplicationSettings", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ApplicationSettings");
                });

            modelBuilder.Entity("MensaGymnazium.IntranetGen3.Model.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Symbol")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Grade");

                    b
                        .HasAnnotation("Caching-AllKeysEnabled", true)
                        .HasAnnotation("Caching-EntitiesEnabled", true);
                });

            modelBuilder.Entity("MensaGymnazium.IntranetGen3.Model.Security.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<int>("GradeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GradeId");

                    b.ToTable("Student");

                    b
                        .HasAnnotation("Caching-AllKeysEnabled", true)
                        .HasAnnotation("Caching-EntitiesEnabled", true);
                });

            modelBuilder.Entity("MensaGymnazium.IntranetGen3.Model.Security.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SeededEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Teacher");

                    b
                        .HasAnnotation("Caching-AllKeysEnabled", true)
                        .HasAnnotation("Caching-EntitiesEnabled", true);
                });

            modelBuilder.Entity("MensaGymnazium.IntranetGen3.Model.Security.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.Property<string>("Name")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<Guid?>("Oid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Oid")
                        .IsUnique()
                        .HasFilter("[Oid] IS NOT NULL");

                    b.HasIndex("StudentId")
                        .IsUnique()
                        .HasFilter("[StudentId] IS NOT NULL");

                    b.HasIndex("TeacherId")
                        .IsUnique()
                        .HasFilter("[TeacherId] IS NOT NULL");

                    b.ToTable("User");

                    b
                        .HasAnnotation("Caching-AllKeysEnabled", true)
                        .HasAnnotation("Caching-EntitiesEnabled", true);
                });

            modelBuilder.Entity("MensaGymnazium.IntranetGen3.Model.SigningRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GradeId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GradeId");

                    b.ToTable("SigningRule");
                });

            modelBuilder.Entity("MensaGymnazium.IntranetGen3.Model.SigningRuleSubjectCategoryRelation", b =>
                {
                    b.Property<int>("SigningRuleId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectCategoryId")
                        .HasColumnType("int");

                    b.HasKey("SigningRuleId", "SubjectCategoryId");

                    b.HasIndex("SubjectCategoryId");

                    b.ToTable("SigningRuleSubjectCategoryRelation");
                });

            modelBuilder.Entity("MensaGymnazium.IntranetGen3.Model.SigningRuleSubjectTypeRelation", b =>
                {
                    b.Property<int>("SigningRuleId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectTypeId")
                        .HasColumnType("int");

                    b.HasKey("SigningRuleId", "SubjectTypeId");

                    b.HasIndex("SubjectTypeId");

                    b.ToTable("SigningRuleSubjectTypeRelation");
                });

            modelBuilder.Entity("MensaGymnazium.IntranetGen3.Model.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ScheduleDayOfWeek")
                        .HasColumnType("int");

                    b.Property<int>("ScheduleSlotInDay")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Subject");

                    b
                        .HasAnnotation("Caching-AllKeysEnabled", true)
                        .HasAnnotation("Caching-EntitiesEnabled", true);
                });

            modelBuilder.Entity("MensaGymnazium.IntranetGen3.Model.SubjectCategory", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("SubjectCategory");

                    b
                        .HasAnnotation("Caching-AllKeysEnabled", true)
                        .HasAnnotation("Caching-EntitiesEnabled", true);
                });

            modelBuilder.Entity("MensaGymnazium.IntranetGen3.Model.SubjectGradeRelation", b =>
                {
                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("GradeId")
                        .HasColumnType("int");

                    b.HasKey("SubjectId", "GradeId");

                    b.HasIndex("GradeId");

                    b.ToTable("SubjectGradeRelation");
                });

            modelBuilder.Entity("MensaGymnazium.IntranetGen3.Model.SubjectTeacherRelation", b =>
                {
                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("SubjectId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("SubjectTeacherRelation");
                });

            modelBuilder.Entity("MensaGymnazium.IntranetGen3.Model.SubjectType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("SubjectType");

                    b
                        .HasAnnotation("Caching-AllKeysEnabled", true)
                        .HasAnnotation("Caching-EntitiesEnabled", true);
                });

            modelBuilder.Entity("MensaGymnazium.IntranetGen3.Model.SubjectTypeRelation", b =>
                {
                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectTypeId")
                        .HasColumnType("int");

                    b.HasKey("SubjectId", "SubjectTypeId");

                    b.HasIndex("SubjectTypeId");

                    b.ToTable("SubjectTypeRelation");

                    b
                        .HasAnnotation("Caching-AllKeysEnabled", true)
                        .HasAnnotation("Caching-EntitiesEnabled", true);
                });

            modelBuilder.Entity("MensaGymnazium.IntranetGen3.Model.Security.Student", b =>
                {
                    b.HasOne("MensaGymnazium.IntranetGen3.Model.Grade", "Grade")
                        .WithMany("Students")
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Grade");
                });

            modelBuilder.Entity("MensaGymnazium.IntranetGen3.Model.Security.User", b =>
                {
                    b.HasOne("MensaGymnazium.IntranetGen3.Model.Security.Student", "Student")
                        .WithOne("User")
                        .HasForeignKey("MensaGymnazium.IntranetGen3.Model.Security.User", "StudentId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("MensaGymnazium.IntranetGen3.Model.Security.Teacher", "Teacher")
                        .WithOne("User")
                        .HasForeignKey("MensaGymnazium.IntranetGen3.Model.Security.User", "TeacherId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("MensaGymnazium.IntranetGen3.Model.SigningRule", b =>
                {
                    b.HasOne("MensaGymnazium.IntranetGen3.Model.Grade", "Grade")
                        .WithMany("SigningRules")
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Grade");
                });

            modelBuilder.Entity("MensaGymnazium.IntranetGen3.Model.SigningRuleSubjectCategoryRelation", b =>
                {
                    b.HasOne("MensaGymnazium.IntranetGen3.Model.SigningRule", "SigningRule")
                        .WithMany("SubjectCategoryRelations")
                        .HasForeignKey("SigningRuleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MensaGymnazium.IntranetGen3.Model.SubjectCategory", "SubjectCategory")
                        .WithMany()
                        .HasForeignKey("SubjectCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SigningRule");

                    b.Navigation("SubjectCategory");
                });

            modelBuilder.Entity("MensaGymnazium.IntranetGen3.Model.SigningRuleSubjectTypeRelation", b =>
                {
                    b.HasOne("MensaGymnazium.IntranetGen3.Model.SigningRule", "SigningRule")
                        .WithMany("SubjectTypeRelations")
                        .HasForeignKey("SigningRuleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MensaGymnazium.IntranetGen3.Model.SubjectType", "SubjectType")
                        .WithMany()
                        .HasForeignKey("SubjectTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SigningRule");

                    b.Navigation("SubjectType");
                });

            modelBuilder.Entity("MensaGymnazium.IntranetGen3.Model.Subject", b =>
                {
                    b.HasOne("MensaGymnazium.IntranetGen3.Model.SubjectCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MensaGymnazium.IntranetGen3.Model.SubjectGradeRelation", b =>
                {
                    b.HasOne("MensaGymnazium.IntranetGen3.Model.Grade", "Grade")
                        .WithMany()
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MensaGymnazium.IntranetGen3.Model.Subject", "Subject")
                        .WithMany("GradeRelations")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Grade");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("MensaGymnazium.IntranetGen3.Model.SubjectTeacherRelation", b =>
                {
                    b.HasOne("MensaGymnazium.IntranetGen3.Model.Subject", "Subject")
                        .WithMany("TeacherRelations")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MensaGymnazium.IntranetGen3.Model.Security.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("MensaGymnazium.IntranetGen3.Model.SubjectTypeRelation", b =>
                {
                    b.HasOne("MensaGymnazium.IntranetGen3.Model.Subject", "Subject")
                        .WithMany("TypeRelations")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MensaGymnazium.IntranetGen3.Model.SubjectType", "SubjectType")
                        .WithMany()
                        .HasForeignKey("SubjectTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Subject");

                    b.Navigation("SubjectType");
                });

            modelBuilder.Entity("MensaGymnazium.IntranetGen3.Model.Grade", b =>
                {
                    b.Navigation("SigningRules");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("MensaGymnazium.IntranetGen3.Model.Security.Student", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("MensaGymnazium.IntranetGen3.Model.Security.Teacher", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("MensaGymnazium.IntranetGen3.Model.SigningRule", b =>
                {
                    b.Navigation("SubjectCategoryRelations");

                    b.Navigation("SubjectTypeRelations");
                });

            modelBuilder.Entity("MensaGymnazium.IntranetGen3.Model.Subject", b =>
                {
                    b.Navigation("GradeRelations");

                    b.Navigation("TeacherRelations");

                    b.Navigation("TypeRelations");
                });
#pragma warning restore 612, 618
        }
    }
}
