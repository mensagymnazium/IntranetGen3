using Havit.Blazor.Components.Web.Services.DataStores;
using MensaGymnazium.IntranetGen3.Contracts;

namespace MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

public class SubjectsDataStore : DictionaryStaticDataStore<int, SubjectReferenceDto>, ISubjectsDataStore
{
	private readonly ISubjectFacade subjectFacade;

	public SubjectsDataStore(ISubjectFacade subjectFacade)
	{
		this.subjectFacade = subjectFacade;
	}

	protected override Func<SubjectReferenceDto, int> KeySelector => (s) => s.Id;
	protected override bool ShouldRefresh() => false; // just hit F5 :-D

	protected async override Task<IEnumerable<SubjectReferenceDto>> LoadDataAsync()
	{
		var dto = await subjectFacade.GetAllSubjectReferencesAsync();
		return dto ?? new List<SubjectReferenceDto>();
	}
}
