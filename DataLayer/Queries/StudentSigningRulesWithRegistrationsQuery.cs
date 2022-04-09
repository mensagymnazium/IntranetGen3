using Havit.Data.Patterns.DataLoaders;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.DataSources;
using MensaGymnazium.IntranetGen3.Model;
using MensaGymnazium.IntranetGen3.Model.Security;

namespace MensaGymnazium.IntranetGen3.DataLayer.Queries;

[Service]
public class StudentSigningRulesWithRegistrationsQuery : QueryBase<SigningRuleWithRegistrationsDto>, IStudentSigningRulesWithRegistrationsQuery
{
	private readonly ISigningRuleDataSource signingRuleDataSource;

	protected Student Student { get; set; }
	protected Subject SubjectFilter { get; set; }

	public StudentSigningRulesWithRegistrationsQuery(
		ISigningRuleDataSource signingRuleDataSource)
	{
		this.signingRuleDataSource = signingRuleDataSource;
	}

	protected override IQueryable<SigningRuleWithRegistrationsDto> Query()
	{
		Contract.Requires<ArgumentException>(Student is not null);

		var data = signingRuleDataSource.Data
			.Where(x => x.GradeId == this.Student.GradeId);

		if (this.SubjectFilter is not null)
		{
			data = data.Where(sr => this.SubjectFilter.GradeRelations.Select(gr => gr.GradeId).Contains(sr.GradeId));
			data = data.Where(sr => sr.SubjectTypeRelations.Any(str => this.SubjectFilter.TypeRelations.Select(tr => tr.SubjectTypeId).Contains(str.SubjectTypeId)));
			data = data.Where(sr => sr.SubjectCategoryRelations.Any(scr => scr.SubjectCategoryId == this.SubjectFilter.CategoryId));
		}

		return data.Select(sr => new SigningRuleWithRegistrationsDto()
		{
			Id = sr.Id,
			GradeId = sr.GradeId,
			Name = sr.Name,
			Quantity = sr.Quantity,
			SubjectCategoryIds = sr.SubjectCategoryRelations.Select(scr => scr.SubjectCategoryId).ToList(),
			SubjectTypeIds = sr.SubjectTypeRelations.Select(str => str.SubjectTypeId).ToList(),
			Registrations = sr.Registrations.Where(r => (r.StudentId == this.Student.Id) && (r.Deleted == null))
								.Select(ssr => new StudentSubjectRegistrationDto()
								{
									Id = ssr.Id,
									StudentId = ssr.StudentId,
									SigningRuleId = ssr.UsedSigningRuleId,
									SubjectId = ssr.SubjectId,
									RegistrationType = ssr.RegistrationType,
									Created = ssr.Created,
								})
								.ToList()
		});
	}

	public Task<List<SigningRuleWithRegistrationsDto>> GetDataAsync(Student student, Subject subjectFilter = null, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentException>(student is not null);

		this.Student = student;
		this.SubjectFilter = subjectFilter;

		return this.SelectAsync(cancellationToken);
	}
}
