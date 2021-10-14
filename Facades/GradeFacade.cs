using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Havit.Extensions.DependencyInjection.Abstractions;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories;

namespace MensaGymnazium.IntranetGen3.Facades
{
	[Service]
	public class GradeFacade : IGradeFacade
	{
		private readonly IGradeRepository gradeRepository;

		public GradeFacade(IGradeRepository gradeRepository)
		{
			this.gradeRepository = gradeRepository;
		}

		public async Task<Dto<List<GradeListItemDto>>> GetAllGradesAsync()
		{
			var data = await gradeRepository.GetAllAsync();

			var result = data
				.Select(g => new GradeListItemDto()
				{
					Id = g.Id,
					Name = g.Name
				})
				.ToList();

			return Dto.FromValue(result);
		}
	}
}
