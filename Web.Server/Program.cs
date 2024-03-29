﻿using System.Runtime.InteropServices;

namespace MensaGymnazium.IntranetGen3.Web.Server;

public class Program
{
	public static void Main(string[] args)
	{
		CreateHostBuilder(args).Build().Run();
	}

	public static IHostBuilder CreateHostBuilder(string[] args) =>
		Host.CreateDefaultBuilder(args)
			.ConfigureWebHostDefaults(webBuilder =>
			{
				webBuilder.UseStartup<Startup>();
#if DEBUG
				webBuilder.UseEnvironment("Development"); // pro Red-Gate ANTS Performance Profiler
#endif
			})
			.ConfigureAppConfiguration((hostContext, config) =>
			{
				// delete all default configuration providers
				config.Sources.Clear();
				config
					.AddJsonFile("appsettings.WebServer.json", optional: false)
					.AddJsonFile($"appsettings.WebServer.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true)
					.AddJsonFile("appsettings.WebServer.local.json", optional: true)
					.AddJsonFile($"appsettings.WebServer.{hostContext.HostingEnvironment.EnvironmentName}.local.json", optional: true)
					.AddEnvironmentVariables();
			})
			.ConfigureLogging((hostingContext, logging) =>
			{
				logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
				logging.AddConsole();
				logging.AddDebug();
				logging.AddAzureWebAppDiagnostics();
#if !DEBUG
				if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
				{
					logging.AddEventLog();
				}
#endif
			});
}
