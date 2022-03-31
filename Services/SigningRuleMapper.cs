using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Model;

namespace MensaGymnazium.IntranetGen3.Services;

[Service]
public class SigningRuleMapper : ISigningRuleMapper
{
	public SigningRuleDto MapToSigningRuleDto(SigningRule signingRule)
	{
		Contract.Requires(signingRule != null);

		return new SigningRuleDto
		{
			SigningRuleId = signingRule.Id,
			Name = signingRule.Name,
			Quantity = signingRule.Quantity,
			GradeId = signingRule.GradeId,
			SubjectTypeIds = new List<int>(signingRule.SubjectTypes.Select(x => x.Id)),
			SubjectCategoryIds = new List<int>(signingRule.SubjectCategories.Select(x => x.Id))
		};
	}

	public void MapFromSigningRuleDto(SigningRuleDto signingRuleDto, SigningRule signingRule)
	{
		Contract.Requires<ArgumentNullException>(signingRuleDto is not null);
		Contract.Requires<ArgumentNullException>(signingRule is not null);

		signingRule.Name = signingRuleDto.Name;
		signingRule.Quantity = signingRuleDto.Quantity;
		signingRule.GradeId = signingRuleDto.GradeId;

		// TODO
		// SubjectCategories, SubjectTypes

	}
}
