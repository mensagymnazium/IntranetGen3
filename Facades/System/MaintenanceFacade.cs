using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Havit.Extensions.DependencyInjection.Abstractions;
using MensaGymnazium.IntranetGen3.Contracts.System;
using MensaGymnazium.IntranetGen3.Model.Security;
using Havit.Services.Caching;
using Microsoft.AspNetCore.Authorization;

namespace MensaGymnazium.IntranetGen3.Facades.System
{
	[Service]
	[Authorize(Roles = nameof(Role.Entry.SystemAdministrator))]
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
}
