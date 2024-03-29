﻿using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace MensaGymnazium.IntranetGen3.Web.Client.Infrastructure.Security;

public class UserClientService : IUserClientService
{
	private readonly HttpClient httpClient;
	private readonly IConfiguration configuration;

	public UserClientService(
		HttpClient httpClient,
		IConfiguration configuration)
	{
		this.httpClient = httpClient;
		this.configuration = configuration;
	}

	public async Task<IEnumerable<Claim>> FetchAdditionalUserClaimsAsync(IAccessTokenProvider accessTokenProvider, CancellationToken cancellationToken = default)
	{
		// We cannot use facade (gRPC stack) as it is dependant on full user context
		var webServerScope = configuration["Auth:WebServerScope"];
		var result = await accessTokenProvider.RequestAccessToken(new AccessTokenRequestOptions() { Scopes = new[] { webServerScope } });

		if (result.TryGetToken(out var token))
		{
			var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "/user-claims");
			httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
			var response = await httpClient.SendAsync(request: httpRequestMessage, cancellationToken);
			var claims = await response.Content.ReadFromJsonAsync<List<KeyValuePair<string, string>>>();
			return claims.Select(c => new Claim(c.Key, c.Value ?? String.Empty));
		}

		return null;
	}
}
