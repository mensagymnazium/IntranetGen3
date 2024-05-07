using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories;

namespace MensaGymnazium.IntranetGen3.Facades;

[Service]
[Authorize]
public class GradeFacade : IGradeFacade
{
	private readonly IGradeRepository _gradeRepository;

	public GradeFacade(IGradeRepository gradeRepository)
	{
		_gradeRepository = gradeRepository;
	}

	public async Task<List<GradeDto>> GetAllGradesAsync(CancellationToken cancellationToken = default)
	{
		var data = await _gradeRepository.GetAllAsync(cancellationToken);


		return data
			.Select(g => new GradeDto()
			{
				Id = g.Id,
				Name = g.Name
			})
			.ToList();
	}
}
