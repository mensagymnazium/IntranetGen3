using Havit.Collections;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Web.Client.Services;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Electives;

public partial class HomeIndexMyElectives
{
	[Inject] protected ISubjectRegistrationProgressValidationFacade SubjectRegistrationProgressValidationFacade { get; set; }
	[Inject] protected IClientAuthService ClientAuthService { get; set; }

	private StudentRegistrationProgressDto studentsProgress;

	protected override async Task OnInitializedAsync()
	{
		var user = await ClientAuthService.GetCurrentClaimsPrincipal();
		if (!user.IsInRole("Student"))
		{
			return;
		}

    studentsProgress = await SubjectRegistrationProgressValidationFacade.GetProgressOfCurrentStudentAsync();
	}

	private string GetHoursWithGrammar(int hours)
	{
		var word = hours switch
		{
			1 => "hodinu",
			2 or 3 or 4 => "hodiny",
			_ => "hodin"
		};

		return $"{hours} {word}";
	}
}