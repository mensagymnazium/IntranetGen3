//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Havit.Data.Patterns.DataSeeds;
//using MensaGymnazium.IntranetGen3.Model;

//namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core
//{
//	public class SigningRuleSubjectCategoryRelationSeed : DataSeed<CoreProfile>
//	{
//		public override void SeedData()
//		{
//			var data = new[]
//			{
//				new SigningRuleSubjectCategoryRelation()
//				{
//					SigningRuleId = 1,
//					SubjectCategoryId = (int)SubjectCategory.Entry.SpecialSeminars,
//				},

//				new SigningRuleSubjectCategoryRelation()
//				{
//					SigningRuleId = 1,
//					SubjectCategoryId = (int)SubjectCategory.Entry.ForeignLanguage,
//				},

//				new SigningRuleSubjectCategoryRelation()
//				{
//					SigningRuleId = 2,
//					SubjectCategoryId = (int)SubjectCategory.Entry.SpecialSeminars,
//				},

//				new SigningRuleSubjectCategoryRelation()
//				{
//					SigningRuleId = 3,
//					SubjectCategoryId = (int)SubjectCategory.Entry.ForeignLanguage,
//				},

//				new SigningRuleSubjectCategoryRelation()
//				{
//					SigningRuleId = 4,
//					SubjectCategoryId = (int)SubjectCategory.Entry.SpecialSeminars,
//				},
//			};

//			Seed(For(data).PairBy(st => new { st.SigningRuleId, st.SubjectCategoryId })); ;
//		}

//	}
//}
