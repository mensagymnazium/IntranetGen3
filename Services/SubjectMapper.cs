using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Havit.Diagnostics.Contracts;
using Havit.Extensions.DependencyInjection.Abstractions;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Model;

namespace MensaGymnazium.IntranetGen3.Services
{
	[Service]
	public class SubjectMapper : ISubjectMapper
	{
		public void MapFromSubjectDto(SubjectDto subjectDto, Subject subject)
		{
			Contract.Requires<ArgumentNullException>(subjectDto is not null);
			Contract.Requires<ArgumentNullException>(subject is not null);

			subject.Name = subjectDto.Name;
		}

		public SubjectDto MapToSubjectDto(Subject subject)
		{
			Contract.Requires<ArgumentNullException>(subject is not null);

			return new SubjectDto
			{
				Id = subject.Id,
				Name = subject.Name

			};
		}
	}
}
