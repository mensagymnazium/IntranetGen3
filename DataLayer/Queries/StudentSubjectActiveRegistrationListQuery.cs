using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.DataSources;

namespace MensaGymnazium.IntranetGen3.DataLayer.Queries;

[Service]
public class StudentSubjectActiveRegistrationListQuery : QueryBase<StudentSubjectRegistrationDto>, IStudentSubjectActiveRegistrationListQuery
{
	private readonly IStudentSubjectRegistrationDataSource studentSubjectRegistrationDataSource;

	public StudentSubjectActiveRegistrationListQuery(IStudentSubjectRegistrationDataSource studentSubjectRegistrationDataSource)
	{
		this.studentSubjectRegistrationDataSource = studentSubjectRegistrationDataSource;
	}

	public StudentSubjectRegistrationListQueryFilter Filter { get; set; }
	public SortItem[] Sorting { get; set; }

	protected override IQueryable<StudentSubjectRegistrationDto> Query()
	{
		Contract.Requires<InvalidOperationException>(this.Filter is not null);

		return studentSubjectRegistrationDataSource.Data
			.WhereIf(Filter.SubjectId is not null, ssr => ssr.SubjectId == Filter.SubjectId)
			.WhereIf(Filter.GradeId is not null, ssr => ssr.Student.GradeId == Filter.GradeId)
			.WhereIf(Filter.StudentId is not null, ssr => ssr.StudentId == Filter.StudentId)
			.WhereIf(Filter.RegistrationType is not null, ssr => ssr.RegistrationType == Filter.RegistrationType)
			.OrderByMultiple(Sorting, sortingExpression => sortingExpression switch
			{
				nameof(StudentSubjectRegistrationDto.SubjectId) => [s => s.Subject.Name, s => s.Student.User.Name],
				nameof(StudentSubjectRegistrationDto.StudentId) => [s => s.Student.User.Name, s => s.Subject.Name],
				nameof(StudentSubjectRegistrationDto.RegistrationType) =>
					[s => s.RegistrationType, s => s.Subject.Name, s => s.Student.User.Name],
				"StudentGradeId" => [s => -s.Student.GradeId],
				_ => throw new InvalidOperationException($"Unknown SortingItem.Expression {sortingExpression}.")
			})
			.Select(ssr => new StudentSubjectRegistrationDto()
			{
				Id = ssr.Id,
				StudentId = ssr.StudentId,
				SubjectId = ssr.SubjectId,
				RegistrationType = ssr.RegistrationType,
				Created = ssr.Created,
			});
	}

	public async Task<DataFragmentResult<StudentSubjectRegistrationDto>> GetDataFragmentResultAsync(int startIndex, int? count, CancellationToken cancellationToken = default)
	{
		var dataFragment = await GetDataFragmentAsync(startIndex, count, cancellationToken);
		return dataFragment.ToDataFragmentResult();
	}
}
