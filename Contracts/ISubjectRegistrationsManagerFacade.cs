namespace MensaGymnazium.IntranetGen3.Contracts;

[ApiContract]
public interface ISubjectRegistrationsManagerFacade
{
	Task<List<SigningRuleWithRegistrationsDto>> GetCurrentUserSigningRulesWithRegistrationsAsync(Dto<int?> onlySubjectId, CancellationToken cancellationToken = default);
	Task<List<SigningRuleStudentRegistrationsDto>> GetCurrentUserSubjectSigningRulesForRegistrationAsync(Dto<int> subjectId, CancellationToken cancellationToken = default);
	Task CancelRegistrationAsync(Dto<int> studentSubjectRegistrationId, CancellationToken cancellationToken = default);
	Task CreateRegistrationAsync(StudentSubjectRegistrationCreateDto studentSubjectRegistrationCreateDto, CancellationToken cancellationToken = default);
	Task<DataFragmentResult<StudentWithSigningRuleListItemDto>> GetStudentWithSigningRuleListAsync(DataFragmentRequest<StudentWithSigningRuleListQueryFilter> facadeRequest, CancellationToken cancellationToken);
}
