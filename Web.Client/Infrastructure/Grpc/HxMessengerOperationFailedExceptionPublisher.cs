using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Havit.Blazor.Components.Web;
using Havit.Blazor.Components.Web.Bootstrap;
using Havit.Blazor.Grpc.Client.ServerExceptions;
using MensaGymnazium.IntranetGen3.Resources;
using Microsoft.Extensions.Localization;

namespace MensaGymnazium.IntranetGen3.Web.Client.Infrastructure.Grpc
{
	public class HxMessengerOperationFailedExceptionGrpcClientListener : IOperationFailedExceptionGrpcClientListener
	{
		private readonly IHxMessengerService messenger;
		private readonly IStringLocalizer<Global> localizer;

		public HxMessengerOperationFailedExceptionGrpcClientListener(IHxMessengerService messenger, IStringLocalizer<Global> localizer)
		{
			this.messenger = messenger;
			this.localizer = localizer;
		}

		public Task ProcessAsync(string errorMessage)
		{
			messenger.AddError(localizer["OperationFailedExceptionMessengerTitle"], errorMessage);

			return Task.CompletedTask;
		}
	}
}
