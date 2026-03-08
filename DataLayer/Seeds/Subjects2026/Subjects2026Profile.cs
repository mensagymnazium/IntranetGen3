using Havit.Data.Patterns.DataSeeds.Profiles;
using MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core;
using MensaGymnazium.IntranetGen3.DataLayer.Seeds.Teachers2026;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Subjects2026;

public class Subjects2026Profile : DataSeedProfile
{
	public override IEnumerable<Type> GetPrerequisiteProfiles()
	{
		yield return typeof(CoreProfile);
		yield return typeof(Teachers2026Profile);
	}
}
