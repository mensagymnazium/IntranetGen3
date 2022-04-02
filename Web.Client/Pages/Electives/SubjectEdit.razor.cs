using Havit;
using MensaGymnazium.IntranetGen3.Contracts;
using Microsoft.AspNetCore.Components;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Electives;

public partial class SubjectEdit
{
	[Parameter] public int? SubjectId { get; set; }
	[Parameter] public EventCallback<int> OnSaved { get; set; }

	[Inject] protected ISubjectFacade SubjectFacade { get; set; }

	private HxOffcanvas offcanvasComponent;
	private SubjectDto model = new();
	private EditContext editContext;
	private string title;

	public async Task ShowAsync()
	{
		if (SubjectId is null)
		{
			model = new();
			editContext = new EditContext(model);
			title = "Nový předmět";
		}
		else if (SubjectId != model.Id)
		{
			model = await SubjectFacade.GetSubjectDetailAsync(Dto.FromValue(SubjectId.Value));
			editContext = new EditContext(model);
			title = model.Name;
		}

		await offcanvasComponent.ShowAsync();
	}

	private async Task HandleValidSubmit()
	{
		try
		{
			if (model.Id == default)
			{
				model.Id = (await SubjectFacade.CreateSubjectAsync(model)).Value;
			}
			else
			{
				await SubjectFacade.UpdateSubjectAsync(model);
			}

			await offcanvasComponent.HideAsync();
			await OnSaved.InvokeAsync(model.Id);
		}
		catch (OperationFailedException)
		{
			// NOOP - The user should be able to fix the issues and repeat the action
		}
	}
}
