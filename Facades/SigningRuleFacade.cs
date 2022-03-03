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


namespace MensaGymnazium.IntranetGen3.Facades
{
	[Service]
	[Authorize]
	public class SigningRuleFacade : ISigningRuleFacade
	{
		private readonly ISigningRuleListQuery SigningRuleListQuery;
		private readonly ISigningRuleRepository SigningRuleRepository;
		private readonly IUnitOfWork unitOfWork;
		private readonly ISigningRuleMapper SigningRuleMapper;

		public SigningRuleFacade(
			ISigningRuleListQuery SigningRuleListQuery,
			ISigningRuleRepository SigningRuleRepository,
			IUnitOfWork unitOfWork,
			ISigningRuleMapper SigningRuleMapper)
		{
			this.SigningRuleListQuery = SigningRuleListQuery;
			this.SigningRuleRepository = SigningRuleRepository;
			this.unitOfWork = unitOfWork;
			this.SigningRuleMapper = SigningRuleMapper;
		}

		public async Task<DataFragmentResult<SigningRuleDto>> GetSigningRuleListAsync(DataFragmentRequest<SigningRuleListQueryFilter> SigningRuleListRequest, CancellationToken cancellationToken = default)
		{
			Contract.Requires<ArgumentNullException>(SigningRuleListRequest is not null, nameof(SigningRuleListRequest));

			SigningRuleListQuery.Filter = SigningRuleListRequest.Filter;
			//SigningRuleListQuery.Sorting = SigningRuleListRequest.Sorting;

			return await SigningRuleListQuery.GetDataFragmentAsync(SigningRuleListRequest.StartIndex, SigningRuleListRequest.Count, cancellationToken);
		}

		public async Task<SigningRuleDto> GetSigningRuleDetailAsync(Dto<int> SigningRuleIdDto, CancellationToken cancellationToken = default)
		{
			Contract.Requires<ArgumentException>(SigningRuleIdDto.Value != default, nameof(SigningRuleIdDto));

			var SigningRule = await SigningRuleRepository.GetObjectAsync(SigningRuleIdDto.Value, cancellationToken);

			return SigningRuleMapper.MapToSigningRuleDto(SigningRule);
		}

		public async Task<Dto<int>> CreateSigningRuleAsync(SigningRuleDto SigningRuleDto, CancellationToken cancellationToken = default)
		{
			Contract.Requires<ArgumentNullException>(SigningRuleDto != null, nameof(SigningRuleDto));
			Contract.Requires<ArgumentException>(SigningRuleDto.SigningRuleId == null, nameof(SigningRuleDto.SigningRuleId));

			var SigningRule = new SigningRule();
			SigningRuleMapper.MapFromSigningRuleDto(SigningRuleDto, SigningRule);

			unitOfWork.AddForInsert(SigningRule);
			await unitOfWork.CommitAsync(cancellationToken);

			return Dto.FromValue(SigningRule.Id);
		}

		public async Task UpdateSigningRuleAsync(SigningRuleDto SigningRuleDto, CancellationToken cancellationToken = default)
		{
			Contract.Requires<ArgumentNullException>(SigningRuleDto != null, nameof(SigningRuleDto));
			Contract.Requires<ArgumentException>(SigningRuleDto.SigningRuleId != null, nameof(SigningRuleDto.SigningRuleId));

			var SigningRule = await SigningRuleRepository.GetObjectAsync(SigningRuleDto.SigningRuleId.Value, cancellationToken);

			SigningRule.Name = SigningRuleDto.Name;

			unitOfWork.AddForUpdate(SigningRule);
			await unitOfWork.CommitAsync(cancellationToken);
		}

		public async Task DeleteSigningRuleAsync(Dto<int> SigningRuleIdDto, CancellationToken cancellationToken = default)
		{
			var SigningRule = SigningRuleRepository.GetObjectAsync(SigningRuleIdDto.Value, cancellationToken);
			unitOfWork.AddForDelete(SigningRule);

			await unitOfWork.CommitAsync(cancellationToken);
		}
	}
}
