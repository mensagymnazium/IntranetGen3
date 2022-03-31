using Havit.Blazor.Grpc.Client.ServerExceptions;

namespace MensaGymnazium.IntranetGen3.Web.Client.Infrastructure.Grpc;

public class HxMessengerOperationFailedExceptionGrpcClientListener : IOperationFailedExceptionGrpcClientListener
{
	private readonly IHxMessengerService messenger;

	public HxMessengerOperationFailedExceptionGrpcClientListener(IHxMessengerService messenger)
	{
		this.messenger = messenger;
	}

	public Task ProcessAsync(string errorMessage)
	{
		messenger.AddError("Něco se nepovedlo", errorMessage);

		return Task.CompletedTask;
	}
}
