using MensaGymnazium.IntranetGen3.Model.Security;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Demo;

public class StudentSeed : DataSeed<DemoProfile>
{
	public override void SeedData()
	{
		var students = new Student[]
		{
			new Student() { SeedEntityId = 1, GradeId = (int)GradeEntry.Prima, User = new User() { Email = "petr.primovic@mensagymnazium.dev", Name = "Petr Primovič" } },
			new Student() { SeedEntityId = 2, GradeId = (int)GradeEntry.Sekunda, User = new User() { Email = "sara.sekundova@mensagymnazium.dev", Name = "Sára Sekundová" } },
			new Student() { SeedEntityId = 3, GradeId = (int)GradeEntry.Tercie, User = new User() { Email = "tereza.tercianova@mensagymnazium.dev", Name = "Tereze Terciánová" } },
			new Student() { SeedEntityId = 4, GradeId = (int)GradeEntry.Kvarta, User = new User() { Email = "karel.kvartik@mensagymnazium.dev", Name = "Karel Kvartík" } },
			new Student() { SeedEntityId = 5, GradeId = (int)GradeEntry.Kvinta, User = new User() { Email = "katka.kvintova@mensagymnazium.dev", Name = "Kateřina Kvintová" } },
			new Student() { SeedEntityId = 6, GradeId = (int)GradeEntry.Sexta, User = new User() { Email = "sona.sextova@mensagymnazium.dev", Name = "Soňa Sextová" } },
			new Student() { SeedEntityId = 7, GradeId = (int)GradeEntry.Septima, User = new User() { Email = "sep.septimovic@mensagymnazium.dev", Name = "Sep Septimovič" } },
			new Student() { SeedEntityId = 8, GradeId = (int)GradeEntry.Oktava, User = new User() { Email = "olin.oktavian@mensagymnazium.dev", Name = "Olin Oktavián" } },
		};

		Seed(For(students).PairBy(student => student.SeedEntityId)
			.AndFor(student => student.User, userSeed => userSeed.PairBy(u => u.Email))
			.AfterSave(item => item.SeedEntity.User.StudentId = item.PersistedEntity.Id)
		);
	}
}
