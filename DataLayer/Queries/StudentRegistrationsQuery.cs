//using Havit.Data.Patterns.DataLoaders;
//using MensaGymnazium.IntranetGen3.Contracts;
//using MensaGymnazium.IntranetGen3.DataLayer.DataSources;
//using MensaGymnazium.IntranetGen3.Model;
//using MensaGymnazium.IntranetGen3.Model.Security;
//using MensaGymnazium.IntranetGen3.Primitives;

//namespace MensaGymnazium.IntranetGen3.DataLayer.Queries;

//[Service]
//public class StudentRegistrationsQuery : QueryBase<RegistrationsDto>, IStudentRegistrationsQuery
//{
//	protected Student Student { get; set; }
//	protected Subject SubjectFilter { get; set; }

//	protected override IQueryable<RegistrationsDto> Query()
//	{
//		Contract.Requires<ArgumentException>(Student is not null);

//		//var studentNextGrade = ((GradeEntry)this.Student.GradeId).NextGrade();

//		//var signingRulesData = signingRuleDataSource.Data
//			//.Where(x => x.GradeId == (int)studentNextGrade);

//		//if (this.SubjectFilter is not null)
//		//{
//		//	signingRulesData = signingRulesData.Where(sr => this.SubjectFilter.GradeRelations.Select(gr => gr.GradeId).Contains(sr.GradeId));
//		//	signingRulesData = signingRulesData.Where(sr => sr.SubjectTypeRelations.Any(str => this.SubjectFilter.TypeRelations.Select(tr => tr.SubjectTypeId).Contains(str.SubjectTypeId)));
//		//	signingRulesData = signingRulesData.Where(sr => sr.SubjectCategoryRelations.Any(scr => scr.SubjectCategoryId == this.SubjectFilter.CategoryId));
//		//}



//		return signingRulesData.Select(sr => new RegistrationsDto()
//		{
//			Id = sr.Id,
//			GradeId = (GradeEntry)sr.GradeId,
//			Name = sr.Name,
//			Quantity = sr.Quantity,
//			SubjectCategoryIds = sr.SubjectCategoryRelations.Select(scr => scr.SubjectCategoryId).ToList(),
//			SubjectTypeIds = sr.SubjectTypeRelations.Select(str => str.SubjectTypeId).ToList(),
//			Registrations = sr.RegistrationsWithDeleted.Where(r => (r.StudentId == this.Student.Id) && (r.Deleted == null))
//								.Select(ssr => new StudentSubjectRegistrationDto()
//								{
//									Id = ssr.Id,
//									StudentId = ssr.StudentId,
//									SigningRuleId = ssr.UsedSigningRuleId,
//									SubjectId = ssr.SubjectId,
//									RegistrationType = ssr.RegistrationType,
//									Created = ssr.Created,
//								})
//								.ToList()
//		});
//	}

//	public Task<List<RegistrationsDto>> GetDataAsync(Student student, Subject subjectFilter = null, CancellationToken cancellationToken = default)
//	{
//		Contract.Requires<ArgumentException>(student is not null);

//		this.Student = student;
//		this.SubjectFilter = subjectFilter;

//		return this.SelectAsync(cancellationToken);
//	}
//}
