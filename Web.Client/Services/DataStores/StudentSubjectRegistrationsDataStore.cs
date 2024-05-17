using Havit.Blazor.Components.Web.Services.DataStores;
using MensaGymnazium.IntranetGen3.Contracts;

namespace MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

/// <summary>
/// The key of the registration is actually the <see cref="StudentSubjectRegistrationCreateDto.SubjectId"/>!!
/// This only stores registrations of the current student!
/// </summary>
public class StudentSubjectRegistrationsDataStore : DictionaryStaticDataStore<int, StudentSubjectRegistrationDto>, IStudentSubjectRegistrationsDataStore
{
	private IStudentSubjectRegistrationFacade studentSubjectRegistrationFacade;
	public StudentSubjectRegistrationsDataStore(IStudentSubjectRegistrationFacade studentSubjectRegistrationFacade)
	{
		this.studentSubjectRegistrationFacade = studentSubjectRegistrationFacade;
	}

	protected override Func<StudentSubjectRegistrationDto, int> KeySelector => registration => registration.SubjectId.Value;
	protected override bool ShouldRefresh() => false; // Cleared by component causing changes

	protected override async Task<IEnumerable<StudentSubjectRegistrationDto>> LoadDataAsync()
	{
		var dto = await studentSubjectRegistrationFacade.GetAllRegistrationsOfCurrentStudentAsync();

		return dto ?? new();
	}
}