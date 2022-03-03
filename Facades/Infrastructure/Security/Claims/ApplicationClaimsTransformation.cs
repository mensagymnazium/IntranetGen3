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
	private static CriticalSection<UserContextInfo> criticalSection = new CriticalSection<UserContextInfo>(); // statické - instanci kritické sekce potřebujeme sdílet přes všechny instance

	private readonly IClaimsCacheStore claimsCacheStore;
	private readonly IUserContextInfoBuilder contextInfoBuilder;
	private readonly ICustomClaimsBuilder customClaimsBuilder;

	public ApplicationClaimsTransformation(IClaimsCacheStore claimsCacheStore, IUserContextInfoBuilder contextInfoBuilder, ICustomClaimsBuilder customClaimsBuilder)
	{
		this.claimsCacheStore = claimsCacheStore;
		this.contextInfoBuilder = contextInfoBuilder;
		this.customClaimsBuilder = customClaimsBuilder;
	}

	/// <summary>
	/// Transformuje claims principla - přidá custom claims.
	/// </summary>
	public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
	{
		UserContextInfo userContextInfo = contextInfoBuilder.GetUserContextInfo(principal);

		// pro nepřihlášeného uživatele žádnou transformaci neprovádíme
		if (userContextInfo == null)
		{
			return await Task.FromResult(principal);
		}

		List<Claim> customClaims = claimsCacheStore.GetClaims(userContextInfo);
		if (customClaims == null)
		{
			await criticalSection.ExecuteActionAsync(userContextInfo, async () =>
			{
				customClaims = claimsCacheStore.GetClaims(userContextInfo);
				if (customClaims == null)
				{
					// pokud nejsou žádné claims v cache, získáme je a do cache uložíme,
					// ať je pro stejný context další request rychlejší
					customClaims = await customClaimsBuilder.GetCustomClaimsAsync(principal);
					claimsCacheStore.StoreClaims(userContextInfo, customClaims);
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
