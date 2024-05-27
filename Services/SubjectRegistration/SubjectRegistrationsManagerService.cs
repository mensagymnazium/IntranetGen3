using System.Security;
using Havit.Services.TimeServices;
using MensaGymnazium.IntranetGen3.DataLayer.DataEntries.Common;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories.Security;
using MensaGymnazium.IntranetGen3.Model;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Services.SubjectRegistration;

[Service]
internal sealed class SubjectRegistrationsManagerService : ISubjectRegistrationsManagerService
{
	private readonly ITimeService _timeService;
	private readonly IApplicationSettingsEntries _applicationSettingsEntries;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IStudentSubjectRegistrationRepository _studentSubjectRegistrationRepository;
	private readonly ISubjectRepository _subjectRepository;
	private readonly IStudentRepository _studentRepository;
	private readonly IGradeRepository _gradeRepository;

	public SubjectRegistrationsManagerService(
		ITimeService timeService,
		IApplicationSettingsEntries applicationSettingsEntries,
		IUnitOfWork unitOfWork,
		IStudentSubjectRegistrationRepository studentSubjectRegistrationRepository,
		ISubjectRepository subjectRepository,
		IStudentRepository studentRepository,
		IGradeRepository gradeRepository)
	{
		_timeService = timeService;
		_applicationSettingsEntries = applicationSettingsEntries;
		_unitOfWork = unitOfWork;
		_studentSubjectRegistrationRepository = studentSubjectRegistrationRepository;
		_subjectRepository = subjectRepository;
		_studentRepository = studentRepository;
		_gradeRepository = gradeRepository;
	}
	public bool IsRegistrationPeriodActive()
	{
		var allowedFrom = _applicationSettingsEntries.Current.SubjectRegistrationAllowedFrom;
		var allowedTo = _applicationSettingsEntries.Current.SubjectRegistrationAllowedTo;
		var now = _timeService.GetCurrentDate();

		if ((allowedFrom is not null) && (now < allowedFrom))
		{
			return false;
		}

		if ((allowedTo is not null) && (now > allowedTo))
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

		_unitOfWork.AddForInsert(studentSubjectRegistration);

		return studentSubjectRegistration;
	}

	public async Task CancelRegistrationAsync(
		int registrationId,
		int callerStudentId,
		CancellationToken cancellationToken)
	{
		var studentSubjectRegistration = await _studentSubjectRegistrationRepository.GetObjectAsync(registrationId, cancellationToken);

		Contract.Requires<SecurityException>(studentSubjectRegistration.StudentId == callerStudentId);

		_unitOfWork.AddForDelete(studentSubjectRegistration);
	}

	public async Task<bool> IsSubjectCapacityFullAsync(
		int subjectId,
		CancellationToken cancellationToken = default)
	{
		var subject = await _subjectRepository.GetObjectAsync(subjectId, cancellationToken);
		if (subject.Capacity is null)
		{
			return false; // No capacity => no limit
		}

		var registrationsForSubject = await _studentSubjectRegistrationRepository.CountMainRegistrationsForSubjectAsync(subjectId, cancellationToken);

		return registrationsForSubject >= subject.Capacity.Value;
	}

	public async Task<bool> IsStudentInAssignableGradeAsync(
		int studentId,
		int subjectId,
		CancellationToken cancellationToken = default)
	{
		var subject = await _subjectRepository.GetObjectAsync(subjectId, cancellationToken);
		var student = await _studentRepository.GetObjectAsync(studentId, cancellationToken);

		// We must consider the future grade.
		var futureGrade = await _gradeRepository.GetObjectAsync((int)((GradeEntry)student.GradeId).NextGrade(), cancellationToken); // -1, because ids are negative

		return subject.Grades.Contains(futureGrade);
	}

	public async Task<bool> DidStudentAlreadyReachHoursPerWeekLimitAsync(
		int studentId,
		int subjectId,
		CancellationToken cancellationToken = default)
	{
		var student = await _studentRepository.GetObjectAsync(studentId, cancellationToken);
		var studentsNextYearGrade = await _gradeRepository.GetObjectAsync((int)((GradeEntry)student.GradeId).NextGrade(), cancellationToken); // Negative values
		var subject = await _subjectRepository.GetObjectAsync(subjectId, cancellationToken);

		if (SubjectCategory.IsEntry(subject.Category, SubjectCategoryEntry.ForeignLanguage))
		{
			return false; // Languages don't count towards the limit
		}

		// Student never has > 10 registrations, so we can safely load this.
		var registrationsForStudent = await _studentSubjectRegistrationRepository.GetActiveRegistrationsByStudentAsync(studentId, cancellationToken);

		var amOfHoursExcludingLanguages = registrationsForStudent
			.Where(r => !SubjectCategory.IsEntry(r.Subject.Category, SubjectCategoryEntry.ForeignLanguage))
			.Sum(r => r.Subject.HoursPerWeek);

		return amOfHoursExcludingLanguages >=
			   studentsNextYearGrade.RegistrationCriteria.RequiredTotalAmountOfHoursPerWeekExcludingLanguage;
	}

	public async Task<bool> IsSubjectRegisteredForStudentAsync(
		int subjectId,
		int callerStudentId,
		CancellationToken cancellationToken = default)
	{
		var registrationsForStudent = await _studentSubjectRegistrationRepository.GetActiveRegistrationsByStudentAsync(callerStudentId, cancellationToken);

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
