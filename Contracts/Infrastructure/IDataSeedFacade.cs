using Havit.ComponentModel;

namespace MensaGymnazium.IntranetGen3.Contracts.Infrastructure;

[ApiContract]
public interface IDataSeedFacade
{
	Task SeedDataProfile(string profileName);

	Task<List<string>> GetDataSeedProfiles();
}
