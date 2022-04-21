using Havit.Services.Caching;
using MensaGymnazium.IntranetGen3.Contracts.Infrastructure;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Facades.Infrastructure;

[Service]
[Authorize(Roles = nameof(Role.Administrator))]
public class MaintenanceFacade : IMaintenanceFacade
{
	private readonly ICacheService cacheService;

	public MaintenanceFacade(ICacheService cacheService)
	{
		this.cacheService = cacheService;
	}

	public Task ClearCache(CancellationToken cancellationToken = default)
	{
		cancellationToken.ThrowIfCancellationRequested();

		cacheService.Clear();

		return Task.CompletedTask;
	}
}
