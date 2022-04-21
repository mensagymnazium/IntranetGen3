using Havit.Data.Patterns.DataSeeds.Profiles;
using MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core;
using MensaGymnazium.IntranetGen3.DataLayer.Seeds.Subjects2022;
using MensaGymnazium.IntranetGen3.DataLayer.Seeds.Teachers2022;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Demo;

public class DemoProfile : DataSeedProfile
{
	public override IEnumerable<Type> GetPrerequisiteProfiles()
	{
		yield return typeof(CoreProfile);
		yield return typeof(Teachers2022Profile);
		yield return typeof(Subjects2022Profile);
	}
}
