using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories;

namespace MensaGymnazium.IntranetGen3.Facades;

[Service]
[Authorize]
public class EducationalAreaFacade : IEducationalAreaFacade
{
	private readonly IEducationalAreaRepository _educationalAreaRepository;

	public EducationalAreaFacade(IEducationalAreaRepository educationalAreaRepository)
	{
		_educationalAreaRepository = educationalAreaRepository;
	}

	public async Task<List<EducationalAreaDto>> GetAllEducationalAreasAsync(CancellationToken cancellationToken = default)
	{
		var data = await _educationalAreaRepository.GetAllAsync(cancellationToken);
		return data
			.Select(c => new EducationalAreaDto()
			{
				Id = c.Id,
				Name = c.Name,
			})
			.ToList();
	}
}
