using System.Security;
using Havit;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.Queries;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories;
using MensaGymnazium.IntranetGen3.Facades.Infrastructure.Security.Authentication;
using MensaGymnazium.IntranetGen3.Model;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Facades;

[Service]
[Authorize]
public class SubjectRegistrationsManagerFacade : ISubjectRegistrationsManagerFacade
{
	private readonly IStudentSigningRulesWithRegistrationsQuery studentSigningRulesWithRegistrationsQuery;
	private readonly IApplicationAuthenticationService applicationAuthenticationService;
	private readonly ISubjectRepository subjectRepository;
	private readonly IStudentSubjectRegistrationRepository studentSubjectRegistrationRepository;
	private readonly IUnitOfWork unitOfWork;
	private readonly IDataLoader dataLoader;

	public SubjectRegistrationsManagerFacade(
		IStudentSigningRulesWithRegistrationsQuery studentSigningRulesWithRegistrationsQuery,
		IApplicationAuthenticationService applicationAuthenticationService,
		ISubjectRepository subjectRepository,
		IStudentSubjectRegistrationRepository studentSubjectRegistrationRepository,
		IUnitOfWork unitOfWork,
		IDataLoader dataLoader)
	{
		this.studentSigningRulesWithRegistrationsQuery = studentSigningRulesWithRegistrationsQuery;
		this.applicationAuthenticationService = applicationAuthenticationService;
		this.subjectRepository = subjectRepository;
		this.studentSubjectRegistrationRepository = studentSubjectRegistrationRepository;
		this.unitOfWork = unitOfWork;
		this.dataLoader = dataLoader;
	}

	[Authorize(Roles = nameof(Role.Student))]
	public async Task CancelRegistrationAsync(Dto<int> studentSubjectRegistrationId, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(studentSubjectRegistrationId is not null);
		Contract.Requires<ArgumentException>(studentSubjectRegistrationId.Value != default);

		var studentSubjectRegistration = await studentSubjectRegistrationRepository.GetObjectAsync(studentSubjectRegistrationId.Value, cancellationToken);

		var currentUser = applicationAuthenticationService.GetCurrentUser();
		Contract.Requires<SecurityException>(studentSubjectRegistration.StudentId == currentUser.StudentId);

		unitOfWork.AddForDelete(studentSubjectRegistration);
		await unitOfWork.CommitAsync(cancellationToken);
	}

	[Authorize(Roles = nameof(Role.Student))]
	public async Task CreateRegistrationAsync(StudentSubjectRegistrationCreateDto studentSubjectRegistrationCreateDto, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(studentSubjectRegistrationCreateDto is not null);
		Contract.Requires<ArgumentException>(studentSubjectRegistrationCreateDto.SigningRuleId != default);
		Contract.Requires<ArgumentException>(studentSubjectRegistrationCreateDto.SubjectId != default);
		Contract.Requires<ArgumentException>(studentSubjectRegistrationCreateDto.RegistrationType != default);

		// Verify registration requirements
		var signingRulesForRegistration = await GetCurrentUserSubjectSigningRulesForRegistrationAsync(Dto.FromValue(studentSubjectRegistrationCreateDto.SubjectId.Value), cancellationToken);
		var signingRuleForRegistrationDto = signingRulesForRegistration.Single(sr => sr.Id == studentSubjectRegistrationCreateDto.SigningRuleId);
		Contract.Requires<ArgumentException>(signingRuleForRegistrationDto is not null);

		switch (studentSubjectRegistrationCreateDto.RegistrationType)
		{
			case StudentRegistrationType.Main:
				Contract.Requires<OperationFailedException>(signingRuleForRegistrationDto.MainRegistrationAllowed, signingRuleForRegistrationDto.MainRegistrationNotAllowedReason);
				break;
			case StudentRegistrationType.Secondary:
				Contract.Requires<OperationFailedException>(signingRuleForRegistrationDto.SecondaryRegistrationAllowed, signingRuleForRegistrationDto.SecondaryRegistrationNotAllowedReason);
				break;
			default:
				throw new InvalidOperationException($"Unknown {nameof(StudentRegistrationType)} value: {studentSubjectRegistrationCreateDto.RegistrationType}.");
		}

		// create registration
		var currentUser = applicationAuthenticationService.GetCurrentUser();
		Contract.Requires<SecurityException>(currentUser.StudentId is not null);

		var studentSubjectRegistration = new StudentSubjectRegistration
		{
			StudentId = currentUser.StudentId.Value,
			UsedSigningRuleId = studentSubjectRegistrationCreateDto.SigningRuleId.Value,
			SubjectId = studentSubjectRegistrationCreateDto.SubjectId.Value,
			RegistrationType = studentSubjectRegistrationCreateDto.RegistrationType.Value
		};

		unitOfWork.AddForInsert(studentSubjectRegistration);
		await unitOfWork.CommitAsync(cancellationToken);
	}

