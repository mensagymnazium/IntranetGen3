using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.DataSources;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.DataLayer.Queries;

[Service]
public class SubjectListQuery : QueryBase<SubjectListItemDto>, ISubjectListQuery
{
	private readonly ISubjectDataSource subjectDataSource;
	private readonly IStudentSubjectRegistrationDataSource studentSubjectRegistrationDataSource;

	public SubjectListQuery(
		ISubjectDataSource subjectDataSource,
		IStudentSubjectRegistrationDataSource studentSubjectRegistrationDataSource)
	{
		this.subjectDataSource = subjectDataSource;
		this.studentSubjectRegistrationDataSource = studentSubjectRegistrationDataSource;
	}

	public SubjectListQueryFilter Filter { get; set; }
	public SortItem[] Sorting { get; set; }

	protected override IQueryable<SubjectListItemDto> Query()
	{
		var data = subjectDataSource.Data
			.WhereIf(!String.IsNullOrWhiteSpace(Filter.Name), s => s.Name.Contains(Filter.Name))
			.WhereIf(Filter.EducationalAreaId != null,
				s => s.EducationalAreaRelations.Any(r => r.EducationalAreaId == Filter.EducationalAreaId))
			.WhereIf(Filter.SubjectCategoryId != null, s => s.CategoryId == Filter.SubjectCategoryId)
			.WhereIf(Filter.TeacherId != null, s => s.TeacherRelations.Any(tr => tr.TeacherId == Filter.TeacherId))
			.WhereIf(Filter.GradeId is not null, s => s.GradeRelations.Any(g => g.GradeId == Filter.GradeId));

		data = data
			.OrderByMultiple(Sorting, sortingExpression => sortingExpression switch
			 {
				 nameof(SubjectListItemDto.Name) => new() { s => s.Name },
				 nameof(SubjectListItemDto.TeacherIds) => new() { s => s.TeacherRelations.FirstOrDefault().Teacher.User.Name },
				 nameof(SubjectListItemDto.Capacity) => new() { s => s.Capacity },
				 nameof(SubjectListItemDto.ScheduleSlotInDay) => new() { s => s.ScheduleDayOfWeek, s => s.ScheduleSlotInDay },
				 nameof(SubjectListItemDto.CategoryId) => new() { s => s.Category.Name },
				 nameof(SubjectListItemDto.GradeIds) => new() { s => s.GradeRelations.FirstOrDefault().GradeId },
				 nameof(SubjectListItemDto.EducationalAreaIds) => new() { s => s.EducationalAreaRelations.FirstOrDefault().EducationalArea.Name },
				 _ => throw new InvalidOperationException($"Unknown SortingItem.Expression {sortingExpression}.")
			 });

		var result = data.Select(s => new SubjectListItemDto()
		{
			Id = s.Id,
			Name = s.Name,
			CategoryId = s.CategoryId,
			EducationalAreaIds = s.EducationalAreaRelations.Select(tr => tr.EducationalAreaId).ToList(),
			Capacity = s.Capacity,
			StudentRegistrationsCountMain = studentSubjectRegistrationDataSource.Data.Count(ssr => ssr.SubjectId == s.Id && ssr.RegistrationType == StudentRegistrationType.Main),
			StudentRegistrationsCountSecondary = studentSubjectRegistrationDataSource.Data.Count(ssr => ssr.SubjectId == s.Id && ssr.RegistrationType == StudentRegistrationType.Secondary),
			GradeIds = s.GradeRelations.Select(tr => tr.GradeId).ToList(),
			TeacherIds = s.TeacherRelations.Select(tr => tr.TeacherId).ToList(),
			ScheduleSlotInDay = s.ScheduleSlotInDay,
			ScheduleDayOfWeek = s.ScheduleDayOfWeek,
		});

		return result;
	}

	public async Task<DataFragmentResult<SubjectListItemDto>> GetDataFragmentResultAsync(int startIndex, int? count, CancellationToken cancellationToken = default)
	{
		var dataFragment = await GetDataFragmentAsync(startIndex, count, cancellationToken);
		return dataFragment.ToDataFragmentResult();
	}
}
