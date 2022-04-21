using Havit.ComponentModel;

namespace MensaGymnazium.IntranetGen3.Contracts;

[ApiContract]
public interface ISubjectTypeFacade
{
	Task<List<SubjectTypeDto>> GetAllSubjectTypesAsync(CancellationToken cancellationToken = default);
}