	[Authorize(Roles = nameof(Role.Student))]
	public async Task<List<SigningRuleStudentRegistrationsDto>> GetCurrentUserSubjectSigningRulesForRegistrationAsync(Dto<int> subjectId, CancellationToken cancellationToken = default)
	{
		var signingRulesWithRegistrations = await GetCurrentUserSigningRulesWithRegistrationsAsync(Dto.FromValue((int?)subjectId.Value), cancellationToken);

		List<SigningRuleStudentRegistrationsDto> result = new();

		var subjectRegistered = signingRulesWithRegistrations.SelectMany(x => x.Registrations).Any(ssr => ssr.SubjectId == subjectId.Value);

		foreach (var item in signingRulesWithRegistrations)
		{
			var resultItem = new SigningRuleStudentRegistrationsDto();
			resultItem.Id = item.Id;
			resultItem.Name = item.Name;

			// main
			resultItem.MainRegistration = item.Registrations.FirstOrDefault(r => (r.SubjectId == subjectId.Value)
																&& (r.RegistrationType == StudentRegistrationType.Main));
			if (resultItem.MainRegistration is not null)
			{
				resultItem.MainRegistrationAllowed = false;
				resultItem.MainRegistrationNotAllowedReason = "Primární registrace tohoto předmětu k tomu pravidlu již existuje";
			}
			else if (item.Registrations.Count(r => r.RegistrationType == StudentRegistrationType.Main) >= item.Quantity)
			{
				resultItem.MainRegistrationAllowed = false;
				resultItem.MainRegistrationNotAllowedReason = "Počet primárních registrací tohoto pravidla vyčerpán";
			}
			else if (subjectRegistered)
			{
				resultItem.MainRegistrationAllowed = false;
				resultItem.MainRegistrationNotAllowedReason = "Předmět je již registrován";
			}
			else
			{
				resultItem.MainRegistrationAllowed = true;
			}

			// secondary
			resultItem.SecondaryRegistration = item.Registrations.FirstOrDefault(r => (r.SubjectId == subjectId.Value)
																&& (r.RegistrationType == StudentRegistrationType.Secondary));
			if (resultItem.SecondaryRegistration is not null)
			{
				resultItem.SecondaryRegistrationAllowed = false;
				resultItem.SecondaryRegistrationNotAllowedReason = "Náhradní registrace tohoto předmětu k tomu pravidlu již existuje";
			}
			else if (item.Registrations.Count(r => r.RegistrationType == StudentRegistrationType.Secondary) >= item.Quantity)
			{
				resultItem.SecondaryRegistrationAllowed = false;
				resultItem.SecondaryRegistrationNotAllowedReason = "Počet náhradních registrací tohoto pravidla vyčerpán";
			}
			else if (subjectRegistered)
			{
				resultItem.SecondaryRegistrationAllowed = false;
				resultItem.SecondaryRegistrationNotAllowedReason = "Předmět je již registrován";
			}
			else
			{
				resultItem.SecondaryRegistrationAllowed = true;
			}

			result.Add(resultItem);
		}

		return result;
	}

	[Authorize(Roles = nameof(Role.Student))]
	public async Task<List<SigningRuleWithRegistrationsDto>> GetCurrentUserSigningRulesWithRegistrationsAsync(Dto<int?> onlySubjectId, CancellationToken cancellationToken = default)
	{
		var user = applicationAuthenticationService.GetCurrentUser();
		Contract.Assert<InvalidOperationException>(user.Student is not null);

		Subject subjectFilter = null;
		if (onlySubjectId.Value.HasValue)
		{
			subjectFilter = await subjectRepository.GetObjectAsync(onlySubjectId.Value.Value, cancellationToken);
			await dataLoader.LoadAsync(subjectFilter, s => s.GradeRelations, cancellationToken);
			await dataLoader.LoadAsync(subjectFilter, s => s.TypeRelations, cancellationToken);
		}

		return await studentSigningRulesWithRegistrationsQuery.GetDataAsync(user.Student, subjectFilter, cancellationToken);
	}
}
