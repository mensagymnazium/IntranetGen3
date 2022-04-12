using MensaGymnazium.IntranetGen3.Model;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core;

public class SigningRuleSeed : DataSeed<CoreProfile>
{
	public override void SeedData()
	{
		var data = new[]
		{
			new SigningRule() {
				SeedItemIdentifier = "Sekunda",
				Name = "sekunda - specializační seminář nebo jazyk",
				Description = "Je potřeba si zvolit jeden specializační seminář nebo jazyk.",
				GradeId = (int) GradeEntry.Sekunda,
				Quantity = 1,
				SubjectCategoryRelations =
				{
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.SpecialisationSeminar },
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
				SeedItemIdentifier = "TercieSpecSem",
				Name = "tercie - specializační seminář",
				Description = "Je potřeba si zvolit jeden specializační seminář.",
				GradeId = (int) GradeEntry.Tercie,
				Quantity = 1,
				SubjectCategoryRelations =
				{
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.SpecialisationSeminar },
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
				SeedItemIdentifier = "TercieJazyk",
				Name = "tercie - jazyk",
				Description = "Je potřeba si zvolit jeden jazyk (pokud již nebyl zvolen v sekundě).",
				GradeId = (int) GradeEntry.Tercie,
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
				SeedItemIdentifier = "KvartaSpecSem",
				Name = "kvarta - specializační seminář",
				Description = "Je potřeba si zvolit jeden specializační seminář.",
				GradeId = (int) GradeEntry.Kvarta,
				Quantity = 1,
				SubjectCategoryRelations =
				{
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.SpecialisationSeminar },
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
				SeedItemIdentifier = "KvintaExtSem",
				Name = "kvinta - nadstavbový seminář",
				Description = "Je potřeba si zvolit jeden nadstavbový seminář.",
				GradeId = (int) GradeEntry.Kvinta,
				Quantity = 1,
				SubjectCategoryRelations =
				{
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.ExtensionSeminar },
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
				SeedItemIdentifier = "KvintaSpecExtSem",
				Name = "kvinta - specializační/nadstavbový seminář",
				Description = "Je potřeba si zvolit jeden specializační nebo nadstavbový seminář.",
				GradeId = (int) GradeEntry.Kvinta,
				Quantity = 1,
				SubjectCategoryRelations =
				{
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.SpecialisationSeminar },
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.ExtensionSeminar },
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
				SeedItemIdentifier = "SextaExtSem",
				Name = "sexta - nadstavbový seminář",
				Description = "Je potřeba si zvolit jeden nadstavbový seminář.",
				GradeId = (int) GradeEntry.Sexta,
				Quantity = 1,
				SubjectCategoryRelations =
				{
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.ExtensionSeminar },
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
				SeedItemIdentifier = "SextaSpecExtSem",
				Name = "sexta - specializační/nadstavbový seminář",
				Description = "Je potřeba si zvolit jeden specializační nebo nadstavbový seminář.",
				GradeId = (int) GradeEntry.Sexta,
				Quantity = 1,
				SubjectCategoryRelations =
				{
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.SpecialisationSeminar },
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.ExtensionSeminar },
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
				SeedItemIdentifier = "SeptimaGradSem",
				Name = "septima - dva maturitní semináře",
				Description = "Je potřeba si zvolit dva maturitní semináře z oblastí Člověk a společnost nebo Člověk a příroda.",
				GradeId = (int) GradeEntry.Septima,
				Quantity = 2,
				SubjectCategoryRelations =
				{
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.GraduationSeminar },
				},
				SubjectTypeRelations =
				{
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanSociety },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanWork },
				},
			},
			new SigningRule()
			{
				SeedItemIdentifier = "SeptimaOther",
				Name = "septima - další tři semináře",
				Description = "Je potřeba si zvolit další tři specializační/nadstavbonvé/maturitní semináře.",
				GradeId = (int) GradeEntry.Septima,
				Quantity = 3,
				SubjectCategoryRelations =
				{
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.SpecialisationSeminar },
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.ExtensionSeminar },
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.GraduationSeminar },
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
				SeedItemIdentifier = "OktavaGradSem",
				Name = "oktáva - dva maturitní semináře",
				Description = "Je potřeba si zvolit dva maturitní semináře z oblastí Člověk a společnost nebo Člověk a příroda.",
				GradeId = (int) GradeEntry.Oktava,
				Quantity = 2,
				SubjectCategoryRelations =
				{
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.GraduationSeminar },
				},
				SubjectTypeRelations =
				{
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanSociety },
					new SigningRuleSubjectTypeRelation() { SubjectTypeId = (int)SubjectType.Entry.HumanWork },
				},
			},
			new SigningRule()
			{
				SeedItemIdentifier = "OktavaOther",
				Name = "oktáva - další čtyři semináře",
				Description = "Je potřeba si zvolit další čtyři specializační/nadstavbonvé/maturitní semináře.",
				GradeId = (int) GradeEntry.Oktava,
				Quantity = 4,
				SubjectCategoryRelations =
				{
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.SpecialisationSeminar },
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.ExtensionSeminar },
					new SigningRuleSubjectCategoryRelation() { SubjectCategoryId = (int)SubjectCategory.Entry.GraduationSeminar },
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
