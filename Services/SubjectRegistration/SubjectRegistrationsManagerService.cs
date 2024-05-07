using System.Security;
using Havit.Services.TimeServices;
using MensaGymnazium.IntranetGen3.DataLayer.DataEntries.Common;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories;
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

	public SubjectRegistrationsManagerService(
		ITimeService timeService,
		IApplicationSettingsEntries applicationSettingsEntries,
		IUnitOfWork unitOfWork,
		IStudentSubjectRegistrationRepository studentSubjectRegistrationRepository,
		ISubjectRepository subjectRepository)
	{
		_timeService = timeService;
		_applicationSettingsEntries = applicationSettingsEntries;
		_unitOfWork = unitOfWork;
		_studentSubjectRegistrationRepository = studentSubjectRegistrationRepository;
		_subjectRepository = subjectRepository;
	}
	public bool IsRegistrationPeriodActive()
	{
		var allowedFrom = _applicationSettingsEntries.Current.SubjectRegistrationAllowedFrom;
		var allowedTo = _applicationSettingsEntries.Current.SubjectRegistrationAllowedTo;
		var today = _timeService.GetCurrentDate();

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

		_unitOfWork.AddForInsert(studentSubjectRegistration);

		return studentSubjectRegistration;
	}

	public async Task CancelRegistrationAsync(int registrationId, int callerStudentId, CancellationToken cancellationToken)
	{
		var studentSubjectRegistration = await _studentSubjectRegistrationRepository.GetObjectAsync(registrationId, cancellationToken);

		Contract.Requires<SecurityException>(studentSubjectRegistration.StudentId == callerStudentId);

		_unitOfWork.AddForDelete(studentSubjectRegistration);
	}

	public async Task<bool> IsSubjectCapacityFullAsync(int subjectId)
	{
		var subject = await _subjectRepository.GetObjectAsync(subjectId);
		if (subject.Capacity is null)
		{
			return false; // No capacity => no limit
		}

		var registrationsForSubject = await _studentSubjectRegistrationRepository.CountMainRegistrationsForSubjectAsync(subjectId);

		return registrationsForSubject >= subject.Capacity.Value;
	}

	public async Task<bool> IsSubjectRegisteredForStudent(int subjectId, int callerStudentId)
	{
		var registrationsForStudent = await _studentSubjectRegistrationRepository.GetRegistrationsByStudent(callerStudentId);

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
