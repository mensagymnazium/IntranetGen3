using MensaGymnazium.IntranetGen3.Model;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core;

public class GradeSeedRegistrationCriteria : DataSeed<CoreProfile>
{
	public override void SeedData()
	{
		var data = new[]
		{
			new GradeRegistrationCriteria() { Id = (int) GradeEntry.Prima},
			new GradeRegistrationCriteria() { Id = (int) GradeEntry.Sekunda},
			new GradeRegistrationCriteria() { Id = (int) GradeEntry.Tercie},
			new GradeRegistrationCriteria() { Id = (int) GradeEntry.Kvarta},
			new GradeRegistrationCriteria() { Id = (int) GradeEntry.Kvinta},
			new GradeRegistrationCriteria() { Id = (int) GradeEntry.Sexta},
			new GradeRegistrationCriteria() { Id = (int) GradeEntry.Septima},
			new GradeRegistrationCriteria() { Id = (int) GradeEntry.Oktava},
		};

		Seed(For(data).PairBy(grade => grade.Id)); // TODO WithoutUpdate nebo bez AadGroupId? 
	}
}
