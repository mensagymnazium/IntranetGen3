using MensaGymnazium.IntranetGen3.Model.Security;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Demo;

public class TeacherSeed : DataSeed<DemoProfile>
{
	public override void SeedData()
	{
		var teachers = new[]
		{
			new Teacher() { SeededEntityId=5558550, User=new User() { Email="demo.Barbora.Lacinova@example.com", Name="Barbora Lacinová" }, FunFact = "tento fakt o paní Lacinové je lež? aaa, paradox..." },
			new Teacher() { SeededEntityId=4854197, User=new User() { Email="demo.Helena.Pollakova@example.com", Name="Bc. Helena Polláková" }, FunFact="paní Polláková učí na Mensa gymnáziu? Překvápko, co?" },
			new Teacher() { SeededEntityId=2805686, User=new User() { Email="demo.Seddon@example.com", Name="Mgr. David J. Seddon" }, FunFact="David učí na škole jen jeden den v týdnu?" },
			new Teacher() { SeededEntityId=10950419, User=new User() { Email="demo.Zdenek.Drozd@example.com", Name="doc. RNDr. Zdeněk Drozd, Ph D." }, FunFact="mi došly nápady na smyšlené fun facty o panu Drozdovi?" },
			new Teacher() { SeededEntityId=4978114, User=new User() { Email="demo.Jaroslav.Sebestik@example.com", Name="Ing. Jaroslav Šebestík, Ph.D." }, FunFact="mi došly nápady na smyšlené fun facty o panu Šebestíkovi?" },
			new Teacher() { SeededEntityId=7314404, User=new User() { Email="demo.Michaela.Makesova@example.com", Name="Ing. Michaela Makešová" }, FunFact="mi došly nápady na smyšlené fun facty o paní Makešové?" },
			new Teacher() { SeededEntityId=1021013, User=new User() { Email="demo.Robert.Haken@example.com", Name="Ing. Robert Haken" }, FunFact="mi došly nápady na smyšlené fun facty o panu Hakenovi?" },
			new Teacher() { SeededEntityId=16438547, User=new User() { Email="demo.Stanislava.Hruskova@example.com", Name="Ing. Stanislava Hrušková, Ph.D." }, FunFact="mi došly nápady na smyšlené fun facty o paní Hruškové?" },
			new Teacher() { SeededEntityId=2724000, User=new User() { Email="demo.Ivo.Sir@example.com", Name="Ivo Šír" }, FunFact="pan Šír na naší škole neučí? Už 3 roky za sebou se neotevřel jeho seminář Práce s OS Linux." },
			new Teacher() { SeededEntityId=8619441, User=new User() { Email="demo.Cyril.Svoboda@example.com", Name="JUDr. Cyril Svoboda, Ph.D." }, FunFact="žádný fakt o politikovi není zábavný?" },
			new Teacher() { SeededEntityId=10546950, User=new User() { Email="demo.Renata.Sladka@example.com", Name="JUDr. Renáta Sladká" }, FunFact="paní Sladká používá jako příklad spolešnosti Sluníčko s.r.o. a Měsíček a.s.?" },
			new Teacher() { SeededEntityId=856000, User=new User() { Email="demo.James.De.Silva@example.com", Name="Mgr. James De Silva" }, FunFact="mi došly nápady na smyšlené fun facty o Jamesovi?" },
			new Teacher() { SeededEntityId=10659022, User=new User() { Email="demo.Jitka.Prochazkova@example.com", Name="Mgr. Jitka Procházková" }, FunFact="mi došly nápady na smyšlené fun facty o paní Procházkové?" },
			new Teacher() { SeededEntityId=8258528, User=new User() { Email="demo.Katerina.Dojciakova@example.com", Name="Kateřina Dojčiaková" }, FunFact="ten, kdo psal tyto fun facty neví, kdo je paní Dojčiaková?" },
			new Teacher() { SeededEntityId=5906515, User=new User() { Email="demo.Krystof.Kucmas@example.com", Name="Mgr. Kryštof Kučmáš" }, FunFact="mi došly nápady na smyšlené fun facty o panu Kučmášovi?" },
			new Teacher() { SeededEntityId=872777, User=new User() { Email="demo.Martin.Kalivoda@example.com", Name="Martin Kalivoda" }, FunFact="mi došly nápady na smyšlené fun facty o panu Kalivodovi?" },
			new Teacher() { SeededEntityId=13061828, User=new User() { Email="demo.Martin.Komarek@example.com", Name="PhDr. Martin Komárek" }, FunFact="mi došly nápady na smyšlené fun facty o panu Komárkovi?" },
			new Teacher() { SeededEntityId=9463298, User=new User() { Email="demo.Martin.Zimen@example.com", Name="Martin Zimen" }, FunFact="pan Zimen už na této škole delší dobu neučí?" },
			new Teacher() { SeededEntityId=16120635, User=new User() { Email="demo.Adela.Smazikova@example.com", Name="Mgr. Adéla Smažíková" }, FunFact="mi došly nápady na smyšlené fun facty o paní Smažíkové?" },
			new Teacher() { SeededEntityId=2705278, User=new User() { Email="demo.Barbora.Hudeckova.Herchlova@example.com", Name="Mgr. Barbora Hudečková Herchlová" }, FunFact="mi došly nápady na smyšlené fun facty o paní Hudečkové?" },
			new Teacher() { SeededEntityId=7871725, User=new User() { Email="demo.Boris.Jankovec@example.com", Name="Mgr. Boris Jankovec" }, FunFact="mi došly nápady na smyšlené fun facty o panu Jankovci?" },
			new Teacher() { SeededEntityId=3531037, User=new User() { Email="demo.Jelena.Bedretdinovova@example.com", Name="Mgr. Jelena Bedretdinovová" }, FunFact="se říká, že když 3x vyslovíte o půlnoci rychle a správně její jméno před zrcadlem, dostanete stovku z ruštiny?" },
			new Teacher() { SeededEntityId=4298674, User=new User() { Email="demo.Lenka.Ulmanova@example.com", Name="Mgr. Lenka Ulmanová" }, FunFact="mi došly nápady na smyšlené fun facty o paní Ulmanové?" },
			new Teacher() { SeededEntityId=10940690, User=new User() { Email="demo.Marie.Veverova@example.com", Name="Mgr. Marie Veverová" }, FunFact="mi došly nápady na smyšlené fun facty o paní veverové?" },
			new Teacher() { SeededEntityId=9712308, User=new User() { Email="demo.Martin.Kulhanek@example.com", Name="Mgr. Martin Kulhánek" }, FunFact="mi došly nápady na smyšlené fun facty o panu Kulhánkovi?" },
			new Teacher() { SeededEntityId=1476149, User=new User() { Email="demo.Milan.Hanzl@example.com", Name="Mgr. Milan Hanzl" }, FunFact="mi došly nápady na smyšlené fun facty o panu Hanzlovi?" },
			new Teacher() { SeededEntityId=2188808, User=new User() { Email="demo.Petr.Kubacak@example.com", Name="PhDr. Petr Kubačák" }, FunFact="mi došly nápady na smyšlené fun facty o panu Kubačákovi?" },
			new Teacher() { SeededEntityId=4276982, User=new User() { Email="demo.Vaclav.Brdek@example.com", Name="Mgr. Václav Brdek" }, FunFact="mi došly nápady na smyšlené fun facty o našem Bohu?" },
			new Teacher() { SeededEntityId=3853935, User=new User() { Email="demo.Vera.Jurcakova@example.com", Name="Mgr. Věra Jurčáková" }, FunFact="mi došly nápady na smyšlené fun facty o paní Jurčákové?" },
			new Teacher() { SeededEntityId=6753631, User=new User() { Email="demo.Peter.Benjamin.Parker@example.com", Name="Peter Benjamin Parker" }, FunFact="Peter Benjamin Parker je naprosto smyšlený učitel?" },
			new Teacher() { SeededEntityId=1213033, User=new User() { Email="demo.Jitka.Hofmannova@example.com", Name="PhDr. Jitka Hofmannová" }, FunFact="mi došly nápady na smyšlené fun facty o paní Hofmannové?" },
			new Teacher() { SeededEntityId=9398696, User=new User() { Email="demo.Rafik.Bedretdinov@example.com", Name="Ing. Rafik Bedretdinov" }, FunFact="mi došly nápady na smyšlené fun facty o panu Bedretdinovi?" },
			new Teacher() { SeededEntityId=13371611, User=new User() { Email="demo.Stanislav.Hampl@example.com", Name="PhDr. Stanislav Hampl" }, FunFact="mi došly nápady na smyšlené fun facty o panu Hamplovi?" },
			new Teacher() { SeededEntityId=3930125, User=new User() { Email="demo.Dana.Mandikova@example.com", Name="RNDr. Dana Mandíková, Ph.D." }, FunFact="ten, kdo psal tyto fun facty neví, kdo je paní Mandíková??" },
			new Teacher() { SeededEntityId=6273638, User=new User() { Email="demo.Katerina.Miloschewska@example.com", Name="RNDr. Kateřina Miloschewská" }, FunFact="má paní Miloschewská kabinet v P2-2?" },
			new Teacher() { SeededEntityId=13712422, User=new User() { Email="demo.Jana.Sedlackova@example.com", Name="Mgr. Jana Sedláčková" }, FunFact="mi došly nápady na smyšlené fun facty o paní Sedláčkové?" }
		};

		Seed(For(teachers).PairBy(teacher => teacher.SeededEntityId)
			.AndFor(teacher => teacher.User, userSeed => userSeed.PairBy(u => u.Email))
			.AfterSave(item => item.SeedEntity.User.TeacherId = item.PersistedEntity.Id)
		);
	}
}
