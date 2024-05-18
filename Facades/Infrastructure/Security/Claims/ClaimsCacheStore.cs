using System.Security.Claims;
using MensaGymnazium.IntranetGen3.Services.Infrastructure;
using Microsoft.Extensions.Caching.Memory;

namespace MensaGymnazium.IntranetGen3.Facades.Infrastructure.Security.Claims;

/// <summary>
/// (In-memory) cache claimů.
/// </summary>
[Service(Profile = ServiceProfiles.WebServer)]
public class ClaimsCacheStore : IClaimsCacheStore
{
	private readonly IMemoryCache _cache;

	public ClaimsCacheStore(IMemoryCache cache)
	{
		_cache = cache;
	}

	public List<Claim> GetClaims(UserContextInfo userContextInfo)
	{
		if (_cache.TryGetValue(GetCacheKey(userContextInfo), out List<Claim> result))
		{
			return result;
		}

		return null;
	}

	public void StoreClaims(UserContextInfo userContextInfo, List<Claim> claims)
	{
		_cache.Set(GetCacheKey(userContextInfo), claims, new MemoryCacheEntryOptions
		{
			Priority = CacheItemPriority.Low,
			AbsoluteExpirationRelativeToNow = new TimeSpan(0, 15, 0) /* 15 minut */
		});
	}

	private object GetCacheKey(UserContextInfo userContextInfo)
	{
		// implementace má přetížení GetHashCode i Equals
		return userContextInfo;
	}
}