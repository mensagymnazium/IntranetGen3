using Havit.Blazor.Components.Web.Services.DataStores;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Contracts.Security;

namespace MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

public interface ISubjectCategoriesDataStore : IDictionaryStaticDataStore<int, SubjectCategoryDto>
{
}
