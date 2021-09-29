using Havit.Blazor.Components.Web.Services.DataStores;
using MensaGymnazium.IntranetGen3.Contracts.Crm;

namespace MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores
{
	public interface IContactReferenceDataStore : IDictionaryStaticDataStore<int, ContactReferenceVM>
	{
	}
}