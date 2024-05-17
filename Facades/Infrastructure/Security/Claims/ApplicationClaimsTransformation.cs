using System.Security.Claims;
using Havit.Threading;
using MensaGymnazium.IntranetGen3.Services.Infrastructure;
using Microsoft.AspNetCore.Authentication;

namespace MensaGymnazium.IntranetGen3.Facades.Infrastructure.Security.Claims;

/// <summary>
/// Přidá do claims z JWT další claims.
/// Jako side-efekt (v implementacích) zajistí založení LoginAccountu, pokud ještě neexistuje.
/// Optimalizace: Claims jsou drženy v cache, aby je nebylo nutné každý request skládat znovu a znovu.
/// </summary>
[Service(Profile = ServiceProfiles.WebServer)]
public class ApplicationClaimsTransformation : IClaimsTransformation
{
	private static CriticalSection<UserContextInfo> s_criticalSection = new CriticalSection<UserContextInfo>(); // statické - instanci kritické sekce potřebujeme sdílet přes všechny instance

	private readonly IClaimsCacheStore _claimsCacheStore;
	private readonly IUserContextInfoBuilder _contextInfoBuilder;
	private readonly ICustomClaimsBuilder _customClaimsBuilder;

	public ApplicationClaimsTransformation(IClaimsCacheStore claimsCacheStore, IUserContextInfoBuilder contextInfoBuilder, ICustomClaimsBuilder customClaimsBuilder)
	{
		_claimsCacheStore = claimsCacheStore;
		_contextInfoBuilder = contextInfoBuilder;
		_customClaimsBuilder = customClaimsBuilder;
	}

	/// <summary>
	/// Transformuje claims principla - přidá custom claims.
	/// </summary>
	public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
	{
		UserContextInfo userContextInfo = _contextInfoBuilder.GetUserContextInfo(principal);

		// pro nepřihlášeného uživatele žádnou transformaci neprovádíme
		if (userContextInfo == null)
		{
			return await Task.FromResult(principal);
		}

		List<Claim> customClaims = _claimsCacheStore.GetClaims(userContextInfo);
		if (customClaims == null)
		{
			await s_criticalSection.ExecuteActionAsync(userContextInfo, async () =>
			{
				customClaims = _claimsCacheStore.GetClaims(userContextInfo);
				if (customClaims == null)
				{
					// pokud nejsou žádné claims v cache, získáme je a do cache uložíme,
					// ať je pro stejný context další request rychlejší
					customClaims = await _customClaimsBuilder.GetCustomClaimsAsync(principal);
					_claimsCacheStore.StoreClaims(userContextInfo, customClaims);
				}
			});
		}

		// zduplikujeme identity a claims tak, že k duplikátům přidáme custom claim
		// pokud bychom přidávali claims do principal, který je parametrem, může se stát (a stalo se!), že se v identity objeví claims vícekrát
		ClaimsIdentity claimsIdentity = ((ClaimsIdentity)principal.Identity).Clone();
		claimsIdentity.AddClaims(customClaims);
		ClaimsPrincipal claimsPrincipalWithCustomClaims = new ClaimsPrincipal(claimsIdentity);
		return await Task.FromResult(claimsPrincipalWithCustomClaims);
	}
}
