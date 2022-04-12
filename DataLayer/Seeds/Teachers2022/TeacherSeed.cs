using MensaGymnazium.IntranetGen3.Model.Security;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Teachers2022;

public class TeacherSeed : DataSeed<Teachers2022Profile>
{
	public override void SeedData()
	{
		var teachers = new[]
		{
			new Teacher() { SeededEntityId = 5558550, User = new User() { Email = "Barbora.Lacinova@mensagymnazium.cz", Name = "Barbora Lacinová" } },
			new Teacher() { SeededEntityId = 4854197, User = new User() { Email = "Helena.Pollakova@mensagymnazium.cz", Name = "Helena Polláková" } },
			new Teacher() { SeededEntityId = 2805686, User = new User() { Email = "david_john.seddon@mensagymnazium.cz", Name = "David John Seddon" } },
			new Teacher() { SeededEntityId = 10950419, User = new User() { Email = "Zdenek.Drozd@mensagymnazium.cz", Name = "Zdeněk Drozd" } },
			new Teacher() { SeededEntityId = 4978114, User = new User() { Email = "Jaroslav.Sebestik@mensagymnazium.cz", Name = "Jaroslav Šebestík" } },
			new Teacher() { SeededEntityId = 7314404, User = new User() { Email = "Michaela.Makesova@mensagymnazium.cz", Name = "Michaela Makešová" } },
			new Teacher() { SeededEntityId = 1021013, User = new User() { Email = "Robert.Haken@mensagymnazium.cz", Name = "Robert Haken" } },
			new Teacher() { SeededEntityId = 16438547, User = new User() { Email = "Stanislava.Hruskova@mensagymnazium.cz", Name = "Stanislava Hrušková" } },
			new Teacher() { SeededEntityId = 2724000, User = new User() { Email = "Ivo.Sir@mensagymnazium.cz", Name = "Ivo Šír" } },
			new Teacher() { SeededEntityId = 8619441, User = new User() { Email = "Cyril.Svoboda@mensagymnazium.cz", Name = "Cyril Svoboda" } },
			new Teacher() { SeededEntityId = 10546950, User = new User() { Email = "Renata.Sladka@mensagymnazium.cz", Name = "Renáta Sladká" } },
			new Teacher() { SeededEntityId = 856000, User = new User() { Email = "James.De.Silva@mensagymnazium.cz", Name = "James De Silva" } },
			new Teacher() { SeededEntityId = 10659022, User = new User() { Email = "Jitka.Prochazkova@mensagymnazium.cz", Name = "Jitka Procházková" } },
			new Teacher() { SeededEntityId = 8258528, User = new User() { Email = "Katerina.Dojciakova@mensagymnazium.cz", Name = "Kateřina Dojčiaková" } },
			new Teacher() { SeededEntityId = 5906515, User = new User() { Email = "Krystof.Kucmas@mensagymnazium.cz", Name = "Kryštof Kučmáš" } },
			new Teacher() { SeededEntityId = 872777, User = new User() { Email = "Martin.Kalivoda@mensagymnazium.cz", Name = "Martin Kalivoda" } },
			new Teacher() { SeededEntityId = 13061828, User = new User() { Email = "Martin.Komarek@mensagymnazium.cz", Name = "Martin Komárek" } },
			new Teacher() { SeededEntityId = 16120635, User = new User() { Email = "Adela.Smazikova@mensagymnazium.cz", Name = "Adéla Smažíková" } },
			new Teacher() { SeededEntityId = 2705278, User = new User() { Email = "Barbora.Hudeckova.Herchlova@mensagymnazium.cz", Name = "Barbora Hudečková Herchlová" } },
			new Teacher() { SeededEntityId = 7871725, User = new User() { Email = "Boris.Jankovec@mensagymnazium.cz", Name = "Boris Jankovec" } },
			new Teacher() { SeededEntityId = 3531037, User = new User() { Email = "Jelena.Bedretdinovova@mensagymnazium.cz", Name = "Jelena Bedretdinovová" } },
			new Teacher() { SeededEntityId = 4298674, User = new User() { Email = "Lenka.Ulmanova@mensagymnazium.cz", Name = "Lenka Ulmanová" } },
			new Teacher() { SeededEntityId = 10940690, User = new User() { Email = "Marie.Veverova@mensagymnazium.cz", Name = "Marie Veverová" } },
			new Teacher() { SeededEntityId = 9712308, User = new User() { Email = "Martin.Kulhanek@mensagymnazium.cz", Name = "Martin Kulhánek" } },
			new Teacher() { SeededEntityId = 1476149, User = new User() { Email = "Milan.Hanzl@mensagymnazium.cz", Name = "Milan Hanzl" } },
			new Teacher() { SeededEntityId = 2188808, User = new User() { Email = "Petr.Kubacak@mensagymnazium.cz", Name = "Petr Kubačák" } },
			new Teacher() { SeededEntityId = 4276982, User = new User() { Email = "Vaclav.Brdek@mensagymnazium.cz", Name = "Václav Brdek" } },
			new Teacher() { SeededEntityId = 3853935, User = new User() { Email = "Vera.Jurcakova@mensagymnazium.cz", Name = "Věra Jurčáková" } },
			new Teacher() { SeededEntityId = 6753631, User = new User() { Email = "Peter.Benjamin.Parker@mensagymnazium.cz", Name = "Peter Benjamin Parker" } },
			new Teacher() { SeededEntityId = 1213033, User = new User() { Email = "Jitka.Hofmannova@mensagymnazium.cz", Name = "Jitka Hofmannová" } },
			new Teacher() { SeededEntityId = 9398696, User = new User() { Email = "Rafik.Bedretdinov@mensagymnazium.cz", Name = "Rafik Bedretdinov" } },
			new Teacher() { SeededEntityId = 13371611, User = new User() { Email = "Stanislav.Hampl@mensagymnazium.cz", Name = "Stanislav Hampl" } },
			new Teacher() { SeededEntityId = 3930125, User = new User() { Email = "Dana.Mandikova@mensagymnazium.cz", Name = "Dana Mandíková" } },
			new Teacher() { SeededEntityId = 6273638, User = new User() { Email = "Katerina.Miloschewska@mensagymnazium.cz", Name = "Kateřina Miloschewská" } },
			new Teacher() { SeededEntityId = 13712422, User = new User() { Email = "Jana.Sedlackova@mensagymnazium.cz", Name = "Jana Sedláčková" } },
			new Teacher() { SeededEntityId = 39839199, User = new User() { Email = "Martin.Zimen@mensagymnazium.cz", Name = "Martin Zimen" } },
		};

		Seed(For(teachers).PairBy(teacher => teacher.SeededEntityId)
			.AndFor(teacher => teacher.User, userSeed => userSeed.PairBy(u => u.Email))
			.AfterSave(item => item.SeedEntity.User.TeacherId = item.PersistedEntity.Id)
		);
	}
}
