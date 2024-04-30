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
				RequiredTotalAmountOfDonatedHoursExcludingLanguage = 0,
			},
			new GradeRegistrationCriteria()
			{
				Id = (int)GradeEntry.Sekunda,
				RequiredTotalAmountOfDonatedHoursExcludingLanguage = 2,
			},
			new GradeRegistrationCriteria()
			{
				Id = (int)GradeEntry.Tercie,
				RequiredTotalAmountOfDonatedHoursExcludingLanguage = 2,
			},
			new GradeRegistrationCriteria()
			{
				Id = (int)GradeEntry.Kvarta,
				RequiredTotalAmountOfDonatedHoursExcludingLanguage = 2,
			},
			new GradeRegistrationCriteria()
			{
				Id = (int)GradeEntry.Kvinta,
				RequiredTotalAmountOfDonatedHoursExcludingLanguage = 4,
			},
			new GradeRegistrationCriteria()
			{
				Id = (int)GradeEntry.Sexta,
				RequiredTotalAmountOfDonatedHoursExcludingLanguage = 4,
			},
			new GradeRegistrationCriteria()
			{
				Id = (int)GradeEntry.Septima,
				RequiredTotalAmountOfDonatedHoursExcludingLanguage = 10,
				RequiresCspOrCpValidation = true,
				RequiredAmountOfDonatedHoursInAreaCspOrCp = 4
			},
			new GradeRegistrationCriteria()
			{
				Id = (int)GradeEntry.Oktava,
				RequiredTotalAmountOfDonatedHoursExcludingLanguage = 12,
				RequiresCspOrCpValidation = true,
				RequiredAmountOfDonatedHoursInAreaCspOrCp = 4
			},
		};

		Seed(For(data).PairBy(grc => grc.Id));
	}
}
