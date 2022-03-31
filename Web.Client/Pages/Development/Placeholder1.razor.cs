using MensaGymnazium.IntranetGen3.Contracts;
using Microsoft.AspNetCore.Components;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Development;

public partial class Placeholder1
{
	[Inject] protected IGradeFacade GradeFacade { get; set; }

	private List<GradeDto> grades;

	protected override async Task OnInitializedAsync()
	{
		grades = await GradeFacade.GetAllGradesAsync();
	}
}
