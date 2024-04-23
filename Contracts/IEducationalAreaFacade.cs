using Havit.ComponentModel;

namespace MensaGymnazium.IntranetGen3.Contracts;

[ApiContract]
public interface IEducationalAreaFacade
{
	Task<List<EducationalAreaDto>> GetAllEducationalAreasAsync(CancellationToken cancellationToken = default);
}
