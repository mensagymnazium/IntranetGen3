using Havit.Collections;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Web.Client.Services;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Electives;

public partial class HomeIndexMyElectives
{
	[Inject] protected ISubjectRegistrationProgressValidationFacade SubjectRegistrationProgressValidationFacade { get; set; }
	[Inject] protected IClientAuthService ClientAuthService { get; set; }

	private StudentRegistrationProgressDto studentsProgress;


	protected override async Task OnAfterRenderAsync(bool firstRender)
	{
		if (!firstRender)
		{
			return;
		}

		var user = await ClientAuthService.GetCurrentClaimsPrincipal();
		if (!user.IsInRole("Student"))
		{
			return;
		}

		studentsProgress = await SubjectRegistrationProgressValidationFacade.GetProgressOfCurrentStudentAsync();

		StateHasChanged();
	}
}