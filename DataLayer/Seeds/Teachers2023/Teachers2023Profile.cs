using Havit.Data.Patterns.DataSeeds.Profiles;
using MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Teachers2023;

public class Teachers2022Profile : DataSeedProfile
{
	public override IEnumerable<Type> GetPrerequisiteProfiles()
	{
		yield return typeof(CoreProfile);
	}
}
