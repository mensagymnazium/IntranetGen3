using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Havit.Data.Patterns.DataSeeds.Profiles;
using MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Demo;

public class DemoProfile : DataSeedProfile
{
	public override IEnumerable<Type> GetPrerequisiteProfiles()
	{
		yield return typeof(CoreProfile);
	}
}
