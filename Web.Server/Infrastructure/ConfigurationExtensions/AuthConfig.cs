using System.IdentityModel.Tokens.Jwt;
using System.Net;
using MensaGymnazium.IntranetGen3.Facades.Infrastructure.Security;
using MensaGymnazium.IntranetGen3.Facades.Infrastructure.Security.Authentication;
using MensaGymnazium.IntranetGen3.Facades.Infrastructure.Security.Claims;
using MensaGymnazium.IntranetGen3.Primitives;
using MensaGymnazium.IntranetGen3.Web.Server.Infrastructure.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.Net.Http.Headers;

namespace MensaGymnazium.IntranetGen3.Web.Server.Infrastructure.ConfigurationExtensions;

public static class AuthConfig
{
	public static void AddCustomizedAuth(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			.AddMicrosoftIdentityWebApi(configuration.GetSection("AzureAd"));

		JsonWebTokenHandler.DefaultInboundClaimTypeMap.Clear();

		services.Configure<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme, options =>
		{
			options.TokenValidationParameters.NameClaimType = "name";
		});

		services.AddScoped<IApplicationAuthenticationService, ApplicationAuthenticationService>();
		services.AddScoped<IUserContextInfoBuilder, UserContextInfoBuilder>();

		services.ConfigureApplicationCookie(configuration =>
		{
			// Do not redirect API calls - customization to include gRPC calls
			// https://github.com/dotnet/aspnetcore/blob/main/src/Security/Authentication/Cookies/src/CookieAuthenticationEvents.cs
			configuration.Events.OnRedirectToLogin = (context) => RedirectOrApiStatus(context, HttpStatusCode.Unauthorized);
			configuration.Events.OnRedirectToAccessDenied = (context) => RedirectOrApiStatus(context, HttpStatusCode.Forbidden);
		});
	}

	private static Task RedirectOrApiStatus(RedirectContext<CookieAuthenticationOptions> context, HttpStatusCode apiStatus)
	{
		if (IsApiRequest(context.Request))
		{
			context.Response.Headers[HeaderNames.Location] = context.RedirectUri;
			context.Response.StatusCode = (int)apiStatus;
		}
		else
		{
			context.Response.Redirect(context.RedirectUri);
		}
		return Task.CompletedTask;
	}

	private static bool IsApiRequest(HttpRequest request)
	{
		return
			request.Headers[HeaderNames.ContentType].ToString().StartsWith("application/grpc", StringComparison.Ordinal) // gRPC-Web
			|| String.Equals(request.Query[HeaderNames.XRequestedWith], "XMLHttpRequest", StringComparison.Ordinal) // AJAX
			|| String.Equals(request.Headers[HeaderNames.XRequestedWith], "XMLHttpRequest", StringComparison.Ordinal); // AJAX
	}
}
