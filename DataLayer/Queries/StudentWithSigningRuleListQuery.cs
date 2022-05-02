using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.DataSources;
using MensaGymnazium.IntranetGen3.DataLayer.DataSources.Security;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.DataLayer.Queries;

[Service]
public class StudentWithSigningRuleListQuery : QueryBase<StudentWithSigningRuleListItemDto>, IStudentWithSigningRuleListQuery
{
	private readonly IStudentDataSource studentDataSource;
	private readonly ISigningRuleDataSource signingRuleDataSource;

	public StudentWithSigningRuleListQuery(
		IStudentDataSource studentDataSource,
		ISigningRuleDataSource signingRuleDataSource)
	{
		this.studentDataSource = studentDataSource;
		this.signingRuleDataSource = signingRuleDataSource;
	}

	public StudentWithSigningRuleListQueryFilter Filter { get; set; }
	public SortItem[] Sorting { get; set; }

	protected override IQueryable<StudentWithSigningRuleListItemDto> Query()
	{
		var data = studentDataSource.Data
			.Join(signingRuleDataSource.Data, s => s.GradeId - 1, sr => sr.GradeId, (student, signingRule) => new { student, signingRule })
			.WhereIf(Filter.GradeId.HasValue, i => i.student.GradeId == Filter.GradeId)
			.WhereIf(Filter.StudentId.HasValue, i => i.student.Id == Filter.StudentId)
			.WhereIf(Filter.SigningRuleId.HasValue, i => i.signingRule.Id == Filter.SigningRuleId)
			.OrderBy(Sorting, sortingExpression => sortingExpression switch
			{
				nameof(StudentWithSigningRuleListItemDto.StudentId) => (i => i.student.User.Name),
				nameof(StudentWithSigningRuleListItemDto.SigningRuleId) => (i => i.signingRule.Name),
				_ => throw new InvalidOperationException($"Unknown SortingItem.Expression {sortingExpression}.")
			})
			.Select(x => new StudentWithSigningRuleListItemDto
			{
				StudentId = x.student.Id,
				SigningRuleId = x.signingRule.Id,
				SigningRuleQuantity = x.signingRule.Quantity,
				MainRegistrationsCount = x.signingRule.Registrations.Count(r => (r.Deleted == null) && (r.RegistrationType == StudentRegistrationType.Main) && (r.StudentId == x.student.Id)),
				SecondaryRegistrationsCount = x.signingRule.Registrations.Count(r => (r.Deleted == null) && (r.RegistrationType == StudentRegistrationType.Secondary) && (r.StudentId == x.student.Id)),
			});

		return data;
	}

	public async Task<DataFragmentResult<StudentWithSigningRuleListItemDto>> GetDataFragmentAsync(int startIndex, int? count, CancellationToken cancellationToken = default)
	{
		return new()
		{
			Data = await SelectDataFragmentAsync(startIndex, count, cancellationToken),
			TotalCount = await CountAsync(cancellationToken)
		};
	}

}
