using Havit;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Primitives;
using Microsoft.AspNetCore.Components;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Electives;

public partial class SubjectEdit : ComponentBase
{
	[Parameter] public int? SubjectId { get; set; }
	[Parameter] public EventCallback<int> OnSaved { get; set; }

	[Inject] protected Func<ISubjectFacade> SubjectFacade { get; set; }

	private HxOffcanvas offcanvasComponent;
	private SubjectDto model;
	private EditContext editContext;
	private string title;

	public SubjectEdit()
	{
		model = CreateModelWithDefaults();
	}

	public async Task ShowAsync()
	{
		if (SubjectId is null)
		{
			model = CreateModelWithDefaults();
			editContext = new EditContext(model);
			title = "Nový předmět";
		}
		else if (SubjectId != model.Id)
		{
			model = await SubjectFacade().GetSubjectDetailAsync(Dto.FromValue(SubjectId.Value));
			editContext = new EditContext(model);
			title = model.Name;
		}

		await offcanvasComponent.ShowAsync();
	}

	private SubjectDto CreateModelWithDefaults()
	{
		var result = new SubjectDto();
		result.GradeIds = new() { (int)GradeEntry.Prima, (int)GradeEntry.Sekunda, (int)GradeEntry.Tercie, (int)GradeEntry.Kvarta, (int)GradeEntry.Kvinta, (int)GradeEntry.Sexta, (int)GradeEntry.Septima, (int)GradeEntry.Oktava };
		result.CategoryId = 1; /* SubjectCategory.Entry.GraduationalSeminar */
		result.SubjectTypeIds = new() { 4 /* SubjectType.Entry.Informatics */ };

		return result;
	}

	private async Task HandleValidSubmit()
	{
		try
		{
			if (model.Id == default)
			{
				Console.WriteLine(model.GradeIds.Count);
				model.Id = (await SubjectFacade().CreateSubjectAsync(model)).Value;
			}
			else
			{
				await SubjectFacade().UpdateSubjectAsync(model);
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
