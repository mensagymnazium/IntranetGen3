using Havit.Blazor.Components.Web.Services.DataStores;
using MensaGymnazium.IntranetGen3.Contracts;

namespace MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

public class SubjectTypesDataStore : DictionaryStaticDataStore<int, SubjectTypeDto>, ISubjectTypesDataStore
{
	private readonly Func<ISubjectTypeFacade> subjectTypeFacade;

	public SubjectTypesDataStore(Func<ISubjectTypeFacade> subjectTypeFacade)
	{
		this.subjectTypeFacade = subjectTypeFacade;
	}

	protected override Func<SubjectTypeDto, int> KeySelector => (SubjectType) => SubjectType.Id;
	protected override bool ShouldRefresh() => false; // just hit F5 :-D

	protected async override Task<IEnumerable<SubjectTypeDto>> LoadDataAsync()
	{
		var dto = await subjectTypeFacade().GetAllSubjectTypesAsync();
		return dto ?? new List<SubjectTypeDto>();
	}
}
