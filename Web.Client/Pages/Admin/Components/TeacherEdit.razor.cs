using Havit;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Contracts.Security;
using Microsoft.AspNetCore.Components;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Admin.Components;

public partial class TeacherEdit : ComponentBase
{
	[Parameter] public EventCallback OnSaved { get; set; }

	[Inject] protected Func<ITeacherFacade> TeacherFacade { get; set; }
	[Inject] protected IHxMessengerService Messenger { get; set; }

	private HxOffcanvas offcanvasComponent;
	private TeacherDto model = new TeacherDto();
	private EditContext editContext;
	private string title;

	public async Task ShowAsync(int teacherId)
	{
		model = await TeacherFacade().GetTeacherDetailAsync(Dto.FromValue(teacherId));
		editContext = new EditContext(model);
		title = model.Name;

		await offcanvasComponent.ShowAsync();
	}

	private async Task HandleValidSubmit()
	{
		try
		{
			await TeacherFacade().UpdateTeacherAsync(model);

			await offcanvasComponent.HideAsync();
			Messenger.AddInformation(model.Name, "Učitel uložen.");
			await OnSaved.InvokeAsync();
		}
		catch (OperationFailedException)
		{
			// NOOP - The user should be able to fix the issues and repeat the action
		}
	}
}
