using Havit.ComponentModel;

namespace MensaGymnazium.IntranetGen3.Contracts.Infrastructure;

[ApiContract]
public interface IDataSeedFacade
{
	Task SeedDataProfileAsync(string profileName);

	Task<List<string>> GetDataSeedProfilesAsync();
}
