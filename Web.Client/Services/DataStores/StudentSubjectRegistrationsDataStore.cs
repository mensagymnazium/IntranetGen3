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

	protected override Func<StudentSubjectRegistrationDto, int> KeySelector => registration => registration.SubjectId!.Value;
	protected override bool ShouldRefresh() => hasUnresolvedChanges;

	protected override async Task<IEnumerable<StudentSubjectRegistrationDto>> LoadDataAsync()
	{
		var dto = await studentSubjectRegistrationFacade.GetAllRegistrationsOfCurrentStudent();
		hasUnresolvedChanges = false;

		return dto ?? new();
	}

	private bool hasUnresolvedChanges = false;
	public void RegistrationsChanged()
	{
		hasUnresolvedChanges = true;
	}
}