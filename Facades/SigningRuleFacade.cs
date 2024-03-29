﻿using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.Queries;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories;
using MensaGymnazium.IntranetGen3.Model;
using MensaGymnazium.IntranetGen3.Primitives;
using MensaGymnazium.IntranetGen3.Services;


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
		Contract.Requires<ArgumentNullException>(SigningRuleListRequest is not null);

		signingRuleListQuery.Filter = SigningRuleListRequest.Filter;
		//SigningRuleListQuery.Sorting = SigningRuleListRequest.Sorting;

		return await signingRuleListQuery.GetDataFragmentAsync(SigningRuleListRequest.StartIndex, SigningRuleListRequest.Count, cancellationToken);
	}

	public async Task<SigningRuleDto> GetSigningRuleDetailAsync(Dto<int> SigningRuleIdDto, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentException>(SigningRuleIdDto.Value != default);

		var SigningRule = await signingRuleRepository.GetObjectAsync(SigningRuleIdDto.Value, cancellationToken);

		return signingRuleMapper.MapToSigningRuleDto(SigningRule);
	}

	[Authorize(Roles = nameof(Role.Administrator))]
	public async Task<Dto<int>> CreateSigningRuleAsync(SigningRuleDto SigningRuleDto, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(SigningRuleDto != null);
		Contract.Requires<ArgumentException>(SigningRuleDto.Id == default);

		var SigningRule = new SigningRule();
		signingRuleMapper.MapFromSigningRuleDto(SigningRuleDto, SigningRule);

		unitOfWork.AddForInsert(SigningRule);
		await unitOfWork.CommitAsync(cancellationToken);

		return Dto.FromValue(SigningRule.Id);
	}

	[Authorize(Roles = nameof(Role.Administrator))]
	public async Task UpdateSigningRuleAsync(SigningRuleDto SigningRuleDto, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(SigningRuleDto != null);
		Contract.Requires<ArgumentException>(SigningRuleDto.Id != default);

		var SigningRule = await signingRuleRepository.GetObjectAsync(SigningRuleDto.Id, cancellationToken);

		SigningRule.Name = SigningRuleDto.Name;

		unitOfWork.AddForUpdate(SigningRule);
		await unitOfWork.CommitAsync(cancellationToken);
	}

	[Authorize(Roles = nameof(Role.Administrator))]
	public async Task DeleteSigningRuleAsync(Dto<int> SigningRuleIdDto, CancellationToken cancellationToken = default)
	{
		var SigningRule = signingRuleRepository.GetObjectAsync(SigningRuleIdDto.Value, cancellationToken);
		unitOfWork.AddForDelete(SigningRule);

		await unitOfWork.CommitAsync(cancellationToken);
	}

	public async Task<List<SigningRuleReferenceDto>> GetAllSigningRuleReferencesAsync(CancellationToken cancellationToken = default)
	{
		return (await signingRuleRepository.GetAllAsync(cancellationToken))
			.Select(sr => new SigningRuleReferenceDto()
			{
				Id = sr.Id,
				Name = sr.Name,
				GradeId = (GradeEntry)sr.GradeId
			})
			.ToList();
	}
}
