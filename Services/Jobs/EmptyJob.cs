using Microsoft.Extensions.Logging;

namespace MensaGymnazium.IntranetGen3.Services.Jobs;

[Service(Profile = Jobs.ProfileName)]
public class EmptyJob : IEmptyJob
{
	private readonly ILogger<EmptyJob> logger;

	public EmptyJob(ILogger<EmptyJob> logger)
	{
		this.logger = logger;
	}

	public Task ExecuteAsync(CancellationToken cancellationToken)
	{
		logger.LogInformation("Begin: EmptyJob");

		// TODO await Task.Delay(5000, cancellationToken);

		logger.LogInformation("End: EmptyJob");

		return Task.CompletedTask;
	}
}
