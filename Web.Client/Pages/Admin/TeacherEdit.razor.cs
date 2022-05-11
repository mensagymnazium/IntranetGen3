using Havit;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Contracts.Security;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Admin;

public partial class TeacherEdit
{
	[Parameter] public TeacherDto Value { get; set; }
	[Parameter] public EventCallback<TeacherDto> ValueChanged { get; set; }
	[Parameter] public EventCallback OnClosed { get; set; }

	[Inject] protected ITeacherFacade TeacherFacade { get; set; }

	private TeacherDto model;
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
				model.Id = (await TeacherFacade.CreateTeacherAsync(model)).Value;
			}
			else
			{
				await TeacherFacade.UpdateTeacherAsync(model);
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