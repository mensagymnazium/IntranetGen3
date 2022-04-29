using MensaGymnazium.IntranetGen3.Model.Security;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Teachers2022;

public class TeacherSeed : DataSeed<Teachers2022Profile>
{
	public override void SeedData()
	{
		var teachers = new[]
		{
			new Teacher() { SeededEntityId = 111, User = new User() { Email = "Martin.Truksa@mensagymnazium.cz", Name = "Placeholder Placeholder" } },
			new Teacher() { SeededEntityId = 121, User = new User() { Email = "Jakub.Železný@mensagymnazium.cz", Name = "Jakub Železný" } },
			new Teacher() { SeededEntityId = 113, User = new User() { Email = "Martin.Truksa@mensagymnazium.cz", Name = "Placeholder Placeholder" } },
			new Teacher() { SeededEntityId = 122, User = new User() { Email = "Halina.Šimková@mensagymnazium.cz", Name = "Halina Šimková" } },
			new Teacher() { SeededEntityId = 123, User = new User() { Email = "Lenka.Bradáčová@mensagymnazium.cz", Name = "Lenka Bradáčová" } },
			new Teacher() { SeededEntityId = 131, User = new User() { Email = "Filip.Turek@mensagymnazium.cz", Name = "Filip Turek" } },
			new Teacher() { SeededEntityId = 132, User = new User() { Email = "Vladimír.Strejček@mensagymnazium.cz", Name = "Vladimír Strejček" } },
			new Teacher() { SeededEntityId = 133, User = new User() { Email = "Jan.Skryja@mensagymnazium.cz", Name = "Jan Skryja" } },
			new Teacher() { SeededEntityId = 211, User = new User() { Email = "Václav.Jiřička@mensagymnazium.cz", Name = "Václav Jiřička" } },
			new Teacher() { SeededEntityId = 112, User = new User() { Email = "Martin.Truksa@mensagymnazium.cz", Name = "Placeholder Placeholder" } },
			new Teacher() { SeededEntityId = 212, User = new User() { Email = "Martin.Truksa@mensagymnazium.cz", Name = "Placeholder Placeholder" } },
			new Teacher() { SeededEntityId = 213, User = new User() { Email = "Marek.Pražan@mensagymnazium.cz", Name = "Marek Pražan" } },
			new Teacher() { SeededEntityId = 221, User = new User() { Email = "Jana.Adámková@mensagymnazium.cz", Name = "Jana Adámková" } },
			new Teacher() { SeededEntityId = 222, User = new User() { Email = "Jakub.Kroulík@mensagymnazium.cz", Name = "Jakub Kroulík" } },
			new Teacher() { SeededEntityId = 223, User = new User() { Email = "Martin.Truksa@mensagymnazium.cz", Name = "Placeholder Placeholder" } },
			new Teacher() { SeededEntityId = 231, User = new User() { Email = "Filip.Maleňák@mensagymnazium.cz", Name = "Filip Maleňák" } },
			new Teacher() { SeededEntityId = 232, User = new User() { Email = "David.Václavík@mensagymnazium.cz", Name = "David Václavík" } },
			new Teacher() { SeededEntityId = 233, User = new User() { Email = "Jakub.Chomát@mensagymnazium.cz", Name = "Jakub Chomát" } },
			new Teacher() { SeededEntityId = 311, User = new User() { Email = "Vladimír.Vlk@mensagymnazium.cz", Name = "Vladimír Vlk" } },
			new Teacher() { SeededEntityId = 312, User = new User() { Email = "Ondřej.Sokol@mensagymnazium.cz", Name = "Ondřej Sokol" } },
			new Teacher() { SeededEntityId = 313, User = new User() { Email = "Andrea.Vytlačilová@mensagymnazium.cz", Name = "Andrea Vytlačilová" } },
			new Teacher() { SeededEntityId = 321, User = new User() { Email = "Robin.Kaleta@mensagymnazium.cz", Name = "Robin Kaleta" } },
			new Teacher() { SeededEntityId = 322, User = new User() { Email = "Jindřich.Šídlo@mensagymnazium.cz", Name = "Jindřich Šídlo" } },
			new Teacher() { SeededEntityId = 323, User = new User() { Email = "Jiří.Šedivý@mensagymnazium.cz", Name = "Jiří Šedivý" } },
			new Teacher() { SeededEntityId = 331, User = new User() { Email = "Martin.Truksa@mensagymnazium.cz", Name = "Placeholder Placeholder" } },
			new Teacher() { SeededEntityId = 332, User = new User() { Email = "Lukáš.Pavlásek@mensagymnazium.cz", Name = "Lukáš Pavlásek" } },
			new Teacher() { SeededEntityId = 333, User = new User() { Email = "Amar.Ibrahim@mensagymnazium.cz", Name = "Amar Ibrahim" } },
		};

		Seed(For(teachers).PairBy(teacher => teacher.SeededEntityId)
			.AndFor(teacher => teacher.User, userSeed => userSeed.PairBy(u => u.Email))
			.AfterSave(item => item.SeedEntity.User.TeacherId = item.PersistedEntity.Id)
		);
	}
}
