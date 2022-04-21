using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories;

namespace MensaGymnazium.IntranetGen3.Facades;

[Service]
[Authorize]
public class SubjectTypeFacade : ISubjectTypeFacade
{
	private readonly ISubjectTypeRepository subjectTypeRepository;

	public SubjectTypeFacade(ISubjectTypeRepository subjectTypeRepository)
	{
		this.subjectTypeRepository = subjectTypeRepository;
	}

	public async Task<List<SubjectTypeDto>> GetAllSubjectTypesAsync(CancellationToken cancellationToken = default)
	{
		var data = await subjectTypeRepository.GetAllAsync(cancellationToken);
		return data
			.Select(c => new SubjectTypeDto()
			{
				Id = c.Id,
				Name = c.Name,
			})
			.ToList();
	}
}
