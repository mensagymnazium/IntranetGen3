using Havit.Blazor.Components.Web.Services.DataStores;
using MensaGymnazium.IntranetGen3.Contracts.Security;

namespace MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

public class TeachersDataStore : DictionaryStaticDataStore<int, TeacherReferenceDto>, ITeachersDataStore
{
	private readonly ITeacherFacade TeacherFacade;

	public TeachersDataStore(ITeacherFacade TeacherFacade)
	{
		this.TeacherFacade = TeacherFacade;
	}

	protected override Func<TeacherReferenceDto, int> KeySelector => (Teacher) => Teacher.TeacherId;
	protected override bool ShouldRefresh() => false; // just hit F5 :-D

	protected async override Task<IEnumerable<TeacherReferenceDto>> LoadDataAsync()
	{
		var dto = await TeacherFacade.GetAllTeacherReferencesAsync();
		return dto ?? new List<TeacherReferenceDto>();
	}
}
