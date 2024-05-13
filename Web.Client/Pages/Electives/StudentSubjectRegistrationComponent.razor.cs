using Havit;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Primitives;
using MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Electives;

public partial class StudentSubjectRegistrationComponent
{
	[Parameter] public int? SubjectId { get; set; } // Xopa: why is this nullable?

	[Parameter] public EventCallback OnRegistrationChanged { get; set; }

	[Inject] protected IHxMessageBoxService MessageBox { get; set; }
	[Inject] protected IHxMessengerService Messenger { get; set; }
	[Inject] protected ISubjectRegistrationsManagerFacade SubjectRegistrationsManagerFacade { get; set; }
	[Inject] protected IStudentSubjectRegistrationsDataStore StudentSubjectRegistrationsDataStore { get; set; }
	[Inject] protected ISubjectRegistrationProgressValidationFacade SubjectRegistrationProgressValidationFacade { get; set; }
	[Inject] protected ISubjectCategoriesDataStore SubjectCategoriesDataStore { get; set; }

	/// <summary>
	/// Registration was made by current user (student) for this subject
	/// If null: no registration
	/// </summary>
	private StudentSubjectRegistrationDto studentsRegistrationForThisSubject = null;

	/// <summary>
	/// Null when not yet loaded.
	/// </summary>
	private CanCreateRegistrationResponse canCreateMainRegistrationResult = null;

	protected override async Task OnInitializedAsync()
	{
		await LoadIsRegistrationPossibleAsync();
		await LoadStudentRegistrationAsync();
	}

	private async Task LoadIsRegistrationPossibleAsync()
	{
		// Test for main registration
		StudentSubjectRegistrationCreateDto mainRegistrationRequest = new StudentSubjectRegistrationCreateDto()
		{
			RegistrationType = StudentRegistrationType.Main,
			SubjectId = SubjectId
		};

		canCreateMainRegistrationResult = await SubjectRegistrationsManagerFacade
			.CanStudentCreateRegistrationAsync(mainRegistrationRequest);
	}

	private async Task LoadStudentRegistrationAsync()
	{
		await StudentSubjectRegistrationsDataStore.EnsureDataAsync();
		studentsRegistrationForThisSubject =
			await StudentSubjectRegistrationsDataStore.GetByKeyOrDefaultAsync(SubjectId!.Value);
	}

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

				// Invalidate data store
				StudentSubjectRegistrationsDataStore.Clear();

				await LoadStudentRegistrationAsync();
				await LoadIsRegistrationPossibleAsync();

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
						RegistrationType = registrationType
					});

				//Invalidate data store
				StudentSubjectRegistrationsDataStore.Clear();

				await LoadStudentRegistrationAsync();
				await LoadIsRegistrationPossibleAsync();

				await OnRegistrationChanged.InvokeAsync();
			}
			catch (OperationFailedException)
			{
				//NOOP
			}
		}
	}
}