using System.Globalization;
using BlazorApplicationInsights;
using FluentValidation;
using Havit.Blazor.Grpc.Client;
using Havit.Blazor.Grpc.Client.ServerExceptions;
using Havit.Blazor.Grpc.Client.WebAssembly;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Contracts.Infrastructure;
using MensaGymnazium.IntranetGen3.Web.Client.Infrastructure.Grpc;
using MensaGymnazium.IntranetGen3.Web.Client.Infrastructure.Security;
using MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace MensaGymnazium.IntranetGen3.Web.Client;

public class Program
{
	public static async Task Main(string[] args)
	{
		var cultureInfo = new CultureInfo("cs-CZ");
		CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
		CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

		var builder = WebAssemblyHostBuilder.CreateDefault(args);

		AddLoggingAndApplicationInsights(builder);

		builder.RootComponents.Add<App>("app");

		//builder.Services.AddHttpClient("MensaGymnazium.IntranetGen3.Web.Server", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
		//	.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
		builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
		//builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
		//	.CreateClient("MensaGymnazium.IntranetGen3.Web.Server"));
		AddAuth(builder);

		builder.Services.AddValidatorsFromAssemblyContaining<Dto<object>>();

		builder.Services.AddHxServices();
		builder.Services.AddHxMessenger();
		builder.Services.AddHxMessageBoxHost();
		SetHxComponents();

		builder.Services.AddScoped<ITeachersDataStore, TeachersDataStore>();
		builder.Services.AddScoped<ISubjectTypesDataStore, SubjectTypesDataStore>();
		builder.Services.AddScoped<ISubjectCategoriesDataStore, SubjectCategoriesDataStore>();
		builder.Services.AddScoped<IGradesDataStore, GradesDataStore>();

		AddGrpcClient(builder);

		WebAssemblyHost webAssemblyHost = builder.Build();

		await webAssemblyHost.RunAsync();
	}

	private static void AddAuth(WebAssemblyHostBuilder builder)
	{
		builder.Services.AddMsalAuthentication(options =>
		{
			builder.Configuration.Bind("AzureAd", options.ProviderOptions);
			options.ProviderOptions.LoginMode = "redirect";
			options.UserOptions.RoleClaim = "role";
		});

		builder.Services.AddScoped(typeof(AccountClaimsPrincipalFactory<RemoteUserAccount>), typeof(CustomAccountClaimsPrincipalFactory));
		builder.Services.AddApiAuthorization();
		builder.Services.AddScoped<IUserClientService, UserClientService>();
	}

	private static void SetHxComponents()
	{
		// HxProgressIndicator.DefaultDelay = 0;
	}

	private static void AddGrpcClient(WebAssemblyHostBuilder builder)
	{
		builder.Services.AddTransient<IOperationFailedExceptionGrpcClientListener, HxMessengerOperationFailedExceptionGrpcClientListener>();
		builder.Services.AddTransient<AuthorizationGrpcClientInterceptor>();
		builder.Services.AddGrpcClientInfrastructure(assemblyToScanForDataContracts: typeof(Dto).Assembly);
		builder.Services.AddGrpcClientsByApiContractAttributes(
			typeof(IDataSeedFacade).Assembly,
			configureGrpcClientWithAuthorization: grpcClient =>
			{
				grpcClient.AddHttpMessageHandler(provider =>
				{
					var navigationManager = provider.GetRequiredService<NavigationManager>();
					var backendUrl = navigationManager.BaseUri;

					return provider.GetRequiredService<AuthorizationMessageHandler>()
						.ConfigureHandler(authorizedUrls: new[] { backendUrl }); // TODO? as neede: , scopes: new[] { "havit-IntranetGen3-api" });
				})
				.AddInterceptor<AuthorizationGrpcClientInterceptor>();
			});
	}

	private static void AddLoggingAndApplicationInsights(WebAssemblyHostBuilder builder)
	{
		var instrumentationKey = builder.Configuration.GetValue<string>("ApplicationInsights:InstrumentationKey");

		builder.Services.AddBlazorApplicationInsights(async applicationInsights =>
		{
			await applicationInsights.SetInstrumentationKey(instrumentationKey);
			await applicationInsights.LoadAppInsights();

			var telemetryItem = new TelemetryItem()
			{
				Tags = new Dictionary<string, object>()
				{
					{ "ai.cloud.role", "Web.Client" },
					// { "ai.cloud.roleInstance", "..." },
				}
			};

			await applicationInsights.AddTelemetryInitializer(telemetryItem);
		}, addILoggerProvider: true);

		builder.Logging.AddFilter<ApplicationInsightsLoggerProvider>(level => (level == LogLevel.Error) || (level == LogLevel.Critical));

#if DEBUG
		builder.Logging.SetMinimumLevel(LogLevel.Debug);
#endif
	}
}
