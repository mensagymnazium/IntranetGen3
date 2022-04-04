using MensaGymnazium.IntranetGen3.Model;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core;

public class GradeSeed : DataSeed<CoreProfile>
{
	public override void SeedData()
	{
		var data = new[]
		{
			new Grade() { Id = (int) Grade.Entry.Prima, Name = "prima", AadGroupId = "77028406-7646-43d8-9f61-2a06f089891c" },
			new Grade() { Id = (int) Grade.Entry.Sekunda, Name = "sekunda", AadGroupId = "85aa6673-47ce-4910-b0ca-e7e03a46a70b" },
			new Grade() { Id = (int) Grade.Entry.Tercie, Name = "tercie", AadGroupId = "5fca5418-0c1f-4f57-9a0a-715bff302d63" },
			new Grade() { Id = (int) Grade.Entry.Kvarta, Name = "kvarta", AadGroupId = "e1291dff-a6c6-474c-8e6a-1d0c22c494ad" },
			new Grade() { Id = (int) Grade.Entry.Kvinta, Name = "kvinta", AadGroupId = "25a6b0d1-7083-4388-9135-6a56b21e1130" },
			new Grade() { Id = (int) Grade.Entry.Sexta, Name = "sexta", AadGroupId = "91bd05b5-bc27-4e6b-8fa5-79661bdf9f66" },
			new Grade() { Id = (int) Grade.Entry.Septima, Name = "septima", AadGroupId = "b374d053-687f-4dcb-a1a7-48d9e41c2098" },
			new Grade() { Id = (int) Grade.Entry.Oktava, Name = "oktáva", AadGroupId = "4da87481-c559-4831-887c-45e41412e9dc" }
		};

		Seed(For(data).PairBy(grade => grade.Id)); // TODO WithoutUpdate nebo bez AadGroupId? 
	}
}
