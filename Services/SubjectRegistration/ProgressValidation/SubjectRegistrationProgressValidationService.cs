﻿using Havit;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.DataSources.Security;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories.Security;
using MensaGymnazium.IntranetGen3.Model;
using MensaGymnazium.IntranetGen3.Model.Security;
using MensaGymnazium.IntranetGen3.Primitives;
using Microsoft.EntityFrameworkCore;

namespace MensaGymnazium.IntranetGen3.Services.SubjectRegistration.ProgressValidation;

[Service]
public sealed class SubjectRegistrationProgressValidationService : ISubjectRegistrationProgressValidationService
{
	private readonly IStudentRepository _studentRepository;
	private readonly IStudentSubjectRegistrationRepository _subjectRegistrationRepository;
	private readonly IGradeRepository _gradeRepository;

	private readonly IStudentDataSource _studentDataSource; // Used to simplify filtering
	private readonly IDataLoader _dataLoader;

	public SubjectRegistrationProgressValidationService(
		IStudentRepository studentRepository,
		IStudentSubjectRegistrationRepository subjectRegistrationRepository,
		IGradeRepository gradeRepository,
		IStudentDataSource studentDatSource,
		IDataLoader dataLoader)
	{
		_studentRepository = studentRepository;
		_subjectRegistrationRepository = subjectRegistrationRepository;
		_gradeRepository = gradeRepository;
		_studentDataSource = studentDatSource;
		_dataLoader = dataLoader;
	}

	public async Task<StudentRegistrationProgress> GetRegistrationProgressOfStudentAsync(int studentId, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentException>(studentId != default);

		var student = await _studentRepository.GetObjectAsync(studentId, cancellationToken);

		await _dataLoader.LoadAsync(student, s => s.SubjectRegistrations, cancellationToken);
		await _dataLoader.LoadAllAsync(student.SubjectRegistrations, ssr => ssr.Subject.EducationalAreaRelations, cancellationToken)
			.ThenLoadAsync(ear => ear.EducationalArea, cancellationToken);
		await _dataLoader.LoadAllAsync(student.SubjectRegistrations, ssr => ssr.Subject.Category, cancellationToken);

		return await GetRegistrationProgressOfStudentImplAsync(student, cancellationToken);
	}

	public async Task<Dictionary<int, StudentRegistrationProgress>> GetRegistrationProgressOfAllStudentsAsync(
		StudentSubjectRegistrationProgressListFilter filter,
		CancellationToken cancellationToken = default)
	{
		// Filter students:
		// 1. Don't fetch oktava students (they are not subject to progress)
		// 2. Fetch based on given filter
		var filteredStudents = await _studentDataSource.Data
			.WhereIf(filter.StudentId is not null, s => s.Id == filter.StudentId)
			.WhereIf(filter.GradeId is not null, s => s.GradeId == filter.GradeId)
			.Where(s => (GradeEntry)s.GradeId != GradeEntry.Oktava)
			.ToArrayAsync(cancellationToken: cancellationToken);

		await _dataLoader.LoadAllAsync(filteredStudents, s => s.SubjectRegistrations, cancellationToken)
			.ThenLoadAsync(ssr => ssr.Subject.EducationalAreaRelations, cancellationToken)
			.ThenLoadAsync(ear => ear.EducationalArea, cancellationToken);
		await _dataLoader.LoadAllAsync(filteredStudents, s => s.SubjectRegistrations, cancellationToken)
			.ThenLoadAsync(ssr => ssr.Subject.Category, cancellationToken);

		// Get progress of each student and store into dict
		var result = new Dictionary<int, StudentRegistrationProgress>(filteredStudents.Length);
		foreach (var student in filteredStudents)
		{
			// Get progress
			Contract.Requires<ArgumentException>(student.Id != default);
			var registrationProgress = await GetRegistrationProgressOfStudentImplAsync(student, cancellationToken);

			// Filter again, based on ValidationState
			if (filter.ValidationState is not null &&
				filter.ValidationState != registrationProgress.IsRegistrationValid())
			{
				continue;
			}

			// Passed filtering, add to result dictP
			result.Add(student.Id, registrationProgress);
		}

		return result;
	}

	private async Task<StudentRegistrationProgress> GetRegistrationProgressOfStudentImplAsync(Student student, CancellationToken cancellationToken = default)
	{
		Contract.Requires<OperationFailedException>(student.GradeId != (int)GradeEntry.Oktava, "Student nemá žádný další ročník");

		// Logically, we want to validate the rules for the next grade
		var futureGrade = await _gradeRepository.GetObjectAsync((int)((GradeEntry)student.GradeId).NextGrade(), cancellationToken);
		var studentsRegistrations = student.SubjectRegistrations;

		Contract.Requires<InvalidOperationException>(studentsRegistrations is not null);
		Contract.Requires<InvalidOperationException>(futureGrade is not null);
		Contract.Requires<InvalidOperationException>(futureGrade.RegistrationCriteria is not null);

		var hoursPerWeekProgress = GetHoursPerWeekProgress(futureGrade, studentsRegistrations);
		var csOrCpProgress = GetCsOrCpRegistrationProgress(futureGrade, studentsRegistrations);
		var languageProgress = GetLanguageRegistrationProgress(futureGrade, studentsRegistrations);

		var registrationProgress = new StudentRegistrationProgress(
			hoursPerWeekProgress,
			csOrCpProgress,
			languageProgress,
			futureGrade.RegistrationCriteria.CanUseForeignLanguageInsteadOfHoursPerWeek);

		return registrationProgress;
	}

	private StudentLanguageRegistrationProgress GetLanguageRegistrationProgress(
		Grade forGrade,
		IEnumerable<StudentSubjectRegistration> studentsRegistrations)
	{
		var doesStudentHaveLanguage = studentsRegistrations
			.Any(r => SubjectCategory.IsEntry(r.Subject.Category, SubjectCategoryEntry.ForeignLanguage));

		return new StudentLanguageRegistrationProgress(
			IsLanguageRequired: forGrade.RegistrationCriteria.RequiresForeginLanguage,
			doesStudentHaveLanguage);
	}

	private StudentHoursPerWeekProgress GetHoursPerWeekProgress(
		Grade forGrade,
		IEnumerable<StudentSubjectRegistration> forRegistrations)
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
		IEnumerable<StudentSubjectRegistration> forRegistrations)
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
}