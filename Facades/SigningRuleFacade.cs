using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Havit.Data.Patterns.UnitOfWorks;
using Havit.Diagnostics.Contracts;
using Havit.Extensions.DependencyInjection.Abstractions;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.Queries;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories;
using MensaGymnazium.IntranetGen3.Model;
using MensaGymnazium.IntranetGen3.Services;
using Microsoft.AspNetCore.Authorization;


namespace MensaGymnazium.IntranetGen3.Facades;

[Service]
[Authorize]
public class SigningRuleFacade : ISigningRuleFacade
{
	private readonly ISigningRuleListQuery signingRuleListQuery;
	private readonly ISigningRuleRepository signingRuleRepository;
	private readonly IUnitOfWork unitOfWork;
	private readonly ISigningRuleMapper signingRuleMapper;

	public SigningRuleFacade(
		ISigningRuleListQuery SigningRuleListQuery,
		ISigningRuleRepository SigningRuleRepository,
		IUnitOfWork unitOfWork,
		ISigningRuleMapper SigningRuleMapper)
	{
		this.signingRuleListQuery = SigningRuleListQuery;
		this.signingRuleRepository = SigningRuleRepository;
		this.unitOfWork = unitOfWork;
		this.signingRuleMapper = SigningRuleMapper;
	}

	public async Task<DataFragmentResult<SigningRuleDto>> GetSigningRuleListAsync(DataFragmentRequest<SigningRuleListQueryFilter> SigningRuleListRequest, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(SigningRuleListRequest is not null, nameof(SigningRuleListRequest));

		signingRuleListQuery.Filter = SigningRuleListRequest.Filter;
		//SigningRuleListQuery.Sorting = SigningRuleListRequest.Sorting;

		return await signingRuleListQuery.GetDataFragmentAsync(SigningRuleListRequest.StartIndex, SigningRuleListRequest.Count, cancellationToken);
	}

	public async Task<SigningRuleDto> GetSigningRuleDetailAsync(Dto<int> SigningRuleIdDto, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentException>(SigningRuleIdDto.Value != default, nameof(SigningRuleIdDto));

		var SigningRule = await signingRuleRepository.GetObjectAsync(SigningRuleIdDto.Value, cancellationToken);

		return signingRuleMapper.MapToSigningRuleDto(SigningRule);
	}

	public async Task<Dto<int>> CreateSigningRuleAsync(SigningRuleDto SigningRuleDto, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(SigningRuleDto != null, nameof(SigningRuleDto));
		Contract.Requires<ArgumentException>(SigningRuleDto.SigningRuleId == null, nameof(SigningRuleDto.SigningRuleId));

		var SigningRule = new SigningRule();
		signingRuleMapper.MapFromSigningRuleDto(SigningRuleDto, SigningRule);

		unitOfWork.AddForInsert(SigningRule);
		await unitOfWork.CommitAsync(cancellationToken);

		return Dto.FromValue(SigningRule.Id);
	}

	public async Task UpdateSigningRuleAsync(SigningRuleDto SigningRuleDto, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(SigningRuleDto != null, nameof(SigningRuleDto));
		Contract.Requires<ArgumentException>(SigningRuleDto.SigningRuleId != null, nameof(SigningRuleDto.SigningRuleId));

		var SigningRule = await signingRuleRepository.GetObjectAsync(SigningRuleDto.SigningRuleId.Value, cancellationToken);

		SigningRule.Name = SigningRuleDto.Name;

		unitOfWork.AddForUpdate(SigningRule);
		await unitOfWork.CommitAsync(cancellationToken);
	}

	public async Task DeleteSigningRuleAsync(Dto<int> SigningRuleIdDto, CancellationToken cancellationToken = default)
	{
		var SigningRule = signingRuleRepository.GetObjectAsync(SigningRuleIdDto.Value, cancellationToken);
		unitOfWork.AddForDelete(SigningRule);

		await unitOfWork.CommitAsync(cancellationToken);
	}
}
