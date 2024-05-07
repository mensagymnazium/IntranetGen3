using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories;

namespace MensaGymnazium.IntranetGen3.Facades;

[Service]
[Authorize]
public class SubjectCategoryFacade : ISubjectCategoryFacade
{
	private readonly ISubjectCategoryRepository _subjectCategoryRepository;

	public SubjectCategoryFacade(ISubjectCategoryRepository subjectCategoryRepository)
	{
		_subjectCategoryRepository = subjectCategoryRepository;
	}

	public async Task<List<SubjectCategoryDto>> GetAllSubjectCategoriesAsync(CancellationToken cancellationToken = default)
	{
		var data = await _subjectCategoryRepository.GetAllAsync(cancellationToken);
		return data
			.Select(c => new SubjectCategoryDto()
			{
				Id = c.Id,
				Name = c.Name,
			})
			.ToList();
	}
}
