using Havit;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories.Security;
using MensaGymnazium.IntranetGen3.Model;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Services.SubjectRegistration.ProgressValidation;

[Service]
public sealed class SubjectRegistrationProgressValidationService : ISubjectRegistrationProgressValidationService
{
	private readonly IStudentRepository studentRepository;
	private readonly IStudentSubjectRegistrationRepository subjectRegistrationRepository;
	private readonly IGradeRepository gradeRepository;
	public SubjectRegistrationProgressValidationService(
		IStudentRepository studentRepository,
		IStudentSubjectRegistrationRepository subjectRegistrationRepository,
		IGradeRepository gradeRepository)
	{
		this.studentRepository = studentRepository;
		this.subjectRegistrationRepository = subjectRegistrationRepository;
		this.gradeRepository = gradeRepository;
	}

	public async Task<StudentRegistrationProgress> GetRegistrationProgressOfStudentAsync(int studentId, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentException>(studentId != default);

		var student = await studentRepository.GetObjectAsync(studentId, cancellationToken);
		Contract.Requires<OperationFailedException>(student.GradeId != (int)GradeEntry.Oktava, "Student nemá žádný další ročník");

		// Logically we want to validate the rules for the next grade
		var futureGrade = await gradeRepository.GetObjectAsync((int)((GradeEntry)student.GradeId).NextGrade(), cancellationToken);
		var studentsRegistrations = await subjectRegistrationRepository.GetActiveRegistrationsByStudentAsync(studentId, cancellationToken);

		Contract.Requires<InvalidOperationException>(studentsRegistrations is not null);
		Contract.Requires<InvalidOperationException>(futureGrade is not null);
		Contract.Requires<InvalidOperationException>(futureGrade.RegistrationCriteria is not null);

		var hoursPerWeekProgress = GetHoursPerWeekProgress(futureGrade, studentsRegistrations);
		var csOrCpProgress = GetCsOrCpRegistrationProgress(futureGrade, studentsRegistrations);
		var languageProgress = GetLanguageRegistrationProgress(futureGrade, studentsRegistrations);

		var registrationProgress = ConstructRegistrationProgress(
			futureGrade,
			hoursPerWeekProgress,
			csOrCpProgress,
			languageProgress);

		return registrationProgress;
	}

	private StudentLanguageRegistrationProgress GetLanguageRegistrationProgress(
		Grade forGrade,
		List<StudentSubjectRegistration> studentsRegistrations)
	{
		var doesStudentHaveLanguage = studentsRegistrations
			.Any(r => SubjectCategory.IsEntry(r.Subject.Category, SubjectCategoryEntry.ForeignLanguage));

		return new StudentLanguageRegistrationProgress(
			IsLanguageRequired: forGrade.RegistrationCriteria.RequiresForeginLanguage,
			doesStudentHaveLanguage);
	}

	private StudentHoursPerWeekProgress GetHoursPerWeekProgress(
		Grade forGrade,
		List<StudentSubjectRegistration> forRegistrations)
	{
		var amOfHoursExcludingLanguages = forRegistrations
			.Where(r => !SubjectCategory.IsEntry(r.Subject.Category, SubjectCategoryEntry.ForeignLanguage))
			.Sum(r => r.Subject.HoursPerWeek);

		var requiredAmountOfHoursPerWeekExcludingLanguages =
			forGrade.RegistrationCriteria.RequiredTotalAmountOfHoursPerWeekExcludingLanguage;

		return new StudentHoursPerWeekProgress(
			AmountOfHoursPerWeekExcludingLanguages: amOfHoursExcludingLanguages,
			RequiredAmountOfHoursPerWeekExcludingLanguages: requiredAmountOfHoursPerWeekExcludingLanguages);
	}

