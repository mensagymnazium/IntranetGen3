using Havit.Blazor.Components.Web.Services.DataStores;
using MensaGymnazium.IntranetGen3.Contracts;

namespace MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

public class GraduationSubjectsDataStore : DictionaryStaticDataStore<int, GraduationSubjectDto>,
	IGraduationSubjectsDataStore
{
	private readonly IGraduationSubjectFacade _graduationSubjectFacade;
	
	public GraduationSubjectsDataStore(IGraduationSubjectFacade graduationSubjectFacade)
	{
		this._graduationSubjectFacade = graduationSubjectFacade;
	}
	
	protected override Func<GraduationSubjectDto, int> KeySelector => graduationSubjectDto => graduationSubjectDto.Id;
	protected override bool ShouldRefresh() => false; // just hit F5 :-D
	
	protected async override Task<IEnumerable<GraduationSubjectDto>> LoadDataAsync()
	{
		var dto = await _graduationSubjectFacade.GetAllGraduationSubjectsAsync();
		return dto ?? new List<GraduationSubjectDto>();
	}
}