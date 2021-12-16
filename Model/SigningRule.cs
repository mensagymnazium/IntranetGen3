using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MensaGymnazium.IntranetGen3.Model.Security;

namespace MensaGymnazium.IntranetGen3.Model
{
	public class SigningRule
	{
		public int Id { get; set; }

		public Grade Grade { get; set; }
		public int GradeId { get; set; }

		public List<SigningRuleSubjectCategoryRelation> SubjectCategoryRelations { get; } = new List<SigningRuleSubjectCategoryRelation>();
		[NotMapped] public IEnumerable<SubjectCategory> SubjectCategories => SubjectCategoryRelations.Select(m => m.SubjectCategory);

		public List<SigningRuleSubjectTypeRelation> SubjectTypeRelations { get; } = new List<SigningRuleSubjectTypeRelation>();
		[NotMapped] public IEnumerable<SubjectType> SubjectTypes => SubjectTypeRelations.Select(m => m.SubjectType);

		public int? Quantity { get; set; }
	}
}
