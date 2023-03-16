using Havit.Data.Patterns.DataSeeds.Profiles;
using MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core;
using MensaGymnazium.IntranetGen3.DataLayer.Seeds.Teachers2023;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Subjects2023;

public class Subjects2023Profile : DataSeedProfile
{
	public override IEnumerable<Type> GetPrerequisiteProfiles()
	{
		yield return typeof(CoreProfile);
		yield return typeof(Teachers2023Profile);
	}
}
