using Havit.Data.EntityFrameworkCore.Patterns.QueryServices;
using Havit.Extensions.DependencyInjection.Abstractions;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.DataSources;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.DataLayer.Queries;

[Service]
public class SigningRuleListQuery : QueryBase<SigningRuleDto>, ISigningRuleListQuery
{
	private readonly ISigningRuleDataSource SigningRuleDataSource;

	public SigningRuleListQuery(ISigningRuleDataSource SigningRuleDataSource)
	{
		this.SigningRuleDataSource = SigningRuleDataSource;
	}

	public SigningRuleListQueryFilter Filter { get; set; }

	protected override IQueryable<SigningRuleDto> Query()
	{
		return SigningRuleDataSource.Data
			.Select(sr => new SigningRuleDto()
			{
				Id = sr.Id,
				Name = sr.Name,
				GradeId = (GradeEntry)sr.GradeId,
				Quantity = sr.Quantity,
				SubjectCategoryIds = sr.SubjectCategoryRelations.Select(scr => scr.SubjectCategoryId).ToList(),
				SubjectTypeIds = sr.SubjectTypeRelations.Select(str => str.SubjectTypeId).ToList(),
			});
	}

	public async Task<DataFragmentResult<SigningRuleDto>> GetDataFragmentAsync(int startIndex, int? count, CancellationToken cancellationToken = default)
	{
		return new()
		{
			Data = await SelectDataFragmentAsync(startIndex, count, cancellationToken),
			TotalCount = await CountAsync(cancellationToken)
		};
	}
}
