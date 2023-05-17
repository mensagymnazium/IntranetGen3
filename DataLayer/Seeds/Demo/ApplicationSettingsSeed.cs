using MensaGymnazium.IntranetGen3.Model.Common;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Demo;

public class ApplicationSettingsSeed : DataSeed<DemoProfile>
{
	public override void SeedData()
	{
		// MF: S Tímhle nastavením by zápis měl být časově možný
		var data = new[]
		{
			new ApplicationSettings()
			{
				SubjectRegistrationAllowedFrom = null,
				SubjectRegistrationAllowedTo = null,
				Id = -1
			}
		};

		// MF: S Tímhle nastavením je na zápis předmětu už pozdě
		//var data = new[]
		//{
		//	new ApplicationSettings()
		//	{
		//		SubjectRegistrationAllowedFrom = null,
		//		SubjectRegistrationAllowedTo = DateTime.Today.AddDays(-1),
		//		Id = -1
		//	}
		//};

		Seed(
			For(data)
			.PairBy(s => s.Id)
			);
	}
}