//using System.Linq.Expressions;
//using MensaGymnazium.IntranetGen3.Model;

//namespace MensaGymnazium.IntranetGen3.DataLayer.Repositories;

//public partial class SigningRuleDbRepository : ISigningRuleRepository
//{
//	protected override IEnumerable<Expression<Func<SigningRule, object>>> GetLoadReferences()
//	{
//		yield return sr => sr.SubjectTypeRelations;
//		yield return sr => sr.SubjectCategoryRelations;
//	}
//}