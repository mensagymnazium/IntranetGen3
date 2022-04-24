using Havit;
using MensaGymnazium.IntranetGen3.Contracts;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Electives;

public partial class StudentSubjectRegistrationEdit
{
	[Parameter] public StudentSubjectRegistrationDto Value { get; set; }
	[Parameter] public EventCallback<StudentSubjectRegistrationDto> ValueChanged { get; set; }
	[Parameter] public EventCallback OnClosed { get; set; }

	[Inject] protected IStudentSubjectRegistrationFacade StudentSubjectRegistrationFacade { get; set; }

	private StudentSubjectRegistrationDto model;
	private EditContext editContext;
	private HxOffcanvas hxOffcanvas;

	protected override void OnParametersSet()
	{
		base.OnParametersSet();

		model = this.Value with { }; // Clone!
		editContext = new EditContext(model);
	}

	public async Task HandleValidSubmit()
	{
		try
		{
			if (model.Id == default)
			{
				model.Id = (await StudentSubjectRegistrationFacade.CreateRegistrationAsync(model)).Value;
			}
			else
			{
				await StudentSubjectRegistrationFacade.UpdateRegistrationAsync(model);
			}

			await hxOffcanvas.HideAsync();

			Value.UpdateFrom(model);
			await ValueChanged.InvokeAsync(this.Value);
		}
		catch (OperationFailedException)
		{
			// NOOP - The user should be able to fix the issues and repeat the action
		}
	}

	public Task ShowAsync() => hxOffcanvas.ShowAsync();

}