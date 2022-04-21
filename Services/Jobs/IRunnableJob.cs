namespace MensaGymnazium.IntranetGen3.Services.Jobs;

public interface IRunnableJob
{
	Task ExecuteAsync(CancellationToken cancellationToken);
}
