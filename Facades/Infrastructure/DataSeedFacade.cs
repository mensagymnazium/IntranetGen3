using Havit;
using Havit.Data.Patterns.DataSeeds;
using Havit.Data.Patterns.DataSeeds.Profiles;
using Havit.Services.Caching;
using MensaGymnazium.IntranetGen3.Contracts.Infrastructure;
using MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Facades.Infrastructure;

/// <summary>
/// Fasáda k seedování dat.
/// </summary>
[Service]
[Authorize(Roles = nameof(Role.Administrator))]

public class DataSeedFacade : IDataSeedFacade
{
	private readonly IDataSeedRunner dataSeedRunner;
	private readonly ICacheService cacheService;

	public DataSeedFacade(
		IDataSeedRunner dataSeedRunner,
		ICacheService cacheService)
	{
		this.dataSeedRunner = dataSeedRunner;
		this.cacheService = cacheService;
	}

	/// <summary>
	/// Provede seedování dat daného profilu.
	/// Pokud jde produkční prostředí a profil není pro produkční prostředí povolen, vrací BadRequest.
	/// </summary>
	public Task SeedDataProfile(string profileName)
	{
		// applicationAuthorizationService.VerifyCurrentUserAuthorization(Operations.SystemAdministration); // TODO alternative authorization approach

		Type type = GetProfileTypes().FirstOrDefault(item => string.Equals(item.Name, profileName, StringComparison.InvariantCultureIgnoreCase));

		if (type == null)
		{
			throw new OperationFailedException($"Profil {profileName} nebyl nalezen.");
		}

		dataSeedRunner.SeedData(type, forceRun: true);

		cacheService.Clear();

		return Task.CompletedTask;
	}

	/// <summary>
	/// Returns list of available data seed profiles (names are ready for use as parameter to <see cref="SeedDataProfile"/> method).
	/// </summary>
	public Task<List<string>> GetDataSeedProfiles()
	{
		return Task.FromResult(GetProfileTypes()
						.Select(t => t.Name)
						.ToList()
		);
	}

	private static IEnumerable<Type> GetProfileTypes()
	{
		return typeof(CoreProfile).Assembly.GetTypes()
			.Where(t => t.GetInterfaces().Contains(typeof(IDataSeedProfile)));
	}
}
