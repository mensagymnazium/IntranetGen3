using MensaGymnazium.IntranetGen3.Model;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core;

public class GradeRegistrationCriteriaSeed : DataSeed<CoreProfile>
{
	public override void SeedData()
	{
		var data = new[]
		{
			new GradeRegistrationCriteria()
			{
				Id = (int)GradeEntry.Prima,
				RequiredTotalAmountOfHoursPerWeekExcludingLanguage = 0,
			},
			new GradeRegistrationCriteria()
			{
				Id = (int)GradeEntry.Sekunda,
				RequiredTotalAmountOfHoursPerWeekExcludingLanguage = 2,
				CanUseForeignLanguageInsteadOfHoursPerWeek = true
			},
			new GradeRegistrationCriteria()
			{
				Id = (int)GradeEntry.Tercie,
				RequiredTotalAmountOfHoursPerWeekExcludingLanguage = 2,
				RequiresForeginLanguage = true,
			},
			new GradeRegistrationCriteria()
			{
				Id = (int)GradeEntry.Kvarta,
				RequiredTotalAmountOfHoursPerWeekExcludingLanguage = 2,
				RequiresForeginLanguage = true,
			},
			new GradeRegistrationCriteria()
			{
				Id = (int)GradeEntry.Kvinta,
				RequiredTotalAmountOfHoursPerWeekExcludingLanguage = 4,
				RequiresForeginLanguage = true,
			},
			new GradeRegistrationCriteria()
			{
				Id = (int)GradeEntry.Sexta,
				RequiredTotalAmountOfHoursPerWeekExcludingLanguage = 4,
				RequiresForeginLanguage = true,
			},
			new GradeRegistrationCriteria()
			{
				Id = (int)GradeEntry.Septima,
				RequiredTotalAmountOfHoursPerWeekExcludingLanguage = 10,
				RequiresCspOrCpValidation = true,
				RequiredAmountOfHoursPerWeekInAreaCspOrCp = 4,
				RequiresForeginLanguage = true,
			},
			new GradeRegistrationCriteria()
			{
				Id = (int)GradeEntry.Oktava,
				RequiredTotalAmountOfHoursPerWeekExcludingLanguage = 12,
				RequiresCspOrCpValidation = true,
				RequiredAmountOfHoursPerWeekInAreaCspOrCp = 4,
				RequiresForeginLanguage = true,
			},
		};

		Seed(For(data).PairBy(grc => grc.Id));
	}
}
