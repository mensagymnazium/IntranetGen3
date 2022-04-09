using System.Text.Json;
using Havit;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Electives;

public partial class StudentSubjectRegistrationComponent
{
	[Parameter] public int? SubjectId { get; set; }

	[Parameter] public EventCallback OnRegistrationChanged { get; set; }

	[Inject] protected IHxMessageBoxService MessageBox { get; set; }
	[Inject] protected Func<ISubjectRegistrationsManagerFacade> SubjectRegistrationsManagerFacade { get; set; }

	private HxGrid<StudentSubjectRegistrationComponentDataItem> gridComponent;

	private async Task<GridDataProviderResult<StudentSubjectRegistrationComponentDataItem>> GetGridData(GridDataProviderRequest<StudentSubjectRegistrationComponentDataItem> request)
	{
		var signingRulesWithRegistrations = await SubjectRegistrationsManagerFacade().GetCurrentUserSigningRulesWithRegistrationsAsync(Dto.FromValue(SubjectId));
		Console.WriteLine(JsonSerializer.Serialize(signingRulesWithRegistrations));

		var data = signingRulesWithRegistrations.Select(sr => new StudentSubjectRegistrationComponentDataItem()
		{
			Id = sr.Id,
			Name = sr.Name,
			MainRegistration = sr.Registrations.FirstOrDefault(r => (r.SubjectId == this.SubjectId)
																&& (r.RegistrationType == StudentRegistrationType.Main)),
			SecondaryRegistration = sr.Registrations.FirstOrDefault(r => (r.SubjectId == this.SubjectId)
																&& (r.RegistrationType == StudentRegistrationType.Secondary)),
			MainRegistrationAllowed = (sr.Registrations.Count(r => r.RegistrationType == StudentRegistrationType.Main) < sr.Quantity),
			SecondaryRegistrationAllowed = (sr.Registrations.Count(r => r.RegistrationType == StudentRegistrationType.Secondary) < sr.Quantity),
		});

		return request.ApplyTo(data);
	}

	private async Task HandleCancelRegistrationClicked(int registrationId)
	{
		if (await MessageBox.ConfirmAsync("Opravdu chcete zrušit zápis?"))
		{
			try
			{
				await SubjectRegistrationsManagerFacade().CancelRegistrationAsync(Dto.FromValue(registrationId));
			}
			catch (OperationFailedException)
			{
				// NOOP
			}
		}

		await gridComponent.RefreshDataAsync();
		await OnRegistrationChanged.InvokeAsync();
	}

	private async Task HandleCreateRegistrationClicked(int signingRuleId, StudentRegistrationType registrationType)
	{
		if (await MessageBox.ConfirmAsync("Opravdu chcete vytvořit zápis?"))
		{
			try
			{
				await SubjectRegistrationsManagerFacade().CreateRegistrationAsync(new StudentSubjectRegistrationCreateDto()
				{
					SubjectId = SubjectId.Value,
					SigningRuleId = signingRuleId,
					RegistrationType = registrationType
				});
			}
			catch (OperationFailedException)
			{
				// NOOP
			}
		}

		await gridComponent.RefreshDataAsync();
		await OnRegistrationChanged.InvokeAsync();
	}

	protected record StudentSubjectRegistrationComponentDataItem
	{
		public int Id { get; internal set; }
		public string Name { get; internal set; }
		public StudentSubjectRegistrationDto MainRegistration { get; internal set; }
		public StudentSubjectRegistrationDto SecondaryRegistration { get; internal set; }
		public bool MainRegistrationAllowed { get; internal set; }
		public bool SecondaryRegistrationAllowed { get; internal set; }
	}
}