using Havit.Collections;
using Havit.Data.EntityFrameworkCore.Patterns.QueryServices;
using Havit.Extensions.DependencyInjection.Abstractions;
using Havit.Linq;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.DataSources;

namespace MensaGymnazium.IntranetGen3.DataLayer.Queries
{
	[Service]
	public class SubjectListQuery : QueryBase<SubjectListItemDto>, ISubjectListQuery
	{
		private readonly ISubjectDataSource subjectDataSource;

		public SubjectListQuery(ISubjectDataSource subjectDataSource)
		{
			this.subjectDataSource = subjectDataSource;
		}

		public SubjectListQueryFilter Filter { get; set; }
		public SortItem[] Sorting { get; set; }

		protected override IQueryable<SubjectListItemDto> Query()
		{
			var data = subjectDataSource.Data
				.WhereIf(!String.IsNullOrWhiteSpace(Filter.Name), s => s.Name.Contains(Filter.Name))
				.WhereIf(Filter.SubjectTypeId != null, s => s.TypeRelations.Any(r => r.SubjectTypeId == Filter.SubjectTypeId))
				.WhereIf(Filter.SubjectCategoryId != null, s => s.CategoryId == Filter.SubjectCategoryId)
				.WhereIf(Filter.TeacherId != null, s => s.TeacherRelations.Any(tr => tr.TeacherId == Filter.TeacherId))
				.OrderByMultiple(Sorting, sortingExpression => sortingExpression switch
				 {
					 nameof(SubjectListItemDto.Name) => new() { s => s.Name },
					 nameof(SubjectListItemDto.TeacherIds) => new() { s => s.TeacherRelations.FirstOrDefault().Teacher.User.Name },
					 nameof(SubjectListItemDto.Capacity) => new() { s => s.Capacity },
					 nameof(SubjectListItemDto.ScheduleSlotInDay) => new() { s => s.ScheduleDayOfWeek, s => s.ScheduleSlotInDay },
					 nameof(SubjectListItemDto.CategoryId) => new() { s => s.Category.Name },
					 nameof(SubjectListItemDto.SubjectTypeIds) => new() { s => s.TypeRelations.FirstOrDefault().SubjectType.Name },
					 _ => throw new InvalidOperationException($"Unknown SortingItem.Expression {sortingExpression}.")
				 });

			var result = data.Select(s => new SubjectListItemDto()
			{
				SubjectId = s.Id,
				Name = s.Name,
				CategoryId = s.CategoryId,
				SubjectTypeIds = s.TypeRelations.Select(tr => tr.SubjectTypeId).ToList(),
				Capacity = s.Capacity,
				GradeIds = s.GradeRelations.Select(tr => tr.GradeId).ToList(),
				TeacherIds = s.TeacherRelations.Select(tr => tr.TeacherId).ToList(),
				ScheduleSlotInDay = s.ScheduleSlotInDay,
				ScheduleDayOfWeek = s.ScheduleDayOfWeek,
			});

			return result;
		}

		public async Task<DataFragmentResult<SubjectListItemDto>> GetDataFragmentAsync(int startIndex, int? count, CancellationToken cancellationToken = default)
		{
			return new()
			{
				Data = await SelectDataFragmentAsync(startIndex, count, cancellationToken),
				TotalCount = await CountAsync(cancellationToken)
			};
		}

	}
}
