using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories;

namespace MensaGymnazium.IntranetGen3.Facades;

[Service]
[Authorize]
public class GraduationSubjectFacade : IGraduationSubjectFacade
{
	private readonly IGraduationSubjectRepository _graduationSubjectRepository;

	public GraduationSubjectFacade(IGraduationSubjectRepository graduationSubjectRepository)
	{
		this._graduationSubjectRepository = graduationSubjectRepository;
	}

	public async Task<List<GraduationSubjectDto>> GetAllGraduationSubjectsAsync(CancellationToken cancellationToken = default)
	{
		var data = await _graduationSubjectRepository.GetAllAsync(cancellationToken);
		return data
			.Select(c => new GraduationSubjectDto()
			{
				Id = c.Id,
				Name = c.Name,
			})
			.ToList();
	}
}