using Havit.Data.Patterns.DataSeeds.Profiles;
using MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Teachers2023;

public class Teachers2023Profile : DataSeedProfile
{
	public override IEnumerable<Type> GetPrerequisiteProfiles()
	{
		yield return typeof(CoreProfile);
	}
}
