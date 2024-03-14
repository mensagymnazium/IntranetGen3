using MensaGymnazium.IntranetGen3.Model;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core;

public class GradeSeed : DataSeed<CoreProfile>
{
	public override void SeedData()
	{
		var data = new[]
		{
			new Grade() { Id = (int) GradeEntry.Prima, Name = "prima", AadGroupId = "b2aff005-e445-497c-8483-f3f4ea92b26b" },
			new Grade() { Id = (int) GradeEntry.Sekunda, Name = "sekunda", AadGroupId = "c237c715-8941-41db-a147-53e1bebb07cd" },
			new Grade() { Id = (int) GradeEntry.Tercie, Name = "tercie", AadGroupId = "77028406-7646-43d8-9f61-2a06f089891c" },
			new Grade() { Id = (int) GradeEntry.Kvarta, Name = "kvarta", AadGroupId = "85aa6673-47ce-4910-b0ca-e7e03a46a70b" },
			new Grade() { Id = (int) GradeEntry.Kvinta, Name = "kvinta", AadGroupId = "5fca5418-0c1f-4f57-9a0a-715bff302d63" },
			new Grade() { Id = (int) GradeEntry.Sexta, Name = "sexta", AadGroupId = "e1291dff-a6c6-474c-8e6a-1d0c22c494ad" },
			new Grade() { Id = (int) GradeEntry.Septima, Name = "septima", AadGroupId = "25a6b0d1-7083-4388-9135-6a56b21e1130" },
			new Grade() { Id = (int) GradeEntry.Oktava, Name = "oktáva", AadGroupId = "91bd05b5-bc27-4e6b-8fa5-79661bdf9f66" },
		};

		Seed(For(data).PairBy(grade => grade.Id)); // TODO WithoutUpdate nebo bez AadGroupId? 
	}
}
