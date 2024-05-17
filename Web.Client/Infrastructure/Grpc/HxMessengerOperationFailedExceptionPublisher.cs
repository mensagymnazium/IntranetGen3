using Havit.Blazor.Grpc.Client.ServerExceptions;

namespace MensaGymnazium.IntranetGen3.Web.Client.Infrastructure.Grpc;

public class HxMessengerOperationFailedExceptionGrpcClientListener : IOperationFailedExceptionGrpcClientListener
{
	private readonly IHxMessengerService _messenger;

	public HxMessengerOperationFailedExceptionGrpcClientListener(IHxMessengerService messenger)
	{
		_messenger = messenger;
	}

	public Task ProcessAsync(string errorMessage)
	{
		_messenger.AddError("Něco se nepovedlo", errorMessage);

		return Task.CompletedTask;
	}
}
