using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Primitives;
using MensaGymnazium.IntranetGen3.Web.Client.Services;
using MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Electives;

public partial class HomeIndexMyElectives
{
	[Inject] protected ISubjectRegistrationProgressValidationFacade SubjectRegistrationProgressValidationFacade { get; set; }
	[Inject] protected IClientAuthService ClientAuthService { get; set; }
	[Inject] protected IStudentSubjectRegistrationFacade StudentSubjectRegistrationFacade { get; set; }
	[Inject] protected ISubjectsDataStore SubjectDataStore { get; set; }

	private StudentRegistrationProgressDto studentsProgress;
	private List<StudentSubjectRegistrationDto> subjectIds;
	private List<SubjectReferenceDto> subjects = new List<SubjectReferenceDto>();
	private bool subjectsCollide;


	protected override async Task OnInitializedAsync()
	{
		var user = await ClientAuthService.GetCurrentClaimsPrincipal();
		if (!user.IsInRole(nameof(Role.Student)))
		{
			return;
		}
		await SubjectDataStore.EnsureDataAsync();

		studentsProgress = await SubjectRegistrationProgressValidationFacade.GetProgressOfCurrentStudentAsync();

		subjectIds = await StudentSubjectRegistrationFacade.GetAllRegistrationsOfCurrentStudentAsync();
		foreach (var subjectId in subjectIds)
		{
			subjects.Add(await SubjectDataStore.GetByKeyAsync(subjectId.SubjectId.Value));
			for (int i = 0; i < subjects.Count() - 1; i++)
			{
				if (subjects[i].ScheduleDayOfWeek == subjects[subjects.Count() - 1].ScheduleDayOfWeek && subjects[i].ScheduleSlotInDay == subjects[subjects.Count() - 1].ScheduleSlotInDay)
				{
					subjectsCollide = true;
				}
			}
		}

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