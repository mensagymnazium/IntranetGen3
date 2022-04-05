using Havit.Blazor.Components.Web.Services.DataStores;
using MensaGymnazium.IntranetGen3.Contracts;

namespace MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

public class GradesDataStore : DictionaryStaticDataStore<int, GradeDto>, IGradesDataStore
{
	private readonly Func<IGradeFacade> GradeFacade;

	public GradesDataStore(Func<IGradeFacade> GradeFacade)
	{
		this.GradeFacade = GradeFacade;
	}

	protected override Func<GradeDto, int> KeySelector => (Grade) => Grade.Id;
	protected override bool ShouldRefresh() => false; // just hit F5 :-D

	protected async override Task<IEnumerable<GradeDto>> LoadDataAsync()
	{
		var dto = await GradeFacade().GetAllGradesAsync();
		return dto ?? new List<GradeDto>();
	}
}
