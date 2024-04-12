using Havit.Blazor.Components.Web.Services.DataStores;
using MensaGymnazium.IntranetGen3.Contracts;

namespace MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

public class EducationalAreasDataStore : DictionaryStaticDataStore<int, EducationalAreaDto>, IEducationalAreasDataStore
{
	private readonly IEducationalAreaFacade _educationalAreaFacade;

	public EducationalAreasDataStore(IEducationalAreaFacade educationalAreaFacade)
	{
		this._educationalAreaFacade = educationalAreaFacade;
	}

	protected override Func<EducationalAreaDto, int> KeySelector => educationalAreaDto => educationalAreaDto.Id;
	protected override bool ShouldRefresh() => false; // just hit F5 :-D

	protected async override Task<IEnumerable<EducationalAreaDto>> LoadDataAsync()
	{
		var dto = await _educationalAreaFacade.GetAllEducationalAreasAsync();
		return dto ?? new List<EducationalAreaDto>();
	}
}
