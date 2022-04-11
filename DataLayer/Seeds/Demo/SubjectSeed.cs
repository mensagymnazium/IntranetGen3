using MensaGymnazium.IntranetGen3.DataLayer.Repositories.Security;
using MensaGymnazium.IntranetGen3.Model;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Demo;

public class SubjectSeed : DataSeed<DemoProfile>
{
	private readonly IUserRepository userRepository;

	public SubjectSeed(IUserRepository userRepository)
	{
		this.userRepository = userRepository;
	}

	public override void SeedData()
	{
		var users = userRepository.GetAll().Where(u => u.TeacherId is not null);

		var subjects = new[]
		{
			new Subject()
			{
				Capacity = 12,
				Name = "Tohle je stoprocentně reálnej předmět...",
				Description = "Reálnej seminář",
				ScheduleDayOfWeek = DayOfWeek.Monday,
				ScheduleSlotInDay = Primitives.ScheduleSlotInDay.Block5,
				CategoryId = (int)SubjectCategory.Entry.ExtensionSeminar,
				TypeRelations =
				{
					new SubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.ArtCulture },
					new SubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.Informatics },
				},
				TeacherRelations =
				{
					new SubjectTeacherRelation() { TeacherId = users.First(t => t.Name.Contains("Zimen")).TeacherId.Value },
					new SubjectTeacherRelation() { TeacherId = users.First(t => t.Name.Contains("Haken")).TeacherId.Value },
				},
				GradeRelations =
				{
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Kvarta },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Kvinta },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Sexta },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Septima },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Oktava },
				}
			},
			new Subject()
			{
				Capacity = 13,
				Name = "Brdek je bůh",
				Description = "Seminář pravdy",
				ScheduleDayOfWeek = DayOfWeek.Tuesday,
				ScheduleSlotInDay = Primitives.ScheduleSlotInDay.Block1,
				CategoryId = (int)SubjectCategory.Entry.SpecialisationSeminar,
				TypeRelations =
				{
					new SubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanSociety },
				},
				TeacherRelations =
				{
					new SubjectTeacherRelation() { TeacherId = users.First(t => t.Name.Contains("Brdek")).TeacherId.Value },
				},
				GradeRelations =
				{
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Sekunda },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Tercie },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Kvarta },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Kvinta },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Sexta },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Septima },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Oktava },
				}
			},
			new Subject()
			{
				Capacity = 9,
				Name = "Kepler",
				ScheduleDayOfWeek = DayOfWeek.Monday,
				Description = "Kepler je odpad",
				ScheduleSlotInDay = Primitives.ScheduleSlotInDay.Block4,
				CategoryId = (int)SubjectCategory.Entry.ExtensionSeminar,
				TypeRelations =
				{
					new SubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.ArtCulture },
				},
				TeacherRelations =
				{
					new SubjectTeacherRelation() { TeacherId = users.First(t => t.Name.Contains("Zimen")).TeacherId.Value },
					new SubjectTeacherRelation() { TeacherId = users.First(t => t.Name.Contains("Haken")).TeacherId.Value },
				},
				GradeRelations =
				{
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Sekunda },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Tercie },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Kvarta },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Kvinta },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Sexta },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Septima },
				}
			},
			new Subject()
			{
				Capacity = 12,
				Name = "MatPol",
				ScheduleDayOfWeek = DayOfWeek.Monday,
				Description = "Stovky zdarma :-)",
				ScheduleSlotInDay = Primitives.ScheduleSlotInDay.Block3,
				CategoryId = (int)SubjectCategory.Entry.GraduationSeminar,
				TypeRelations =
				{
					new SubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanSociety },
				},
				TeacherRelations =
				{
					new SubjectTeacherRelation() { TeacherId = users.First(t => t.Name.Contains("Svoboda")).TeacherId.Value },
				},
				GradeRelations =
				{
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Septima },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Oktava },
				}
			},
			new Subject()
			{
				Capacity = 12,
				Name = "MatBio",
				ScheduleDayOfWeek = DayOfWeek.Monday,
				Description = "Kdo by nechtěl předmět s Jurčákovou?",
				ScheduleSlotInDay = Primitives.ScheduleSlotInDay.Block2,
				CategoryId = (int)SubjectCategory.Entry.GraduationSeminar,
				TypeRelations =
				{
					new SubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanNature },
				},
				TeacherRelations =
				{
					new SubjectTeacherRelation() { TeacherId = users.First(t => t.Name.Contains("Jurčáková")).TeacherId.Value },
				},
				GradeRelations =
				{
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Septima },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Oktava },
				}
			},
			new Subject()
			{
				Capacity = 12,
				Name = "SocAJ",
				ScheduleDayOfWeek = DayOfWeek.Monday,
				Description = "Není vhodný pro slabší povahy",
				ScheduleSlotInDay = Primitives.ScheduleSlotInDay.Block4,
				CategoryId = (int)SubjectCategory.Entry.ForeignLanguage,
				TypeRelations =
				{
					new SubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanSociety },
					new SubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.LanguageCommunication },
				},
				TeacherRelations =
				{
					new SubjectTeacherRelation() { TeacherId = users.First(t => t.Name.Contains("Silva")).TeacherId.Value },
				},
				GradeRelations =
				{
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Kvinta },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Sexta },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Septima },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Oktava },
				}
			},
			new Subject()
			{
				Capacity = 12,
				Name = "ArdPrg",
				Description = "Kočí > Šebestík",
				ScheduleDayOfWeek = DayOfWeek.Thursday,
				ScheduleSlotInDay = Primitives.ScheduleSlotInDay.Block4,
				CategoryId = (int)SubjectCategory.Entry.SpecialisationSeminar,
				TypeRelations =
				{
					new SubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.Informatics },
					new SubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.MathApplication },
				},
				TeacherRelations =
				{
					new SubjectTeacherRelation() { TeacherId = users.First(t => t.Name.Contains("Šebestík")).TeacherId.Value },
				},
				GradeRelations =
				{
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Kvinta },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Sexta },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Septima },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Oktava },
				}
			},
			new Subject()
			{
				Capacity = 12,
				Name = "SemPrg II",
				Description = "Student = Levná pracovní síla",
				ScheduleDayOfWeek = DayOfWeek.Thursday,
				ScheduleSlotInDay = Primitives.ScheduleSlotInDay.Block5,
				CategoryId = (int)SubjectCategory.Entry.SpecialisationSeminar,
				TypeRelations =
				{
					new SubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.Informatics },
					new SubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.MathApplication },
				},
				TeacherRelations =
				{
					new SubjectTeacherRelation() { TeacherId = users.First(t => t.Name.Contains("Haken")).TeacherId.Value },
				},
				GradeRelations =
				{
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Tercie },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Kvarta },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Kvinta },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Sexta },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Septima },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Oktava },
				}
			},
			new Subject()
			{
				Capacity = 12,
				Name = "ŘímAJ",
				Description = "Stejně se to neotevře ;-)",
				ScheduleDayOfWeek = DayOfWeek.Wednesday,
				ScheduleSlotInDay = Primitives.ScheduleSlotInDay.Block5,
				CategoryId = (int)SubjectCategory.Entry.ForeignLanguage,
				TypeRelations =
				{
					new SubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.LanguageCommunication },
					new SubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanWork },
				},
				TeacherRelations =
				{
					new SubjectTeacherRelation() { TeacherId = users.First(t => t.Name.Contains("Parker")).TeacherId.Value },
				},
				GradeRelations =
				{
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Kvinta },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Sexta },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Septima },
					new SubjectGradeRelation() { GradeId = (int)GradeEntry.Oktava },
				}
			},
		};

		Seed(For(subjects).PairBy(subject => subject.Name)
			.AfterSave(item => item.SeedEntity.TeacherRelations.ForEach(tr => tr.SubjectId = item.PersistedEntity.Id))
			.AfterSave(item => item.SeedEntity.TypeRelations.ForEach(tr => tr.SubjectId = item.PersistedEntity.Id))
			.AfterSave(item => item.SeedEntity.GradeRelations.ForEach(gr => gr.SubjectId = item.PersistedEntity.Id))
			.AndForAll(subject => subject.TeacherRelations, configuration => configuration.PairBy(tr => tr.SubjectId, tr => tr.TeacherId))
			.AndForAll(subject => subject.TypeRelations, configuration => configuration.PairBy(tr => tr.SubjectId, tr => tr.SubjectTypeId))
			.AndForAll(subject => subject.GradeRelations, configuration => configuration.PairBy(gr => gr.SubjectId, gr => gr.GradeId))
		);
	}

	public override IEnumerable<Type> GetPrerequisiteDataSeeds()
	{
		yield return typeof(TeacherSeed);
	}
}
