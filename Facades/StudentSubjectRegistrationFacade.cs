using System.Security;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.Queries;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories;
using MensaGymnazium.IntranetGen3.Facades.Infrastructure.Security.Authentication;
using MensaGymnazium.IntranetGen3.Model;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Facades;

[Service]
[Authorize]
public class StudentSubjectRegistrationFacade : IStudentSubjectRegistrationFacade
{
	private readonly IStudentSubjectActiveRegistrationListQuery studentSubjectActiveActiveRegistrationsListQuery;
	private readonly IStudentSubjectRegistrationRepository studentSubjectRegistrationRepository;
	private readonly IUnitOfWork unitOfWork;
	private readonly IApplicationAuthenticationService applicationAuthenticationService;

	public StudentSubjectRegistrationFacade(
		IStudentSubjectActiveRegistrationListQuery studentSubjectActiveActiveRegistrationsListQuery,
		IStudentSubjectRegistrationRepository studentSubjectRegistrationRepository,
		IUnitOfWork unitOfWork, IApplicationAuthenticationService applicationAuthenticationService)
	{
		this.studentSubjectActiveActiveRegistrationsListQuery = studentSubjectActiveActiveRegistrationsListQuery;
		this.studentSubjectRegistrationRepository = studentSubjectRegistrationRepository;
		this.unitOfWork = unitOfWork;
		this.applicationAuthenticationService = applicationAuthenticationService;
	}

	public async Task<DataFragmentResult<StudentSubjectRegistrationDto>> GetStudentSubjectActiveRegistrationsListAsync(DataFragmentRequest<StudentSubjectRegistrationListQueryFilter> studentSubjectRegistrationListRequest, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(studentSubjectRegistrationListRequest is not null);

		studentSubjectActiveActiveRegistrationsListQuery.Filter = studentSubjectRegistrationListRequest.Filter;
		studentSubjectActiveActiveRegistrationsListQuery.Sorting = studentSubjectRegistrationListRequest.Sorting;

		return await studentSubjectActiveActiveRegistrationsListQuery.GetDataFragmentResultAsync(studentSubjectRegistrationListRequest.StartIndex, studentSubjectRegistrationListRequest.Count, cancellationToken);
	}

	[Authorize(Roles = nameof(Role.Student))]
	public async Task<List<StudentSubjectRegistrationDto>> GetAllRegistrationsOfCurrentStudentAsync(CancellationToken cancellationToken = default)
	{
		var currentUser = applicationAuthenticationService.GetCurrentUser();
		Contract.Requires<SecurityException>(currentUser.StudentId is not null);

		var registrations = await studentSubjectRegistrationRepository.GetActiveRegistrationsByStudentAsync(currentUser.StudentId.Value, cancellationToken);

		// Map
		var response = registrations.Select(r => new StudentSubjectRegistrationDto()
		{
			SubjectId = r.SubjectId,
			StudentId = r.StudentId,
			RegistrationType = r.RegistrationType,
			Id = r.Id
		}).ToList();

		return response;
	}

	[Authorize(Roles = nameof(Role.Administrator))]
	public async Task<Dto<int>> CreateRegistrationAsync(StudentSubjectRegistrationDto registrationDto, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(registrationDto != null);
		Contract.Requires<ArgumentException>(registrationDto.Id == default);

		var registration = new StudentSubjectRegistration();
		MapRegistrationFromDto(registrationDto, registration);

		unitOfWork.AddForInsert(registration);
		await unitOfWork.CommitAsync(cancellationToken);

		return Dto.FromValue(registration.Id);
	}

	[Authorize(Roles = nameof(Role.Administrator))]
	public async Task UpdateRegistrationAsync(StudentSubjectRegistrationDto registrationDto, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(registrationDto != null);
		Contract.Requires<ArgumentException>(registrationDto.Id != default);

		var registration = await studentSubjectRegistrationRepository.GetObjectAsync(registrationDto.Id, cancellationToken);

		MapRegistrationFromDto(registrationDto, registration);

		unitOfWork.AddForUpdate(registration);
		await unitOfWork.CommitAsync(cancellationToken);
	}

	private void MapRegistrationFromDto(StudentSubjectRegistrationDto registrationDto, StudentSubjectRegistration registration)
	{
		registration.SubjectId = registrationDto.SubjectId.Value;
		registration.StudentId = registrationDto.StudentId.Value;
		registration.RegistrationType = registrationDto.RegistrationType.Value;
	}

	[Authorize(Roles = nameof(Role.Administrator))]
	public async Task DeleteRegistrationAsync(Dto<int> registrationIdDto, CancellationToken cancellationToken = default)
	{
		var registration = await studentSubjectRegistrationRepository.GetObjectAsync(registrationIdDto.Value, cancellationToken);
		unitOfWork.AddForDelete(registration);

		await unitOfWork.CommitAsync(cancellationToken);
	}
}
