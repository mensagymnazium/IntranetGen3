using MensaGymnazium.IntranetGen3.Model;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core;

public class SigningRuleSeed : DataSeed<CoreProfile>
{
	public override void SeedData()
	{
		// MensaForum - logika zápisů na volitelné předměty posouvá o 1 stupeň dopředu, proto jsou pravidla vytvořena s posunem!
		var data = new[]
		{
			new SigningRule() {
				SeedItemIdentifier = "kvarta",
				Name = "kvarta",
				Description = "Mensa fórum",
				GradeId = (int) GradeEntry.Kvarta,
				Quantity = 9,
				SubjectCategoryRelations =
				{
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.GraduationSeminar },
				},
				SubjectTypeRelations =
				{
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.Informatics },
				}
			},
			new SigningRule() {
				SeedItemIdentifier = "kvinta",
				Name = "kvinta",
				Description = "Mensa fórum",
				GradeId = (int) GradeEntry.Kvinta,
				Quantity = 9,
				SubjectCategoryRelations =
				{
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.GraduationSeminar },
				},
				SubjectTypeRelations =
				{
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.Informatics },
				}
			},
			new SigningRule() {
				SeedItemIdentifier = "sexta",
				Name = "sexta",
				Description = "Mensa fórum",
				GradeId = (int) GradeEntry.Sexta,
				Quantity = 9,
				SubjectCategoryRelations =
				{
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.GraduationSeminar },
				},
				SubjectTypeRelations =
				{
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.Informatics },
				}
			},
			new SigningRule() {
				SeedItemIdentifier = "septima",
				Name = "septima",
				Description = "Mensa fórum",
				GradeId = (int) GradeEntry.Septima,
				Quantity = 9,
				SubjectCategoryRelations =
				{
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.GraduationSeminar },
				},
				SubjectTypeRelations =
				{
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.Informatics },
				}
			},
			new SigningRule() {
				SeedItemIdentifier = "oktava",
				Name = "oktáva",
				Description = "Mensa fórum",
				GradeId = (int) GradeEntry.Oktava,
				Quantity = 9,
				SubjectCategoryRelations =
				{
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.GraduationSeminar },
				},
				SubjectTypeRelations =
				{
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.Informatics },
				}
			},
		};

		Seed(For(data).PairBy(sr => sr.SeedItemIdentifier)
			// TODO .WithoutUpdate() + relations
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
