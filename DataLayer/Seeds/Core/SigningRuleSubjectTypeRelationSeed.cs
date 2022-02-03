//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Havit.Data.Patterns.DataSeeds;
//using MensaGymnazium.IntranetGen3.Model;

//namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core
//{
//	public class SigningRuleSubjectTypeRelationSeed : DataSeed<CoreProfile>
//	{
//		public override void SeedData()
//		{
//			var data = new[]
//			{
//				new SigningRuleSubjectTypeRelation()
//				{
//					SigningRuleId = 1,
//					SubjectTypeId = (int)SubjectType.Entry.NotDefined,
//				},
//				new SigningRuleSubjectTypeRelation()
//				{
//					SigningRuleId = 1,
//					SubjectTypeId = (int)SubjectType.Entry.HumanHealth,
//				},
//				new SigningRuleSubjectTypeRelation()
//				{
//					SigningRuleId = 1,
//					SubjectTypeId = (int)SubjectType.Entry.HumanNature,
//				},
//				new SigningRuleSubjectTypeRelation()
//				{
//					SigningRuleId = 1,
//					SubjectTypeId = (int)SubjectType.Entry.HumanSociety,
//				},
//				new SigningRuleSubjectTypeRelation()
//				{
//					SigningRuleId = 1,
//					SubjectTypeId = (int)SubjectType.Entry.HumanWork,
//				},
//				new SigningRuleSubjectTypeRelation()
//				{
//					SigningRuleId = 1,
//					SubjectTypeId = (int)SubjectType.Entry.ArtCulture,
//				},
//				new SigningRuleSubjectTypeRelation()
//				{
//					SigningRuleId = 1,
//					SubjectTypeId = (int)SubjectType.Entry.Informatics,
//				},
//				new SigningRuleSubjectTypeRelation()
//				{
//					SigningRuleId = 1,
//					SubjectTypeId = (int)SubjectType.Entry.MathApplication,
//				},
//				new SigningRuleSubjectTypeRelation()
//				{
//					SigningRuleId = 1,
//					SubjectTypeId = (int)SubjectType.Entry.LanguageCommunication,
//				},


//				new SigningRuleSubjectTypeRelation()
//				{
//					SigningRuleId = 2,
//					SubjectTypeId = (int)SubjectType.Entry.NotDefined,
//				},
//				new SigningRuleSubjectTypeRelation()
//				{
//					SigningRuleId = 2,
//					SubjectTypeId = (int)SubjectType.Entry.HumanHealth,
//				},
//				new SigningRuleSubjectTypeRelation()
//				{
//					SigningRuleId = 2,
//					SubjectTypeId = (int)SubjectType.Entry.HumanNature,
//				},
//				new SigningRuleSubjectTypeRelation()
//				{
//					SigningRuleId = 2,
//					SubjectTypeId = (int)SubjectType.Entry.HumanSociety,
//				},
//				new SigningRuleSubjectTypeRelation()
//				{
//					SigningRuleId = 2,
//					SubjectTypeId = (int)SubjectType.Entry.HumanWork,
//				},
//				new SigningRuleSubjectTypeRelation()
//				{
//					SigningRuleId = 2,
//					SubjectTypeId = (int)SubjectType.Entry.ArtCulture,
//				},
//				new SigningRuleSubjectTypeRelation()
//				{
//					SigningRuleId = 2,
//					SubjectTypeId = (int)SubjectType.Entry.Informatics,
//				},
//				new SigningRuleSubjectTypeRelation()
//				{
//					SigningRuleId = 2,
//					SubjectTypeId = (int)SubjectType.Entry.MathApplication,
//				},
//				new SigningRuleSubjectTypeRelation()
//				{
//					SigningRuleId = 2,
//					SubjectTypeId = (int)SubjectType.Entry.LanguageCommunication,
//				},


//				new SigningRuleSubjectTypeRelation()
//				{
//					SigningRuleId = 3,
//					SubjectTypeId = (int)SubjectType.Entry.LanguageCommunication,
//				},


//				new SigningRuleSubjectTypeRelation()
//				{
//					SigningRuleId = 4,
//					SubjectTypeId = (int)SubjectType.Entry.NotDefined,
//				},
//				new SigningRuleSubjectTypeRelation()
//				{
//					SigningRuleId = 4,
//					SubjectTypeId = (int)SubjectType.Entry.HumanHealth,
//				},
//				new SigningRuleSubjectTypeRelation()
//				{
//					SigningRuleId = 4,
//					SubjectTypeId = (int)SubjectType.Entry.HumanNature,
//				},
//				new SigningRuleSubjectTypeRelation()
//				{
//					SigningRuleId = 4,
//					SubjectTypeId = (int)SubjectType.Entry.HumanSociety,
//				},
//				new SigningRuleSubjectTypeRelation()
//				{
//					SigningRuleId = 4,
//					SubjectTypeId = (int)SubjectType.Entry.HumanWork,
//				},
//				new SigningRuleSubjectTypeRelation()
//				{
//					SigningRuleId = 4,
//					SubjectTypeId = (int)SubjectType.Entry.ArtCulture,
//				},
//				new SigningRuleSubjectTypeRelation()
//				{
//					SigningRuleId = 4,
//					SubjectTypeId = (int)SubjectType.Entry.Informatics,
//				},
//				new SigningRuleSubjectTypeRelation()
//				{
//					SigningRuleId = 4,
//					SubjectTypeId = (int)SubjectType.Entry.MathApplication,
//				},
//				new SigningRuleSubjectTypeRelation()
//				{
//					SigningRuleId = 4,
//					SubjectTypeId = (int)SubjectType.Entry.LanguageCommunication,
//				},
//			};

//			Seed(For(data).PairBy(st => new { st.SigningRuleId, st.SubjectTypeId }));
//		}
//	}
//}
