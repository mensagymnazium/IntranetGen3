using Havit.Data.EntityFrameworkCore.Patterns.QueryServices;
using Havit.Extensions.DependencyInjection.Abstractions;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.DataSources;

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
		// TODO Filter
		// TODO Richer DTO?

		return SigningRuleDataSource.Data
			.Select(s => new SigningRuleDto()
			{
				Id = s.Id,
				Name = s.Name,
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
