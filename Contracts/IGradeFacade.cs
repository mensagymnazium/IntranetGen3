using Havit.ComponentModel;

namespace MensaGymnazium.IntranetGen3.Contracts;

[ApiContract]
public interface IGradeFacade
{
	Task<List<GradeDto>> GetAllGradesAsync(CancellationToken cancellationToken = default);
}
