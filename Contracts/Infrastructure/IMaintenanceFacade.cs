using Havit.ComponentModel;

namespace MensaGymnazium.IntranetGen3.Contracts.Infrastructure;

[ApiContract]
public interface IMaintenanceFacade
{
	Task ClearCache(CancellationToken cancellationToken = default);
}
