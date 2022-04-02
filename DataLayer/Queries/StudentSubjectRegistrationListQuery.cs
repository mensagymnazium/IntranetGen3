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

	protected override IQueryable<StudentSubjectRegistrationDto> Query()
	{
		Contract.Requires<InvalidOperationException>(this.Filter is not null);

		return studentSubjectRegistrationDataSource.Data
			.WhereIf(Filter.SubjectId is not null, ssr => ssr.SubjectId == Filter.SubjectId)
			.Select(ssr => new StudentSubjectRegistrationDto()
			{
				Id = ssr.Id,
				StudentId = ssr.StudentId,
				SubjectId = ssr.SubjectId,
				RegistrationType = ssr.RegistrationType,
				SigningRuleId = ssr.UsedSigningRuleId
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
