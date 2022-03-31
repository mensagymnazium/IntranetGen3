using Havit.Blazor.Components.Web.Services.DataStores;
using MensaGymnazium.IntranetGen3.Contracts;

namespace MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

public class SubjectTypesDataStore : DictionaryStaticDataStore<int, SubjectTypeDto>, ISubjectTypesDataStore
{
	private readonly ISubjectTypeFacade SubjectTypeFacade;

	public SubjectTypesDataStore(ISubjectTypeFacade SubjectTypeFacade)
	{
		this.SubjectTypeFacade = SubjectTypeFacade;
	}

	protected override Func<SubjectTypeDto, int> KeySelector => (SubjectType) => SubjectType.Id;
	protected override bool ShouldRefresh() => false; // just hit F5 :-D

	protected async override Task<IEnumerable<SubjectTypeDto>> LoadDataAsync()
	{
		var dto = await SubjectTypeFacade.GetAllSubjectTypesAsync();
		return dto ?? new List<SubjectTypeDto>();
	}
}
