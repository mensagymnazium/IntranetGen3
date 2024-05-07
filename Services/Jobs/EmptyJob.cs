using Microsoft.Extensions.Logging;

namespace MensaGymnazium.IntranetGen3.Services.Jobs;

[Service(Profile = Jobs.ProfileName)]
public class EmptyJob : IEmptyJob
{
	private readonly ILogger<EmptyJob> _logger;

	public EmptyJob(ILogger<EmptyJob> logger)
	{
		_logger = logger;
	}

	public Task ExecuteAsync(CancellationToken cancellationToken)
	{
		_logger.LogInformation("Begin: EmptyJob");

		// TODO await Task.Delay(5000, cancellationToken);

		_logger.LogInformation("End: EmptyJob");

		return Task.CompletedTask;
	}
}