	private StudentCsOrCpRegistrationProgress GetCsOrCpRegistrationProgress(
		Grade forGrade,
		List<StudentSubjectRegistration> forRegistrations)
	{
		static bool IsRegistrationWithinAreaCsOrCp(StudentSubjectRegistration registration)
			=> registration.Subject.EducationalAreas.Any(area =>
				EducationalArea.IsEntry(area, EducationalArea.Entry.HumanSociety)
				|| EducationalArea.IsEntry(area, EducationalArea.Entry.HumanNature));

		if (!forGrade.RegistrationCriteria.RequiresCsOrCpValidation)
		{
			// Validation not needed here
			return new StudentCsOrCpRegistrationProgress()
			{
				DoesRequireCsOrCpValidation = false
			};
		}

		var ammOfHoursInCsOrCp = forRegistrations
			.Where(IsRegistrationWithinAreaCsOrCp)
			.Sum(r => r.Subject.HoursPerWeek);

		var requiredAmountOfHoursPerWeekInCsOrCp =
			forGrade.RegistrationCriteria.RequiredAmountOfHoursPerWeekInAreaCsOrCp;


		return new StudentCsOrCpRegistrationProgress(
			DoesRequireCsOrCpValidation: true,
			AmountOfHoursPerWeekInCsOrCp: ammOfHoursInCsOrCp,
			RequiredMinimalAmountOfHoursPerWeekInCsOrCp: requiredAmountOfHoursPerWeekInCsOrCp);
	}

	/// <summary>
	/// Responsible for creating the <see cref="StudentSubjectRegistration"/>.
	/// Determines, whether the combination of "rule progresses" (i.e. <see cref="StudentCsOrCpRegistrationProgress"/>)
	/// results in a valid registration (<see cref="StudentRegistrationProgress.IsRegistrationValid"/>).
	/// 
	/// This will be useful, when exceptions in the criteria are made, such as - Prima can choose a second language
	/// instead of filling the donated hours with regular subjects, so he won't fill the donated hours criteria,
	/// but it will still result in a valid registration.
	/// </summary>
	/// <returns></returns>
	private StudentRegistrationProgress ConstructRegistrationProgress(
		Grade forGrade,
		StudentHoursPerWeekProgress hoursPerWeekProgress,
		StudentCsOrCpRegistrationProgress csOrCpProgress,
		StudentLanguageRegistrationProgress languageRegistrationProgress)
	{
		bool isRegistrationValid = IsRegistrationValid(
			forGrade,
			hoursPerWeekProgress,
			csOrCpProgress,
			languageRegistrationProgress);

		return new StudentRegistrationProgress(
			isRegistrationValid,
			hoursPerWeekProgress,
			csOrCpProgress,
			languageRegistrationProgress,
			forGrade.RegistrationCriteria.CanUseForeignLanguageInsteadOfHoursPerWeek);
	}

	private static bool IsRegistrationValid(
		Grade forGrade,
		StudentHoursPerWeekProgress hoursPerWeekProgress,
		StudentCsOrCpRegistrationProgress csOrCpProgress,
		StudentLanguageRegistrationProgress languageProgress)
	{
		var isRegistrationValid = true;

		// Determine based on csOrCp
		if (csOrCpProgress.DoesRequireCsOrCpValidation)
		{
			isRegistrationValid &= csOrCpProgress.IsProgressComplete;
		}

		// Determine based on if student can use language instead of donated hours
		if (forGrade.RegistrationCriteria.CanUseForeignLanguageInsteadOfHoursPerWeek
			&& languageProgress.HasRegisteredLanguage)
		{
			// If language progress is sufficient, we should check, that the student doesn't have any other donated hours
			isRegistrationValid &= hoursPerWeekProgress.AmountOfHoursPerWeekExcludingLanguages == 0;
		}
		else
		{
			// -> Cannot skip donated hours validation (more common)
			isRegistrationValid &= hoursPerWeekProgress.IsProgressComplete;
		}

		// Determine based on language
		if (languageProgress.IsLanguageRequired)
		{
			isRegistrationValid &= languageProgress.HasRegisteredLanguage;
		}

		return isRegistrationValid;
	}
}