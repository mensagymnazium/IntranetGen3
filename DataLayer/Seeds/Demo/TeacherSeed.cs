using Havit.Data.Patterns.DataSeeds;
using MensaGymnazium.IntranetGen3.Model.Security;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Demo
{
	public class TeacherSeed : DataSeed<DemoProfile>
	{
		public override void SeedData()
		{
			var teachers = new[]
			{
				new Teacher() { SeededEntityId=5558550, User=new User() { Email="demo.Barbora.Lacinova@example.com", Name="Barbora Lacinová" } },
				new Teacher() { SeededEntityId=4854197, User=new User() { Email="demo.Helena.Pollakova@example.com", Name="Bc. Helena Polláková" } },
				new Teacher() { SeededEntityId=2805686, User=new User() { Email="demo.Seddon@example.com", Name="Mgr. David J. Seddon" } },
				new Teacher() { SeededEntityId=10950419, User=new User() { Email="demo.Zdenek.Drozd@example.com", Name="doc. RNDr. Zdeněk Drozd, Ph D." } },
				new Teacher() { SeededEntityId=4978114, User=new User() { Email="demo.Jaroslav.Sebestik@example.com", Name="Ing. Jaroslav Šebestík, Ph.D." } },
				new Teacher() { SeededEntityId=7314404, User=new User() { Email="demo.Michaela.Makesova@example.com", Name="Ing. Michaela Makešová" } },
				new Teacher() { SeededEntityId=1021013, User=new User() { Email="demo.Robert.Haken@example.com", Name="Ing. Robert Haken" } },
				new Teacher() { SeededEntityId=16438547, User=new User() { Email="demo.Stanislava.Hruskova@example.com", Name="Ing. Stanislava Hrušková, Ph.D." } },
				new Teacher() { SeededEntityId=2724000, User=new User() { Email="demo.Ivo.Sir@example.com", Name="Ivo Šír" } },
				new Teacher() { SeededEntityId=8619441, User=new User() { Email="demo.Cyril.Svoboda@example.com", Name="JUDr. Cyril Svoboda, Ph.D." } },
				new Teacher() { SeededEntityId=10546950, User=new User() { Email="demo.Renata.Sladka@example.com", Name="JUDr. Renáta Sladká" } },
				new Teacher() { SeededEntityId=856000, User=new User() { Email="demo.James.De.Silva@example.com", Name="Mgr. James De Silva" } },
				new Teacher() { SeededEntityId=10659022, User=new User() { Email="demo.Jitka.Prochazkova@example.com", Name="Mgr. Jitka Procházková" } },
				new Teacher() { SeededEntityId=8258528, User=new User() { Email="demo.Katerina.Dojciakova@example.com", Name="Kateřina Dojčiaková" } },
				new Teacher() { SeededEntityId=5906515, User=new User() { Email="demo.Krystof.Kucmas@example.com", Name="Mgr. Kryštof Kučmáš" } },
				new Teacher() { SeededEntityId=872777, User=new User() { Email="demo.Martin.Kalivoda@example.com", Name="Martin Kalivoda" } },
				new Teacher() { SeededEntityId=13061828, User=new User() { Email="demo.Martin.Komarek@example.com", Name="PhDr. Martin Komárek" } },
				new Teacher() { SeededEntityId=9463298, User=new User() { Email="demo.Martin.Zimen@example.com", Name="Martin Zimen" } },
				new Teacher() { SeededEntityId=16120635, User=new User() { Email="demo.Adela.Smazikova@example.com", Name="Mgr. Adéla Smažíková" } },
				new Teacher() { SeededEntityId=2705278, User=new User() { Email="demo.Barbora.Hudeckova.Herchlova@example.com", Name="Mgr. Barbora Hudečková Herchlová" } },
				new Teacher() { SeededEntityId=7871725, User=new User() { Email="demo.Boris.Jankovec@example.com", Name="Mgr. Boris Jankovec" } },
				new Teacher() { SeededEntityId=3531037, User=new User() { Email="demo.Jelena.Bedretdinovova@example.com", Name="Mgr. Jelena Bedretdinovová" } },
				new Teacher() { SeededEntityId=4298674, User=new User() { Email="demo.Lenka.Ulmanova@example.com", Name="Mgr. Lenka Ulmanová" } },
				new Teacher() { SeededEntityId=10940690, User=new User() { Email="demo.Marie.Veverova@example.com", Name="Mgr. Marie Veverová" } },
				new Teacher() { SeededEntityId=9712308, User=new User() { Email="demo.Martin.Kulhanek@example.com", Name="Mgr. Martin Kulhánek" } },
				new Teacher() { SeededEntityId=1476149, User=new User() { Email="demo.Milan.Hanzl@example.com", Name="Mgr. Milan Hanzl" } },
				new Teacher() { SeededEntityId=2188808, User=new User() { Email="demo.Petr.Kubacak@example.com", Name="PhDr. Petr Kubačák" } },
				new Teacher() { SeededEntityId=4276982, User=new User() { Email="demo.Vaclav.Brdek@example.com", Name="Mgr. Václav Brdek" } },
				new Teacher() { SeededEntityId=3853935, User=new User() { Email="demo.Vera.Jurcakova@example.com", Name="Mgr. Věra Jurčáková" } },
				new Teacher() { SeededEntityId=6753631, User=new User() { Email="demo.Peter.Benjamin.Parker@example.com", Name="Peter Benjamin Parker" } },
				new Teacher() { SeededEntityId=1213033, User=new User() { Email="demo.Jitka.Hofmannova@example.com", Name="PhDr. Jitka Hofmannová" } },
				new Teacher() { SeededEntityId=9398696, User=new User() { Email="demo.Rafik.Bedretdinov@example.com", Name="Ing. Rafik Bedretdinov" } },
				new Teacher() { SeededEntityId=13371611, User=new User() { Email="demo.Stanislav.Hampl@example.com", Name="PhDr. Stanislav Hampl" } },
				new Teacher() { SeededEntityId=3930125, User=new User() { Email="demo.Dana.Mandikova@example.com", Name="RNDr. Dana Mandíková, Ph.D." } },
				new Teacher() { SeededEntityId=6273638, User=new User() { Email="demo.Katerina.Miloschewska@example.com", Name="RNDr. Kateřina Miloschewská" }, FunFact="Má kabinet v P2-2" },
				new Teacher() { SeededEntityId=13712422, User=new User() { Email="demo.Jana.Sedlackova@example.com", Name="Mgr. Jana Sedláčková" } }
			};

			Seed(For(teachers)
				.PairBy(teacher => teacher.SeededEntityId)
				.AndFor(user => user.User, teacher => teacher.PairBy(t => t.Email))
				.AfterSave(item => item.SeedEntity.User.TeacherId = item.PersistedEntity.Id));
		}
	}
}
