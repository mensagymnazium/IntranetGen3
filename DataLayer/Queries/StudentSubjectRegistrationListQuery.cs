using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.DataSources;

namespace MensaGymnazium.IntranetGen3.DataLayer.Queries;

[Service]
public class StudentSubjectRegistrationListQuery : QueryBase<StudentSubjectRegistrationDto>, IStudentSubjectRegistrationListQuery
{
	private readonly IStudentSubjectRegistrationDataSource studentSubjectRegistrationDataSource;

	public StudentSubjectRegistrationListQuery(IStudentSubjectRegistrationDataSource studentSubjectRegistrationDataSource)
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
			.WhereIf(Filter.SigningRuleId is not null, ssr => ssr.UsedSigningRuleId == Filter.SigningRuleId)
			.OrderByMultiple(Sorting, sortingExpression => sortingExpression switch
			{
				nameof(StudentSubjectRegistrationDto.SubjectId) => new() { s => s.Subject.Name, s => s.Student.User.Name },
				nameof(StudentSubjectRegistrationDto.StudentId) => new() { s => s.Student.User.Name, s => s.Subject.Name },
				nameof(StudentSubjectRegistrationDto.RegistrationType) => new() { s => s.RegistrationType, s => s.Subject.Name, s => s.Student.User.Name },
				nameof(StudentSubjectRegistrationDto.SigningRuleId) => new() { s => s.UsedSigningRule.Name, s => s.Subject.Name, s => s.Student.User.Name },
				"StudentGradeId" => new() { s => -s.Student.GradeId },
				_ => throw new InvalidOperationException($"Unknown SortingItem.Expression {sortingExpression}.")
			})
			.Select(ssr => new StudentSubjectRegistrationDto()
			{
				Id = ssr.Id,
				StudentId = ssr.StudentId,
				SubjectId = ssr.SubjectId,
				RegistrationType = ssr.RegistrationType,
				SigningRuleId = ssr.UsedSigningRuleId,
				Created = ssr.Created,
			});
	}

	public async Task<DataFragmentResult<StudentSubjectRegistrationDto>> GetDataFragmentAsync(int startIndex, int? count, CancellationToken cancellationToken = default)
	{
		return new()
		{
			Data = await SelectDataFragmentAsync(startIndex, count, cancellationToken),
			TotalCount = await CountAsync(cancellationToken)
		};
	}
}
