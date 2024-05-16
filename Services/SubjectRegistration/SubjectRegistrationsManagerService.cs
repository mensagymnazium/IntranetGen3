using System.Security;
using Havit.Services.TimeServices;
using MensaGymnazium.IntranetGen3.DataLayer.DataEntries.Common;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories.Security;
using MensaGymnazium.IntranetGen3.Model;
using MensaGymnazium.IntranetGen3.Model.Security;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Services.SubjectRegistration;

[Service]
internal sealed class SubjectRegistrationsManagerService : ISubjectRegistrationsManagerService
{
	private readonly ITimeService timeService;
	private readonly IApplicationSettingsEntries applicationSettingsEntries;
	private readonly IUnitOfWork unitOfWork;
	private readonly IStudentSubjectRegistrationRepository studentSubjectRegistrationRepository;
	private readonly ISubjectRepository subjectRepository;
	private readonly IStudentRepository studentRepository;
	private readonly IGradeRepository gradeRepository;

	public SubjectRegistrationsManagerService(
		ITimeService timeService,
		IApplicationSettingsEntries applicationSettingsEntries,
		IUnitOfWork unitOfWork,
		IStudentSubjectRegistrationRepository studentSubjectRegistrationRepository,
		ISubjectRepository subjectRepository,
		IStudentRepository studentRepository,
		IGradeRepository gradeRepository)
	{
		this.timeService = timeService;
		this.applicationSettingsEntries = applicationSettingsEntries;
		this.unitOfWork = unitOfWork;
		this.studentSubjectRegistrationRepository = studentSubjectRegistrationRepository;
		this.subjectRepository = subjectRepository;
		this.studentRepository = studentRepository;
		this.gradeRepository = gradeRepository;
	}
	public bool IsRegistrationPeriodActive()
	{
		var allowedFrom = applicationSettingsEntries.Current.SubjectRegistrationAllowedFrom;
		var allowedTo = applicationSettingsEntries.Current.SubjectRegistrationAllowedTo;
		var today = timeService.GetCurrentDate();

		if (allowedFrom is not null && today < allowedFrom)
		{
			return false;
		}

		if (allowedTo is not null && today > allowedTo)
		{
			return false;
		}

		return true;
	}

	public StudentSubjectRegistration CreateNewSubjectRegistration(
		int studentId,
		int subjectId,
		StudentRegistrationType registrationType)
	{
		var studentSubjectRegistration = new StudentSubjectRegistration
		{
			StudentId = studentId,
			SubjectId = subjectId,
			RegistrationType = registrationType,
		};

		unitOfWork.AddForInsert(studentSubjectRegistration);

		return studentSubjectRegistration;
	}

	public async Task CancelRegistrationAsync(
		int registrationId,
		int callerStudentId,
		CancellationToken cancellationToken)
	{
		var studentSubjectRegistration = await studentSubjectRegistrationRepository.GetObjectAsync(registrationId, cancellationToken);

		Contract.Requires<SecurityException>(studentSubjectRegistration.StudentId == callerStudentId);

		unitOfWork.AddForDelete(studentSubjectRegistration);
	}

	public async Task<bool> IsSubjectCapacityFullAsync(
		int subjectId,
		CancellationToken cancellationToken = default)
	{
		var subject = await subjectRepository.GetObjectAsync(subjectId, cancellationToken);
		if (subject.Capacity is null)
		{
			return false; // No capacity => no limit
		}

		var registrationsForSubject = await studentSubjectRegistrationRepository.CountMainRegistrationsForSubjectAsync(subjectId, cancellationToken);

		return registrationsForSubject >= subject.Capacity.Value;
	}

	public async Task<bool> IsStudentInAssignableGrade(
		int studentId,
		int subjectId,
		CancellationToken cancellationToken = default)
	{
		var subject = await subjectRepository.GetObjectAsync(subjectId, cancellationToken);
		var student = await studentRepository.GetObjectAsync(studentId, cancellationToken);

		// We must consider the future grade.
		var futureGrade = await gradeRepository.GetObjectAsync((int)((GradeEntry)student.GradeId).NextGrade(), cancellationToken); // -1, because ids are negative

		return subject.Grades.Contains(futureGrade);
	}

	public async Task<bool> DidStudentAlreadyReachHoursPerWeekLimit(
		int studentId,
		int subjectId,
		CancellationToken cancellationToken = default)
	{
		var student = await studentRepository.GetObjectAsync(studentId, cancellationToken);
		var studentsNextYearGrade = await gradeRepository.GetObjectAsync((int)((GradeEntry)student.GradeId).NextGrade(), cancellationToken); // Negative values
		var subject = await subjectRepository.GetObjectAsync(subjectId, cancellationToken);

		if (SubjectCategory.IsEntry(subject.Category, SubjectCategoryEntry.ForeignLanguage))
		{
			return false; // Languages don't count towards the limit
		}

		// Student never has > 10 registrations, so we can safely load this.
		var registrationsForStudent = await studentSubjectRegistrationRepository.GetRegistrationsByStudentAsync(studentId, cancellationToken);

		// (Now omitting main/secondary registration, just count them all)
		static bool IsSubjectALanguage(Subject subject)
			=> SubjectCategory.IsEntry(subject.Category, SubjectCategoryEntry.ForeignLanguage);

		var amOfHoursExcludingLanguages = registrationsForStudent
			.Aggregate(0, (total, reg) =>
				IsSubjectALanguage(reg.Subject)
					? total
					: total + reg.Subject.HoursPerWeek);

		return amOfHoursExcludingLanguages >=
			   studentsNextYearGrade.RegistrationCriteria.RequiredTotalAmountOfHoursPerWeekExcludingLanguage;
	}

	public async Task<bool> IsSubjectRegisteredForStudentAsync(
		int subjectId,
		int callerStudentId,
		CancellationToken cancellationToken = default)
	{
		var registrationsForStudent = await studentSubjectRegistrationRepository.GetRegistrationsByStudentAsync(callerStudentId, cancellationToken);

		foreach (var registration in registrationsForStudent)
		{
			if (registration.SubjectId == subjectId)
			{
				return true;
			}
		}

		return false;
	}
}
