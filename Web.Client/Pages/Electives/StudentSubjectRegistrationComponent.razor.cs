using Havit;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Electives;

public partial class StudentSubjectRegistrationComponent
{
	[Parameter] public int? SubjectId { get; set; }

	[Parameter] public EventCallback OnRegistrationChanged { get; set; }

	[Inject] protected IHxMessageBoxService MessageBox { get; set; }
	[Inject] protected IHxMessengerService Messenger { get; set; }
	[Inject] protected ISubjectRegistrationsManagerFacade SubjectRegistrationsManagerFacade { get; set; }

	private HxGrid<SigningRuleStudentRegistrationsDto> gridComponent;

	private async Task<GridDataProviderResult<SigningRuleStudentRegistrationsDto>> GetGridData(GridDataProviderRequest<SigningRuleStudentRegistrationsDto> request)
	{
		Contract.Assert<InvalidOperationException>(SubjectId is not null);

		var data = await SubjectRegistrationsManagerFacade.GetCurrentUserSubjectSigningRulesForRegistrationAsync(Dto.FromValue(SubjectId.Value));

		return request.ApplyTo(data);
	}

	private async Task HandleCancelRegistrationClicked(int registrationId)
	{
		if (await MessageBox.ConfirmAsync("Opravdu chcete zrušit zápis?"))
		{
			try
			{
				await SubjectRegistrationsManagerFacade.CancelRegistrationAsync(Dto.FromValue(registrationId));

				await gridComponent.RefreshDataAsync();
				await OnRegistrationChanged.InvokeAsync();
			}
			catch (OperationFailedException)
			{
				//NOOP
			}
		}
	}

	private async Task HandleCreateRegistrationClicked(int signingRuleId, StudentRegistrationType registrationType)
	{
		if (await MessageBox.ConfirmAsync("Opravdu chcete vytvořit zápis?"))
		{
			try
			{
				await SubjectRegistrationsManagerFacade.CreateRegistrationAsync(
					new StudentSubjectRegistrationCreateDto()
					{
						SubjectId = SubjectId.Value,
						SigningRuleId = signingRuleId,
						RegistrationType = registrationType
					});

				await gridComponent.RefreshDataAsync();
				await OnRegistrationChanged.InvokeAsync();
			}
			catch (OperationFailedException)
			{
				//NOOP
			}
		}
	}
}