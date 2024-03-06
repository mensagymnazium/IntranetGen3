using MensaGymnazium.IntranetGen3.Model.Security;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Teachers2024;

public class TeacherSeed : DataSeed<Teachers2024Profile>
{
	public override void SeedData()
	{
		var teachers = new[]
		{
			new Teacher() { SeededEntityId = 0, User = new User() { Email = "mensaforum.2023.001@mensagymnazium.cz", Name = "Vojtěch Vačkář" } },
			new Teacher() { SeededEntityId = 1, User = new User() { Email = "mensaforum.2023.010@mensagymnazium.cz", Name = "sestra Angelika" } },
			new Teacher() { SeededEntityId = 2, User = new User() { Email = "mensaforum.2023.003@mensagymnazium.cz", Name = "Eva Zažímalová" } },
			new Teacher() { SeededEntityId = 3, User = new User() { Email = "mensaforum.2023.002@mensagymnazium.cz", Name = "František Skála" } },
			new Teacher() { SeededEntityId = 4, User = new User() { Email = "mensaforum.2023.004@mensagymnazium.cz", Name = "Kateřina Kněžíková" } },
			new Teacher() { SeededEntityId = 5, User = new User() { Email = "mensaforum.2023.005@mensagymnazium.cz", Name = "Daniel Munich" } },
			new Teacher() { SeededEntityId = 6, User = new User() { Email = "mensaforum.2023.006@mensagymnazium.cz", Name = "Šárka Robinson" } },
			new Teacher() { SeededEntityId = 7, User = new User() { Email = "mensaforum.2023.007@mensagymnazium.cz", Name = "Jan Nedbal" } },
			new Teacher() { SeededEntityId = 8, User = new User() { Email = "mensaforum.2023.008@mensagymnazium.cz", Name = "Pavel Cejnar" } },
			new Teacher() { SeededEntityId = 9, User = new User() { Email = "mensaforum.2023.009@mensagymnazium.cz", Name = "Jan Vojtko" } },
			new Teacher() { SeededEntityId = 10, User = new User() { Email = "mensaforum.2023.011@mensagymnazium.cz", Name = "Tomáš Petráček" } },
			new Teacher() { SeededEntityId = 11, User = new User() { Email = "mensaforum.2023.012@mensagymnazium.cz", Name = "Luboš Pick" } },
			new Teacher() { SeededEntityId = 12, User = new User() { Email = "mensaforum.2023.013@mensagymnazium.cz", Name = "Aleš Gerloch" } },
			new Teacher() { SeededEntityId = 13, User = new User() { Email = "mensaforum.2023.014@mensagymnazium.cz", Name = "Klára Kadár" } },
			new Teacher() { SeededEntityId = 14, User = new User() { Email = "mensaforum.2023.015@mensagymnazium.cz", Name = "Jiří Matas" } },
			new Teacher() { SeededEntityId = 15, User = new User() { Email = "mensaforum.2023.016@mensagymnazium.cz", Name = "Pete Lupton" } },
			new Teacher() { SeededEntityId = 16, User = new User() { Email = "mensaforum.2023.017@mensagymnazium.cz", Name = "Láďa Hruška" } },
			new Teacher() { SeededEntityId = 17, User = new User() { Email = "mensaforum.2023.018@mensagymnazium.cz", Name = "Vladimír Polívka" } },
			new Teacher() { SeededEntityId = 18, User = new User() { Email = "mensaforum.2023.019@mensagymnazium.cz", Name = "Tomáš Zima" } },
			new Teacher() { SeededEntityId = 19, User = new User() { Email = "mensaforum.2023.020@mensagymnazium.cz", Name = "czechedsubstance" } },
			new Teacher() { SeededEntityId = 20, User = new User() { Email = "mensaforum.2023.021@mensagymnazium.cz", Name = "Anna Geislerová" } },
			new Teacher() { SeededEntityId = 21, User = new User() { Email = "mensaforum.2023.022@mensagymnazium.cz", Name = "Hana Švábíková" } },
			new Teacher() { SeededEntityId = 22, User = new User() { Email = "mensaforum.2023.023@mensagymnazium.cz", Name = "Jiří Martínek" } },
			new Teacher() { SeededEntityId = 23, User = new User() { Email = "mensaforum.2023.024@mensagymnazium.cz", Name = "Jitka Nováčková" } },
			new Teacher() { SeededEntityId = 24, User = new User() { Email = "mensaforum.2023.025@mensagymnazium.cz", Name = "Kateřina Šedá" } },
			new Teacher() { SeededEntityId = 25, User = new User() { Email = "mensaforum.2023.026@mensagymnazium.cz", Name = "Jiří Hájíček" } },
			new Teacher() { SeededEntityId = 26, User = new User() { Email = "mensaforum.2023.027@mensagymnazium.cz", Name = "..." } },
		};

		Seed(For(teachers).PairBy(teacher => teacher.SeededEntityId)
			.AndFor(teacher => teacher.User, userSeed => userSeed.PairBy(u => u.Email))
			.AfterSave(item => item.SeedEntity.User.TeacherId = item.PersistedEntity.Id)
		);
	}
}
