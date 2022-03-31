using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Havit.Data.Patterns.DataSeeds;
using MensaGymnazium.IntranetGen3.Model;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core;

public class SigningRuleSeed : DataSeed<CoreProfile>
{
	public override void SeedData()
	{
		var data = new[]
		{
			new SigningRule() {
				Name = "Sekunda - Specializovaný seminář nebo jazyk",
				Description = "Je potřeba si zvolit jeden specializační seminář nebo jazyk",
				GradeId = (int) Grade.Entry.Sekunda,
				Quantity = 1,
				SubjectCategoryRelations =
				{
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.SpecialSeminars },
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.ForeignLanguage },
				},
				SubjectTypeRelations =
				{
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanHealth },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanNature },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanSociety },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanWork },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.ArtCulture },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.Informatics },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.MathApplication },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.LanguageCommunication },
				}
			},
			new SigningRule() {
				Name = "Tercie - Specializovaný seminář",
				Description = "Je potřeba si zvolit jeden specializační seminář",
				GradeId = (int) Grade.Entry.Tercie,
				Quantity = 1,
				SubjectCategoryRelations =
				{
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.SpecialSeminars },
				},
				SubjectTypeRelations =
				{
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanHealth },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanNature },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanSociety },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanWork },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.ArtCulture },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.Informatics },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.MathApplication },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.LanguageCommunication },
				}
			},
			new SigningRule()
			{
				Name = "Tercie - Jazyk",
				Description = "Je potřeba si zvolit jeden jazyk (pokud již nebyl zvolen v Sekundě)",
				GradeId = (int) Grade.Entry.Tercie,
				Quantity = 1,
				SubjectCategoryRelations =
				{
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.ForeignLanguage },
				},
				SubjectTypeRelations =
				{
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.LanguageCommunication },
				}
			},

			new SigningRule()
			{
				Name = "Kvarta - Specializovaný seminář",
				Description = "Je potřeba si zvolit jeden specializační seminář",
				GradeId = (int) Grade.Entry.Kvarta,
				Quantity = 1,
				SubjectCategoryRelations =
				{
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.SpecialSeminars },
				},
				SubjectTypeRelations =
				{
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanHealth },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanNature },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanSociety },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanWork },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.ArtCulture },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.Informatics },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.MathApplication },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.LanguageCommunication },
				}
			},

			new SigningRule()
			{
				Name = "Kvinta - Nadstavbový seminář",
				Description = "Je potřeba si zvolit jeden nadstavbový seminář",
				GradeId = (int) Grade.Entry.Kvinta,
				Quantity = 1,
				SubjectCategoryRelations =
				{
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.Seminars },
				},
				SubjectTypeRelations =
				{
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanHealth },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanNature },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanSociety },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanWork },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.ArtCulture },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.Informatics },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.MathApplication },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.LanguageCommunication },
				}
			},
			new SigningRule()
			{
				Name = "Kvinta - Druhý seminář",
				Description = "Je potřeba si zvolit jeden specializační nebo nadstavbový seminář",
				GradeId = (int) Grade.Entry.Kvinta,
				Quantity = 1,
				SubjectCategoryRelations =
				{
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.SpecialSeminars },
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.Seminars },
				},
				SubjectTypeRelations =
				{
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanHealth },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanNature },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanSociety },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanWork },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.ArtCulture },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.Informatics },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.MathApplication },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.LanguageCommunication },
				}
			},
			new SigningRule()
			{
				Name = "Sexta - Druhý seminář",
				Description = "Je potřeba si zvolit jeden specializační nebo nadstavbový seminář",
				GradeId = (int) Grade.Entry.Sexta,
				Quantity = 1,
				SubjectCategoryRelations =
				{
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.SpecialSeminars },
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.Seminars },
				},
				SubjectTypeRelations =
				{
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanHealth },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanNature },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanSociety },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanWork },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.ArtCulture },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.Informatics },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.MathApplication },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.LanguageCommunication },
				}
			},
			new SigningRule()
			{
				Name = "Septima - dva semináře",
				Description = "Je potřeba si zvolit dva semináře",
				GradeId = (int) Grade.Entry.Septima,
				Quantity = 2,
				SubjectCategoryRelations =
				{
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.SpecialSeminars },
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.Seminars },
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.Graduational },
				},
				SubjectTypeRelations =
				{
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanHealth },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanNature },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanSociety },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanWork },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.ArtCulture },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.Informatics },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.MathApplication },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.LanguageCommunication },
				}
			},
		};

		Seed(For(data).PairBy(sr => sr.Name)
			.AfterSave(item =>
			{
				item.SeedEntity.SubjectCategoryRelations.ForEach(cr => cr.SigningRuleId = item.PersistedEntity.Id);
				item.SeedEntity.SubjectTypeRelations.ForEach(tr => tr.SigningRuleId = item.PersistedEntity.Id);
			})
			.AndForAll(sr => sr.SubjectCategoryRelations,
						categoryRelationSeed => categoryRelationSeed.PairBy(cr => cr.SigningRuleId, cr => cr.SubjectCategoryId))
			.AndForAll(sr => sr.SubjectTypeRelations,
						typeRelationSeed => typeRelationSeed.PairBy(tr => tr.SigningRuleId, tr => tr.SubjectTypeId))
		);
	}

	public override IEnumerable<Type> GetPrerequisiteDataSeeds()
	{
		yield return typeof(GradeSeed);
		yield return typeof(SubjectCategorySeed);
		yield return typeof(SubjectTypeSeed);
	}
}
