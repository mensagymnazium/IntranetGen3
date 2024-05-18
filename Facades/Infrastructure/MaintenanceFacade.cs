using Havit.Services.Caching;
using MensaGymnazium.IntranetGen3.Contracts.Infrastructure;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Facades.Infrastructure;

[Service]
[Authorize(Roles = nameof(Role.Administrator))]
public class MaintenanceFacade : IMaintenanceFacade
{
	private readonly ICacheService _cacheService;

	public MaintenanceFacade(ICacheService cacheService)
	{
		_cacheService = cacheService;
	}

	public Task ClearCacheAsync(CancellationToken cancellationToken = default)
	{
		cancellationToken.ThrowIfCancellationRequested();

		_cacheService.Clear();

		return Task.CompletedTask;
	}
}
