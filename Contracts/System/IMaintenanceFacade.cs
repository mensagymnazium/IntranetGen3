using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using Havit.ComponentModel;

namespace MensaGymnazium.IntranetGen3.Contracts.System
{
	[ApiContract]
	public interface IMaintenanceFacade
	{
		Task ClearCache(CancellationToken cancellationToken = default);
	}
}