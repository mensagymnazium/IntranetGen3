using Havit.Collections;
using MensaGymnazium.IntranetGen3.Contracts;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Electives;

public partial class HomeIndexMyElectives
{
	[Inject] protected ISubjectRegistrationProgressValidationFacade SubjectRegistrationProgressValidationFacade { get; set; }

	private StudentRegistrationProgressDto studentsProgress;

	protected override async Task OnInitializedAsync()
	{
		studentsProgress = await SubjectRegistrationProgressValidationFacade.GetProgressOfCurrentStudentAsync();
	}
}