using Havit;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Electives;

public partial class StudentSubjectRegistrationComponent
{
	[Parameter] public int? SubjectId { get; set; } // Xopa: why is this nullable?

	[Parameter] public EventCallback OnRegistrationChanged { get; set; }

	[Inject] protected IHxMessageBoxService MessageBox { get; set; }
	[Inject] protected IHxMessengerService Messenger { get; set; }
	[Inject] protected ISubjectRegistrationsManagerFacade SubjectRegistrationsManagerFacade { get; set; }

	/// <summary>
	/// If registration type is null there is no registration, no registration was made by current user (student) for this subject
	/// //TODO: Replace with data from data store? This is now messy
	/// </summary>
	private StudentSubjectRegistrationDto studentsRegistrationForThisSubject;

	protected override async Task OnInitializedAsync()
	{
		studentsRegistrationForThisSubject = await SubjectRegistrationsManagerFacade.GetCurrentUserRegistrationForSubject(
			Dto.FromValue(SubjectId!.Value));
	}

	//private HxGrid<SigningRuleStudentRegistrationsDto> gridComponent;

	//private async Task<GridDataProviderResult<SigningRuleStudentRegistrationsDto>> GetGridData(GridDataProviderRequest<SigningRuleStudentRegistrationsDto> request)
	//{
	//	Contract.Assert<InvalidOperationException>(SubjectId is not null);

	//	var data = await SubjectRegistrationsManagerFacade.GetCurrentUserSubjectSigningRulesForRegistrationAsync(Dto.FromValue(SubjectId.Value));

	//	return request.ApplyTo(data);
	//}

	private async Task HandleCancelRegistrationClicked()
	{
		if (studentsRegistrationForThisSubject is null)
		{
			throw new InvalidOperationException("No registration was made by current user (student) for this subject.");
		}

		if (await MessageBox.ConfirmAsync("Opravdu chcete zrušit zápis?"))
		{
			try
			{
				await SubjectRegistrationsManagerFacade.CancelRegistrationAsync(Dto.FromValue(studentsRegistrationForThisSubject.Id));

				//await gridComponent.RefreshDataAsync();
				await OnRegistrationChanged.InvokeAsync();
			}
			catch (OperationFailedException)
			{
				//NOOP
			}
		}
	}

	private async Task HandleCreateRegistrationClicked(StudentRegistrationType registrationType)
	{
		if (await MessageBox.ConfirmAsync("Opravdu chcete vytvořit zápis?"))
		{
			try
			{
				await SubjectRegistrationsManagerFacade.CreateRegistrationAsync(
					new StudentSubjectRegistrationCreateDto()
					{
						SubjectId = SubjectId!.Value,
						//SigningRuleId = signingRuleId,
						RegistrationType = registrationType
					});

				//await gridComponent.RefreshDataAsync();
				await OnRegistrationChanged.InvokeAsync();
			}
			catch (OperationFailedException)
			{
				//NOOP
			}
		}
	}
}