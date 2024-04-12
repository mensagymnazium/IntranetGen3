using Havit.Blazor.Components.Web.Services.DataStores;
using MensaGymnazium.IntranetGen3.Contracts;

namespace MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

public interface IEducationalAreasDataStore : IDictionaryStaticDataStore<int, EducationalAreaDto>
{
}
