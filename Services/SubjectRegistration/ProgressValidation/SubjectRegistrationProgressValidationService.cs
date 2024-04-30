using MensaGymnazium.IntranetGen3.DataLayer.Repositories;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories.Security;
using MensaGymnazium.IntranetGen3.Model;

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
		var student = await studentRepository.GetObjectAsync(studentId, cancellationToken);
		Contract.Requires<ArgumentNullException>(student is not null);

		// Logically we want to validate the rules for the next grade
		// Todo: what if someone from oktava (no future grade) calls this method?
		var futureGrade = await gradeRepository.GetObjectAsync(student.GradeId - 1, cancellationToken);
		var studentsRegistrations = await subjectRegistrationRepository.GetRegistrationsByStudentAsync(studentId, cancellationToken);

		Contract.Requires<ArgumentNullException>(studentsRegistrations is not null);
		Contract.Requires<ArgumentNullException>(futureGrade is not null);
		Contract.Requires<ArgumentNullException>(futureGrade.RegistrationCriteria is not null);

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
			RequiredAmountOfDonatedHoursInCsOrCp: requiredAmountOfDonatedHoursInCspOrCp);
	}

	/// <summary>
	/// Reponsible for creating the <see cref="StudentSubjectRegistration"/>.
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
		var isRegistrationValid =
			(donatedHoursProgress.MeetsCriteria)
			&& (csOrCpProgress.MeetsCriteria);

		return new StudentRegistrationProgress(
			isRegistrationValid,
			donatedHoursProgress,
			csOrCpProgress,
			languageRegistrationProgress);
	}
}