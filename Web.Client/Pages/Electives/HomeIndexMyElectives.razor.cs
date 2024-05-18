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

		await CheckIfSubjectsCollideAsync();
	}

	private async Task CheckIfSubjectsCollideAsync()
	{
		var subjects = new List<SubjectReferenceDto>();
		var subjectIds = await StudentSubjectRegistrationFacade.GetAllActiveRegistrationsOfCurrentStudentAsync();
		foreach (var subjectId in subjectIds)
		{
			var subject = await SubjectDataStore.GetByKeyAsync(subjectId.SubjectId.Value);
			foreach (var otherSubject in subjects)
			{
				if ((subject.ScheduleDayOfWeek == otherSubject.ScheduleDayOfWeek)
					&& (subject.ScheduleSlotInDay == otherSubject.ScheduleSlotInDay))
				{
					subjectsCollide = true;
				}
			}
			subjects.Add(subject);
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