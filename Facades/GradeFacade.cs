using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Havit.Extensions.DependencyInjection.Abstractions;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace MensaGymnazium.IntranetGen3.Facades;

[Service]
[Authorize]
public class GradeFacade : IGradeFacade
{
	private readonly IGradeRepository gradeRepository;

	public GradeFacade(IGradeRepository gradeRepository)
	{
		this.gradeRepository = gradeRepository;
	}

	public async Task<List<GradeDto>> GetAllGradesAsync(CancellationToken cancellationToken = default)
	{
		var data = await gradeRepository.GetAllAsync(cancellationToken);


		return data
			.Select(g => new GradeDto()
			{
				Id = g.Id,
				Name = g.Name
			})
			.ToList();
	}
}
