﻿using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories;

namespace MensaGymnazium.IntranetGen3.Facades;

[Service]
[Authorize]
public class SubjectCategoryFacade : ISubjectCategoryFacade
{
	private readonly ISubjectCategoryRepository subjectCategoryRepository;

	public SubjectCategoryFacade(ISubjectCategoryRepository subjectCategoryRepository)
	{
		this.subjectCategoryRepository = subjectCategoryRepository;
	}

	public async Task<List<SubjectCategoryDto>> GetAllSubjectCategoriesAsync(CancellationToken cancellationToken = default)
	{
		var data = await subjectCategoryRepository.GetAllAsync(cancellationToken);
		return data
			.Select(c => new SubjectCategoryDto()
			{
				Id = c.Id,
				Name = c.Name,
			})
			.ToList();
	}
}
