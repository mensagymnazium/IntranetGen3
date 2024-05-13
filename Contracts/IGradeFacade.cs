namespace MensaGymnazium.IntranetGen3.Contracts;

[ApiContract]
public interface IGradeFacade
{
	Task<List<GradeDto>> GetAllGradesAsync(CancellationToken cancellationToken = default);
	Task<List<GradeRegistrationCriteriaDto>> GetGradeRegistrationCriteriasAsync(CancellationToken cancellationToken = default);
	Task UpdateGradeRegistrationCriteriaAsync(GradeRegistrationCriteriaDto model, CancellationToken cancellationToken = default);
}
