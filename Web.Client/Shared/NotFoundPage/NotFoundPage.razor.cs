using MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

namespace MensaGymnazium.IntranetGen3.Web.Client.Shared.NotFoundPage;
public partial class NotFoundPage
{
	string teacherName {  get; set; }
	string teacherFunFact {  get; set; }
	
	[Inject] ITeachersDataStore teachersDataStore { get; set; }
	protected override async Task OnInitializedAsync()
	{
		await teachersDataStore.EnsureDataAsync();

		var teachers = await teachersDataStore.GetAllAsync();
		var teacherArr = teachers.ToArray();
		var teacher = teacherArr[Random.Shared.Next(0, teacherArr.Length-1)];
		this.teacherName = teacher.Name;
		this.teacherFunFact = teacher.FunFact;

				
	}


	public void HandleBackClick()
	{
		NavigationManager.NavigateTo("/");
	}
}