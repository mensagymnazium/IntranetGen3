using MensaGymnazium.IntranetGen3.Model.Security;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Teachers2023;

public class TeacherSeed : DataSeed<Teachers2023Profile>
{
	public override void SeedData()
	{
		var teachers = new[]
		{
			new Teacher() { SeededEntityId = 111, User = new User() { Email = "mensaforum.2023.001@mensagymnazium.cz", Name = "Jan Klenka" } },
			new Teacher() { SeededEntityId = 112, User = new User() { Email = "mensaforum.2023.010@mensagymnazium.cz", Name = "Zdeněk Pohlreich" } },
			new Teacher() { SeededEntityId = 113, User = new User() { Email = "mensaforum.2023.003@mensagymnazium.cz", Name = "Judr. Pavel Rychetský dr. h. c." } },
			new Teacher() { SeededEntityId = 121, User = new User() { Email = "mensaforum.2023.002@mensagymnazium.cz", Name = "Karel \"Kovy\" Kovář" } },
			new Teacher() { SeededEntityId = 122, User = new User() { Email = "mensaforum.2023.004@mensagymnazium.cz", Name = "Prof. Dr. David Storch, Ph.D." } },
			new Teacher() { SeededEntityId = 123, User = new User() { Email = "mensaforum.2023.005@mensagymnazium.cz", Name = "Mgr. Andrea Hudáková, Ph D. a tým" } },
			new Teacher() { SeededEntityId = 131, User = new User() { Email = "mensaforum.2023.006@mensagymnazium.cz", Name = "Tomáš Bublík" } },
			new Teacher() { SeededEntityId = 132, User = new User() { Email = "mensaforum.2023.007@mensagymnazium.cz", Name = "Prof. MUDr. Vladimír Beneš, DrSc." } },
			new Teacher() { SeededEntityId = 133, User = new User() { Email = "mensaforum.2023.008@mensagymnazium.cz", Name = "Mgr. et Mgr. Eliška Děcká, Ph.D." } },
			new Teacher() { SeededEntityId = 211, User = new User() { Email = "mensaforum.2023.009@mensagymnazium.cz", Name = "Prof. Ing. Jan Flusser, DrSc." } },
			new Teacher() { SeededEntityId = 212, User = new User() { Email = "mensaforum.2023.011@mensagymnazium.cz", Name = "Prof. JUDr. Bc. Tomáš Gřivna , Ph.D." } },
			new Teacher() { SeededEntityId = 213, User = new User() { Email = "mensaforum.2023.012@mensagymnazium.cz", Name = "Ing. Jan \"Pokáč\" Pokorný" } },
			new Teacher() { SeededEntityId = 221, User = new User() { Email = "mensaforum.2023.013@mensagymnazium.cz", Name = "Doc. Jiří Janák, Th.D." } },
			new Teacher() { SeededEntityId = 222, User = new User() { Email = "mensaforum.2023.014@mensagymnazium.cz", Name = "Bc. Jindřich Šídlo" } },
			new Teacher() { SeededEntityId = 223, User = new User() { Email = "mensaforum.2023.015@mensagymnazium.cz", Name = "Mgr. Adam Česlík" } },
			new Teacher() { SeededEntityId = 231, User = new User() { Email = "mensaforum.2023.016@mensagymnazium.cz", Name = "Ing. Mgr. Jan Romportl, Ph.D." } },
			new Teacher() { SeededEntityId = 232, User = new User() { Email = "mensaforum.2023.017@mensagymnazium.cz", Name = "Mudr. Zuzana Řeřichová" } },
			new Teacher() { SeededEntityId = 233, User = new User() { Email = "mensaforum.2023.018@mensagymnazium.cz", Name = "Kryštof Kohout a Sonoko Ashida" } },
			new Teacher() { SeededEntityId = 311, User = new User() { Email = "mensaforum.2023.019@mensagymnazium.cz", Name = "Mgr. David Navara" } },
			new Teacher() { SeededEntityId = 312, User = new User() { Email = "mensaforum.2023.020@mensagymnazium.cz", Name = "Johanna Nejedlová" } },
			new Teacher() { SeededEntityId = 313, User = new User() { Email = "mensaforum.2023.021@mensagymnazium.cz", Name = "Tereza Kostková, Dis." } },
			new Teacher() { SeededEntityId = 321, User = new User() { Email = "mensaforum.2023.022@mensagymnazium.cz", Name = "Ing. Marek Jílek" } },
			new Teacher() { SeededEntityId = 322, User = new User() { Email = "mensaforum.2023.023@mensagymnazium.cz", Name = "MgA. Václav Kalenda" } },
			new Teacher() { SeededEntityId = 323, User = new User() { Email = "mensaforum.2023.024@mensagymnazium.cz", Name = "Mgr. Petr Horký" } },
			new Teacher() { SeededEntityId = 331, User = new User() { Email = "mensaforum.2023.025@mensagymnazium.cz", Name = "Miloš Škorpil" } },
			new Teacher() { SeededEntityId = 332, User = new User() { Email = "mensaforum.2023.026@mensagymnazium.cz", Name = "Prof. MUDr. Cyril Höschl, DrSc." } },
			new Teacher() { SeededEntityId = 333, User = new User() { Email = "mensaforum.2023.027@mensagymnazium.cz", Name = "Phdr. Petra Procházková" } },
		};

		Seed(For(teachers).PairBy(teacher => teacher.SeededEntityId)
			.AndFor(teacher => teacher.User, userSeed => userSeed.PairBy(u => u.Email))
			.AfterSave(item => item.SeedEntity.User.TeacherId = item.PersistedEntity.Id)
		);
	}
}
