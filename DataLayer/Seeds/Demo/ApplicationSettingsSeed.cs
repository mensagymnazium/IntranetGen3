using MensaGymnazium.IntranetGen3.Model.Common;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Demo;

public class ApplicationSettingsSeed : DataSeed<DemoProfile>
{
	public override void SeedData()
	{
		var data = new[]
		{
			new ApplicationSettings()
			{
				CanRegisterSubjectFrom = DateTime.Today.AddDays(-2),
				CanRegisterSubjectTo = DateTime.Today.AddDays(-1),
				Id = -1
			}
		};

		//Seed(For(data).PairBy(grade => grade.Id)); // TODO WithoutUpdate
		Seed(
			For(data)
			.PairBy(s => s.Id)
			//.WithoutUpdate()
			);
	}
}