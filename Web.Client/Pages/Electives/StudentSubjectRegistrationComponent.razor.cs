using Havit;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Primitives;
using MensaGymnazium.IntranetGen3.Web.Client.Services;
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
	[Inject] protected IClientAuthService ClientAuthService { get; set; }
	[Inject] protected ISubjectsDataStore SubjectDataStore { get; set; }

	/// <summary>
	/// Show text about the rule, that some specialization seminars may be chosen as
	/// extension seminars after an agreement.
	/// </summary>
	private bool shouldShowExtensionSeminarWarning = false; // Todo: this probably won't be needed in the future

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
		await SubjectDataStore.EnsureDataAsync();

		await LoadIsRegistrationPossibleAsync();
		await LoadStudentRegistrationAsync();

		shouldShowExtensionSeminarWarning = await GetShouldShowExtensionSeminarWarning();
	}

	private async Task<bool> GetShouldShowExtensionSeminarWarning()
	{
		var claims = await ClientAuthService.GetCurrentClaimsPrincipal();

		// Check if is student
		if (!claims.IsInRole(nameof(Role.Student)))
		{
			return false;
		}

		// Don't show if seminar is an extension seminar already
		var subject = await SubjectDataStore.GetByKeyAsync(SubjectId.Value);
		var subjectCategory = await SubjectCategoriesDataStore.GetByKeyAsync(subject.CategoryId.Value);
		if ((SubjectCategoryEntry)subjectCategory.Id == SubjectCategoryEntry.ExtensionSeminar)
		{
			return false;
		}

		// Check based on grade
		var grade = await ClientAuthService.GetCurrentStudentGradeIdAsync();
		var nextGrade = grade.Value.NextGrade();

		return nextGrade is GradeEntry.Kvinta or GradeEntry.Sexta;
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
			await StudentSubjectRegistrationsDataStore.GetByKeyOrDefaultAsync(SubjectId.Value);
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
						SubjectId = SubjectId.Value,
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