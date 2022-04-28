using MensaGymnazium.IntranetGen3.Model.Security;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Teachers2022;

public class TeacherSeed : DataSeed<Teachers2022Profile>
{
	public override void SeedData()
	{
		var teachers = new[]
		{
			new Teacher() { SeededEntityId = 111, User = new User() { Email = "Barbora.Lacinova@mensagymnazium.cz", Name = "Barbora Lacinová" } },
			new Teacher() { SeededEntityId = 112, User = new User() { Email = "Helena.Pollakova@mensagymnazium.cz", Name = "Helena Polláková" } },
			new Teacher() { SeededEntityId = 113, User = new User() { Email = "david_john.seddon@mensagymnazium.cz", Name = "David John Seddon" } },
			new Teacher() { SeededEntityId = 121, User = new User() { Email = "Zdenek.Drozd@mensagymnazium.cz", Name = "Zdeněk Drozd" } },
			new Teacher() { SeededEntityId = 122, User = new User() { Email = "Jaroslav.Sebestik@mensagymnazium.cz", Name = "Jaroslav Šebestík" } },
			new Teacher() { SeededEntityId = 123, User = new User() { Email = "Michaela.Makesova@mensagymnazium.cz", Name = "Michaela Makešová" } },
			new Teacher() { SeededEntityId = 131, User = new User() { Email = "Robert.Haken@mensagymnazium.cz", Name = "Robert Haken" } },
			new Teacher() { SeededEntityId = 132, User = new User() { Email = "Stanislava.Hruskova@mensagymnazium.cz", Name = "Stanislava Hrušková" } },
			new Teacher() { SeededEntityId = 133, User = new User() { Email = "Ivo.Sir@mensagymnazium.cz", Name = "Ivo Šír" } },
			new Teacher() { SeededEntityId = 211, User = new User() { Email = "Cyril.Svoboda@mensagymnazium.cz", Name = "Cyril Svoboda" } },
			new Teacher() { SeededEntityId = 212, User = new User() { Email = "Renata.Sladka@mensagymnazium.cz", Name = "Renáta Sladká" } },
			new Teacher() { SeededEntityId = 213, User = new User() { Email = "James.De.Silva@mensagymnazium.cz", Name = "James De Silva" } },
			new Teacher() { SeededEntityId = 221, User = new User() { Email = "Jitka.Prochazkova@mensagymnazium.cz", Name = "Jitka Procházková" } },
			new Teacher() { SeededEntityId = 222, User = new User() { Email = "Katerina.Dojciakova@mensagymnazium.cz", Name = "Kateřina Dojčiaková" } },
			new Teacher() { SeededEntityId = 223, User = new User() { Email = "Krystof.Kucmas@mensagymnazium.cz", Name = "Kryštof Kučmáš" } },
			new Teacher() { SeededEntityId = 231, User = new User() { Email = "Martin.Kalivoda@mensagymnazium.cz", Name = "Martin Kalivoda" } },
			new Teacher() { SeededEntityId = 232, User = new User() { Email = "Martin.Komarek@mensagymnazium.cz", Name = "Martin Komárek" } },
			new Teacher() { SeededEntityId = 233, User = new User() { Email = "Adela.Smazikova@mensagymnazium.cz", Name = "Adéla Smažíková" } },
			new Teacher() { SeededEntityId = 311, User = new User() { Email = "Barbora.Hudeckova.Herchlova@mensagymnazium.cz", Name = "Barbora Hudečková Herchlová" } },
			new Teacher() { SeededEntityId = 312, User = new User() { Email = "Boris.Jankovec@mensagymnazium.cz", Name = "Boris Jankovec" } },
			new Teacher() { SeededEntityId = 313, User = new User() { Email = "Jelena.Bedretdinovova@mensagymnazium.cz", Name = "Jelena Bedretdinovová" } },
			new Teacher() { SeededEntityId = 321, User = new User() { Email = "Lenka.Ulmanova@mensagymnazium.cz", Name = "Lenka Ulmanová" } },
			new Teacher() { SeededEntityId = 322, User = new User() { Email = "Marie.Veverova@mensagymnazium.cz", Name = "Marie Veverová" } },
			new Teacher() { SeededEntityId = 323, User = new User() { Email = "Martin.Kulhanek@mensagymnazium.cz", Name = "Martin Kulhánek" } },
			new Teacher() { SeededEntityId = 331, User = new User() { Email = "Milan.Hanzl@mensagymnazium.cz", Name = "Milan Hanzl" } },
			new Teacher() { SeededEntityId = 332, User = new User() { Email = "Petr.Kubacak@mensagymnazium.cz", Name = "Petr Kubačák" } },
			new Teacher() { SeededEntityId = 333, User = new User() { Email = "Vaclav.Brdek@mensagymnazium.cz", Name = "Václav Brdek" } },
		};

		Seed(For(teachers).PairBy(teacher => teacher.SeededEntityId)
			.AndFor(teacher => teacher.User, userSeed => userSeed.PairBy(u => u.Email))
			.AfterSave(item => item.SeedEntity.User.TeacherId = item.PersistedEntity.Id)
		);
	}
}
