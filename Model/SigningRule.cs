using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Havit.Model.Collections.Generic;

namespace MensaGymnazium.IntranetGen3.Model;

public class SigningRule
{
	public int Id { get; set; }

	public Grade Grade { get; set; }
	public int GradeId { get; set; }

	[MaxLength(100)]
	public string Name { get; set; }

	[MaxLength(Int32.MaxValue)]
	public string Description { get; set; }

	public List<SigningRuleSubjectCategoryRelation> SubjectCategoryRelations { get; } = new List<SigningRuleSubjectCategoryRelation>();
	[NotMapped] public IEnumerable<SubjectCategory> SubjectCategories => SubjectCategoryRelations.Select(m => m.SubjectCategory);

	public List<SigningRuleSubjectTypeRelation> SubjectTypeRelations { get; } = new List<SigningRuleSubjectTypeRelation>();
	[NotMapped] public IEnumerable<SubjectType> SubjectTypes => SubjectTypeRelations.Select(m => m.SubjectType);

	public int? Quantity { get; set; }

	public List<StudentSubjectRegistration> RegistrationsWithDeleted { get; } = new List<StudentSubjectRegistration>();
	[NotMapped] public ICollection<StudentSubjectRegistration> Registrations { get; }

	[MaxLength(50)]
	public string SeedItemIdentifier { get; set; }

	public SigningRule()
	{
		Registrations = new FilteringCollection<StudentSubjectRegistration>(RegistrationsWithDeleted, r => r.Deleted is null);
	}
}
