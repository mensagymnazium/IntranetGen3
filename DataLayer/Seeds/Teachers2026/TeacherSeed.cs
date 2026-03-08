using MensaGymnazium.IntranetGen3.Model.Security;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Teachers2026;

public class TeacherSeed : DataSeed<Teachers2026Profile>
{
	public override void SeedData()
	{
		var teachers = new[]
		{
			new Teacher() { SeededEntityId = 111, User = new User() { Email = "mensaforum.2026.001@mensagymnazium.cz", Name = "Lukáš Březina" } },
			new Teacher() { SeededEntityId = 112, User = new User() { Email = "mensaforum.2026.002@mensagymnazium.cz", Name = "Jan Rak" } },
			new Teacher() { SeededEntityId = 113, User = new User() { Email = "mensaforum.2026.003@mensagymnazium.cz", Name = "Jiří Došlý" } },
			new Teacher() { SeededEntityId = 121, User = new User() { Email = "mensaforum.2026.004@mensagymnazium.cz", Name = "Jiří Hynek" } },
			new Teacher() { SeededEntityId = 122, User = new User() { Email = "mensaforum.2026.005@mensagymnazium.cz", Name = "Antonín Peták" } },
			new Teacher() { SeededEntityId = 123, User = new User() { Email = "mensaforum.2026.006@mensagymnazium.cz", Name = "Petra Klabouchová" } },
			new Teacher() { SeededEntityId = 131, User = new User() { Email = "mensaforum.2026.007@mensagymnazium.cz", Name = "Patrik Koláček a Michal Flekač" } },
			new Teacher() { SeededEntityId = 132, User = new User() { Email = "mensaforum.2026.008@mensagymnazium.cz", Name = "Pivovar Staropramen" } },
			new Teacher() { SeededEntityId = 133, User = new User() { Email = "mensaforum.2026.009@mensagymnazium.cz", Name = "Eva Kudová" } },
			new Teacher() { SeededEntityId = 211, User = new User() { Email = "mensaforum.2026.010@mensagymnazium.cz", Name = "Dominik Strouhal" } },
			new Teacher() { SeededEntityId = 212, User = new User() { Email = "mensaforum.2026.011@mensagymnazium.cz", Name = "Jiří Hrdý" } },
			new Teacher() { SeededEntityId = 213, User = new User() { Email = "mensaforum.2026.012@mensagymnazium.cz", Name = "Jakub Tomšej" } },
			new Teacher() { SeededEntityId = 221, User = new User() { Email = "mensaforum.2026.013@mensagymnazium.cz", Name = "Miloš Škorpil" } },
			new Teacher() { SeededEntityId = 222, User = new User() { Email = "mensaforum.2026.014@mensagymnazium.cz", Name = "Martin Soukup" } },
			new Teacher() { SeededEntityId = 223, User = new User() { Email = "mensaforum.2026.015@mensagymnazium.cz", Name = "Petr Pelikán" } },
			new Teacher() { SeededEntityId = 231, User = new User() { Email = "mensaforum.2026.016@mensagymnazium.cz", Name = "David Navara" } },
			new Teacher() { SeededEntityId = 232, User = new User() { Email = "mensaforum.2026.017@mensagymnazium.cz", Name = "Nadia Rovderová" } },
			new Teacher() { SeededEntityId = 233, User = new User() { Email = "mensaforum.2026.018@mensagymnazium.cz", Name = "Gabriela Kahoferová" } },
			new Teacher() { SeededEntityId = 311, User = new User() { Email = "mensaforum.2026.019@mensagymnazium.cz", Name = "Martin Ladecký" } },
			new Teacher() { SeededEntityId = 312, User = new User() { Email = "mensaforum.2026.020@mensagymnazium.cz", Name = "Radek Bartoníček" } },
			new Teacher() { SeededEntityId = 313, User = new User() { Email = "mensaforum.2026.021@mensagymnazium.cz", Name = "Vítězslav Škorpík" } },
			new Teacher() { SeededEntityId = 321, User = new User() { Email = "mensaforum.2026.022@mensagymnazium.cz", Name = "Sylva Horáková" } },
			new Teacher() { SeededEntityId = 322, User = new User() { Email = "mensaforum.2026.023@mensagymnazium.cz", Name = "Zuzana Hübnerová" } },
			new Teacher() { SeededEntityId = 323, User = new User() { Email = "mensaforum.2026.024@mensagymnazium.cz", Name = "Karel Eliáš" } },
			new Teacher() { SeededEntityId = 331, User = new User() { Email = "mensaforum.2026.025@mensagymnazium.cz", Name = "Daniel Dvořák" } },
			new Teacher() { SeededEntityId = 332, User = new User() { Email = "mensaforum.2026.026@mensagymnazium.cz", Name = "Erik Šafařík" } },
			new Teacher() { SeededEntityId = 333, User = new User() { Email = "mensaforum.2026.027@mensagymnazium.cz", Name = "Petr Fiala" } },
		};

		Seed(For(teachers).PairBy(teacher => teacher.SeededEntityId)
			.AndFor(teacher => teacher.User, userSeed => userSeed.PairBy(u => u.Email))
			.AfterSave(item => item.SeedEntity.User.TeacherId = item.PersistedEntity.Id)
		);
	}
}
