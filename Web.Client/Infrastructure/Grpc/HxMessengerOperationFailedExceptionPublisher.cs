using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Havit.Blazor.Components.Web;
using Havit.Blazor.Components.Web.Bootstrap;
using Havit.Blazor.Grpc.Client.ServerExceptions;

namespace MensaGymnazium.IntranetGen3.Web.Client.Infrastructure.Grpc
{
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
}
