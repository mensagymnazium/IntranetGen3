using Havit.Data.Patterns.DataSeeds.Profiles;
using MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Teachers2024;

public class Teachers2024Profile : DataSeedProfile
{
	public override IEnumerable<Type> GetPrerequisiteProfiles()
	{
		yield return typeof(CoreProfile);
	}
}
