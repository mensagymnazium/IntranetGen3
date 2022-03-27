using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Model;

namespace MensaGymnazium.IntranetGen3.Services
{
	[Service]
	public class SubjectMapper : ISubjectMapper
	{
		private readonly IDataLoader dataLoader;

		public SubjectMapper(IDataLoader dataLoader)
		{
			this.dataLoader = dataLoader;
		}

		public void MapFromSubjectDto(SubjectDto subjectDto, Subject subject)
		{
			Contract.Requires<ArgumentNullException>(subjectDto is not null);
			Contract.Requires<ArgumentNullException>(subject is not null);

			subject.Name = subjectDto.Name;
		}

		public async Task<SubjectDto> MapToSubjectDtoAsync(Subject subject, CancellationToken cancellationToken = default)
		{
			Contract.Requires<ArgumentNullException>(subject is not null);

			await dataLoader.LoadAsync(subject, s => s.TeacherRelations, cancellationToken);
			await dataLoader.LoadAsync(subject, s => s.GradeRelations, cancellationToken);
			await dataLoader.LoadAsync(subject, s => s.TypeRelations, cancellationToken);

			return new SubjectDto
			{
				SubjectId = subject.Id,
				Name = subject.Name,
				Description = subject.Description,
				CategoryId = subject.CategoryId,
				SubjectTypeIds = subject.TypeRelations.Select(tr => tr.SubjectTypeId).ToList(),
				Capacity = subject.Capacity,
				GradeIds = subject.GradeRelations.Select(tr => tr.GradeId).ToList(),
				TeacherIds = subject.TeacherRelations.Select(tr => tr.TeacherId).ToList(),
				ScheduleSlotInDay = subject.ScheduleSlotInDay,
				ScheduleDayOfWeek = subject.ScheduleDayOfWeek,
			};
		}
	}
}
