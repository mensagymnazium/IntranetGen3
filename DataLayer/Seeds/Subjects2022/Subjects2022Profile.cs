using Havit.Data.Patterns.DataSeeds.Profiles;
using MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core;
using MensaGymnazium.IntranetGen3.DataLayer.Seeds.Teachers2022;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Subjects2022;

public class Subjects2022Profile : DataSeedProfile
{
	public override IEnumerable<Type> GetPrerequisiteProfiles()
	{
		yield return typeof(CoreProfile);
		yield return typeof(Teachers2022Profile);
	}
}
