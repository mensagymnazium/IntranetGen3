using Havit;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Admin;

public partial class GradeRegistrationCriteriaEdit
{
	[Parameter] public GradeRegistrationCriteriaDto Value { get; set; }
	[Parameter] public EventCallback<GradeRegistrationCriteriaDto> ValueChanged { get; set; }
	[Parameter] public EventCallback OnClosed { get; set; }

	[Inject] protected IGradeFacade GradeFacade { get; set; }
	[Inject] protected IGradesDataStore GradesDataStore { get; set; }

	private GradeRegistrationCriteriaDto model = new();
	private EditContext editContext;
	private HxOffcanvas hxOffcanvas;

	protected override Task OnInitializedAsync()
	{
		return GradesDataStore.EnsureDataAsync();
	}

	protected override void OnParametersSet()
	{
		base.OnParametersSet();

		model = this.Value with { };
		editContext = new EditContext(model);
	}

	public async Task HandleValidSubmit()
	{
		try
		{
			await GradeFacade.UpdateGradeRegistrationCriteriaAsync(model);

			await hxOffcanvas.HideAsync();

			Value = model with { };
			await ValueChanged.InvokeAsync(this.Value);
		}
		catch (OperationFailedException)
		{
			// NOOP - The user should be able to fix the issues and repeat the action
		}
	}

	public Task ShowAsync() => hxOffcanvas.ShowAsync();
}