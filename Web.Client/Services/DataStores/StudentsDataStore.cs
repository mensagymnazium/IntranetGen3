using Havit.Blazor.Components.Web.Services.DataStores;
using MensaGymnazium.IntranetGen3.Contracts.Security;

namespace MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

public class StudentsDataStore : DictionaryStaticDataStore<int, StudentReferenceDto>, IStudentsDataStore
{
	private readonly IStudentFacade studentFacade;

	public StudentsDataStore(IStudentFacade studentFacade)
	{
		this.studentFacade = studentFacade;
	}

	protected override Func<StudentReferenceDto, int> KeySelector => (s) => s.Id;
	protected override bool ShouldRefresh() => false; // just hit F5 :-D

	protected async override Task<IEnumerable<StudentReferenceDto>> LoadDataAsync()
	{
		var dto = await studentFacade.GetAllStudentReferencesAsync();
		return dto ?? new List<StudentReferenceDto>();
	}
}
