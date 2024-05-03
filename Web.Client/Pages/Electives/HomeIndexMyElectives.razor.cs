using MensaGymnazium.IntranetGen3.Contracts;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Electives;

public partial class HomeIndexMyElectives
{
	[Inject]
	protected ISubjectRegistrationProgressValidationFacade SubjectRegistrationProgressValidationFacade { get; set; }

	private StudentRegistrationProgressDto studentsProgress;

	protected override async Task OnInitializedAsync()
	{
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