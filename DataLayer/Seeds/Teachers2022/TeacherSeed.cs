using MensaGymnazium.IntranetGen3.Model.Security;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Teachers2022;

public class TeacherSeed : DataSeed<Teachers2022Profile>
{
	public override void SeedData()
	{
		var teachers = new[]
		{
			new Teacher() { SeededEntityId = 111, User = new User() { Email = "mensaforum.2022.001@mensagymnazium.cz", Name = "Štěpán Krtička" } },
//			new Teacher() { SeededEntityId = 112, User = new User() { Email = "mensaforum.2022.010@mensagymnazium.cz", Name = "Placeholder Placeholder" } },
			new Teacher() { SeededEntityId = 113, User = new User() { Email = "mensaforum.2022.003@mensagymnazium.cz", Name = "Bratr Kliment" } },
//			new Teacher() { SeededEntityId = 121, User = new User() { Email = "mensaforum.2022.002@mensagymnazium.cz", Name = "Jakub Železný" } },
//			new Teacher() { SeededEntityId = 122, User = new User() { Email = "mensaforum.2022.004@mensagymnazium.cz", Name = "Halina Šimková" } },
//			new Teacher() { SeededEntityId = 123, User = new User() { Email = "mensaforum.2022.005@mensagymnazium.cz", Name = "Lenka Bradáčová" } },
//			new Teacher() { SeededEntityId = 131, User = new User() { Email = "mensaforum.2022.006@mensagymnazium.cz", Name = "Filip Turek" } },
//			new Teacher() { SeededEntityId = 132, User = new User() { Email = "mensaforum.2022.007@mensagymnazium.cz", Name = "Vladimír Strejček" } },
//			new Teacher() { SeededEntityId = 133, User = new User() { Email = "mensaforum.2022.008@mensagymnazium.cz", Name = "Jan Skryja" } },
//			new Teacher() { SeededEntityId = 211, User = new User() { Email = "mensaforum.2022.009@mensagymnazium.cz", Name = "Václav Jiřička" } },
//			new Teacher() { SeededEntityId = 212, User = new User() { Email = "mensaforum.2022.011@mensagymnazium.cz", Name = "Placeholder Placeholder" } },
//			new Teacher() { SeededEntityId = 213, User = new User() { Email = "mensaforum.2022.012@mensagymnazium.cz", Name = "Marek Pražan" } },
//			new Teacher() { SeededEntityId = 221, User = new User() { Email = "mensaforum.2022.013@mensagymnazium.cz", Name = "Jana Adámková" } },
//			new Teacher() { SeededEntityId = 222, User = new User() { Email = "mensaforum.2022.014@mensagymnazium.cz", Name = "Jakub Kroulík" } },
			new Teacher() { SeededEntityId = 223, User = new User() { Email = "mensaforum.2022.015@mensagymnazium.cz", Name = "Dana Drábová" } },
//			new Teacher() { SeededEntityId = 231, User = new User() { Email = "mensaforum.2022.016@mensagymnazium.cz", Name = "Filip Maleňák" } },
//			new Teacher() { SeededEntityId = 232, User = new User() { Email = "mensaforum.2022.017@mensagymnazium.cz", Name = "David Václavík" } },
//			new Teacher() { SeededEntityId = 233, User = new User() { Email = "mensaforum.2022.018@mensagymnazium.cz", Name = "Jakub Chomát" } },
//			new Teacher() { SeededEntityId = 311, User = new User() { Email = "mensaforum.2022.019@mensagymnazium.cz", Name = "Vladimír Vlk" } },
//			new Teacher() { SeededEntityId = 312, User = new User() { Email = "mensaforum.2022.020@mensagymnazium.cz", Name = "Ondřej Sokol" } },
//			new Teacher() { SeededEntityId = 313, User = new User() { Email = "mensaforum.2022.021@mensagymnazium.cz", Name = "Andrea Vytlačilová" } },
//			new Teacher() { SeededEntityId = 321, User = new User() { Email = "mensaforum.2022.022@mensagymnazium.cz", Name = "Robin Kaleta" } },
//			new Teacher() { SeededEntityId = 322, User = new User() { Email = "mensaforum.2022.023@mensagymnazium.cz", Name = "Jindřich Šídlo" } },
//			new Teacher() { SeededEntityId = 323, User = new User() { Email = "mensaforum.2022.024@mensagymnazium.cz", Name = "Jiří Šedivý" } },
			new Teacher() { SeededEntityId = 331, User = new User() { Email = "mensaforum.2022.025@mensagymnazium.cz", Name = "Ondřej Vrkoč" } },
//			new Teacher() { SeededEntityId = 332, User = new User() { Email = "mensaforum.2022.026@mensagymnazium.cz", Name = "Lukáš Pavlásek" } },
//			new Teacher() { SeededEntityId = 333, User = new User() { Email = "mensaforum.2022.027@mensagymnazium.cz", Name = "Amar Ibrahim" } },
		};

		Seed(For(teachers).PairBy(teacher => teacher.SeededEntityId)
			.AndFor(teacher => teacher.User, userSeed => userSeed.PairBy(u => u.Email))
			.AfterSave(item => item.SeedEntity.User.TeacherId = item.PersistedEntity.Id)
		);
	}
}
