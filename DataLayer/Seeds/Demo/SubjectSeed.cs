using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Havit.Data.Patterns.DataSeeds;
using MensaGymnazium.IntranetGen3.Model;


namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Demo
{
	public class SubjectSeed : DataSeed<DemoProfile>
	{
		public override void SeedData()
		{
			var subjects = new[]
			{
				new Subject()
				{
					Capacity = 12,
					Name = "Tohle je stoprocentně reálnej předmět...",
					ScheduleDayOfWeek = DayOfWeek.Monday,
					Description = "Reálnej seminář",
					ScheduleSlotInDay = Primitives.ScheduleSlotInDay.Block5
				},
				new Subject()
				{
					Capacity = 13,
					Name = "Brdek je bůh.",
					ScheduleDayOfWeek = DayOfWeek.Monday,
					Description = "Seminář pravdy",
					ScheduleSlotInDay = Primitives.ScheduleSlotInDay.Block1
				},
				new Subject()
				{
					Capacity = 9,
					Name = "Kepler",
					ScheduleDayOfWeek = DayOfWeek.Monday,
					Description = "Kepler je odpad",
					ScheduleSlotInDay = Primitives.ScheduleSlotInDay.Block4
				},
				new Subject()
				{
					Capacity = 12,
					Name = "MatPol",
					ScheduleDayOfWeek = DayOfWeek.Monday,
					Description = "Stovky zdarma :-)",
					ScheduleSlotInDay = Primitives.ScheduleSlotInDay.Block3
				},
				new Subject()
				{
					Capacity = 12,
					Name = "MatBio",
					ScheduleDayOfWeek = DayOfWeek.Monday,
					Description = "Kdo by nechtěl předmět s Jurčákovou?",
					ScheduleSlotInDay = Primitives.ScheduleSlotInDay.Block2
				},
				new Subject()
				{
					Capacity = 12,
					Name = "SocAJ",
					ScheduleDayOfWeek = DayOfWeek.Monday,
					Description = "Není vhodný pro slabší povahy",
					ScheduleSlotInDay = Primitives.ScheduleSlotInDay.Block4
				},
				new Subject()
				{
					Capacity = 12,
					Name = "ArdPrg",
					ScheduleDayOfWeek = DayOfWeek.Monday,
					Description = "Kočí > Šebestík",
					ScheduleSlotInDay = Primitives.ScheduleSlotInDay.Block4
				},
				new Subject()
				{
					Capacity = 12,
					Name = "SemPrg II",
					ScheduleDayOfWeek = DayOfWeek.Monday,
					Description = "Student = Levná pracovní síla",
					ScheduleSlotInDay = Primitives.ScheduleSlotInDay.Block5
				},
				new Subject()
				{
					Capacity = 12,
					Name = "ŘímAJ",
					ScheduleDayOfWeek = DayOfWeek.Monday,
					Description = "Stejně se to neotevře ;-)",
					ScheduleSlotInDay = Primitives.ScheduleSlotInDay.Block5
				},
			};
			Seed(For(subjects)
				.PairBy(subject => subject.Name));
				//.AndFor(user => user.User, teacher => teacher.PairBy(t => t.Email))
				//.AfterSave(item => item.SeedEntity.User.TeacherId = item.PersistedEntity.Id));
		}
	}
}