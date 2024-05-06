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
		var futureGrade = await gradeRepository.GetObjectAsync(student.GradeId - 1, cancellationToken);
		var studentsRegistrations = await subjectRegistrationRepository.GetRegistrationsByStudentAsync(studentId, cancellationToken);

		Contract.Requires<InvalidOperationException>(studentsRegistrations is not null);
		Contract.Requires<InvalidOperationException>(futureGrade is not null);
		Contract.Requires<InvalidOperationException>(futureGrade.RegistrationCriteria is not null);

		var donatedHoursProgress = GetDonatedHoursProgress(futureGrade, studentsRegistrations);
		var csOrCpProgress = GetCsOrCpRegistrationProgress(futureGrade, studentsRegistrations);
		var languageProgress = GetLanguageRegistrationProgress(futureGrade, studentsRegistrations);

		var registrationProgress = ConstructRegistrationProgress(
			futureGrade,
			donatedHoursProgress,
			csOrCpProgress,
			languageProgress);

		return registrationProgress;
	}

	private StudentLanguageRegistrationProgress GetLanguageRegistrationProgress(
		Grade forGrade,
		List<StudentSubjectRegistration> studentsRegistrations)
	{
		var doesStudentHaveLanguage = studentsRegistrations
			.Any(r => SubjectCategory.IsEntry(r.Subject.Category, SubjectCategory.Entry.ForeignLanguage));

		return new StudentLanguageRegistrationProgress(
			IsLanguageRequired: forGrade.RegistrationCriteria.RequiresForeginLanguage,
			doesStudentHaveLanguage);
	}

	private StudentDonatedHoursProgress GetDonatedHoursProgress(
		Grade forGrade,
		List<StudentSubjectRegistration> forRegistrations)
	{
		static bool IsSubjectALanguage(Subject subject)
			=> SubjectCategory.IsEntry(subject.Category, SubjectCategory.Entry.ForeignLanguage);

		var amOfHoursExcludingLanguages = forRegistrations
			.Aggregate(0, (total, reg) =>
				IsSubjectALanguage(reg.Subject)
					? total
					: total + reg.Subject.HoursPerWeek);

		var requiredAmountOfDonatedHoursExcludingLanguages =
			forGrade.RegistrationCriteria.RequiredTotalAmountOfDonatedHoursExcludingLanguage;

		return new StudentDonatedHoursProgress(
			AmountOfDonatedHoursExcludingLanguages: amOfHoursExcludingLanguages,
			RequiredAmountOfDonatedHoursExcludingLanguages: requiredAmountOfDonatedHoursExcludingLanguages);
	}

	private StudentCsOrCpRegistrationProgress GetCsOrCpRegistrationProgress(
		Grade forGrade,
		List<StudentSubjectRegistration> forRegistrations)
	{
		static bool IsRegistrationWithinAreaCspOrCp(StudentSubjectRegistration registration)
			=> registration.Subject.EducationalAreas.Any(area =>
				EducationalArea.IsEntry(area, EducationalArea.Entry.HumanSociety)
				|| EducationalArea.IsEntry(area, EducationalArea.Entry.HumanNature));

		if (!forGrade.RegistrationCriteria.RequiresCspOrCpValidation)
		{
			// Validation not needed here
			return new StudentCsOrCpRegistrationProgress()
			{
				DoesRequireCsOrCpValidation = false
			};
		}

		// Calculate the sum of hours in those fields
		var ammOfHoursInCsOrCp = forRegistrations
			.Aggregate(0, (total, reg) =>
				IsRegistrationWithinAreaCspOrCp(reg)
					? total + reg.Subject.HoursPerWeek
					: total);

		var requiredAmountOfDonatedHoursInCspOrCp =
			forGrade.RegistrationCriteria.RequiredAmountOfDonatedHoursInAreaCspOrCp;


		return new StudentCsOrCpRegistrationProgress(
			DoesRequireCsOrCpValidation: true,
			AmountOfDonatedHoursInCsOrCp: ammOfHoursInCsOrCp,
			RequiredMinimalAmountOfDonatedHoursInCsOrCp: requiredAmountOfDonatedHoursInCspOrCp);
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
		StudentDonatedHoursProgress donatedHoursProgress,
		StudentCsOrCpRegistrationProgress csOrCpProgress,
		StudentLanguageRegistrationProgress languageRegistrationProgress)
	{
		bool isRegistrationValid = IsRegistrationValid(
			forGrade,
			donatedHoursProgress,
			csOrCpProgress,
			languageRegistrationProgress);

		return new StudentRegistrationProgress(
			isRegistrationValid,
			donatedHoursProgress,
			csOrCpProgress,
			languageRegistrationProgress,
			forGrade.RegistrationCriteria.CanUseForeignLanguageInsteadOfDonatedHours);
	}

	private static bool IsRegistrationValid(
		Grade forGrade,
		StudentDonatedHoursProgress donatedHoursProgress,
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
		if (forGrade.RegistrationCriteria.CanUseForeignLanguageInsteadOfDonatedHours
			&& languageProgress.HasRegisteredLanguage)
		{
			// If language progress is sufficient, we should check, that the student doesn't have any other donated hours
			isRegistrationValid &= donatedHoursProgress.AmountOfDonatedHoursExcludingLanguages == 0;
		}
		else
		{
			// -> Cannot skip donated hours validation (more common)
			isRegistrationValid &= donatedHoursProgress.IsProgressComplete;
		}

		// Determine based on language
		if (languageProgress.IsLanguageRequired)
		{
			isRegistrationValid &= languageProgress.HasRegisteredLanguage;
		}

		return isRegistrationValid;
	}
}