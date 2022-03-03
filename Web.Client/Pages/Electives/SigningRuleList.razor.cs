using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Havit.Blazor.Components.Web.Bootstrap;
using Havit.Blazor.Components.Web;
using MensaGymnazium.IntranetGen3.Contracts;
using Microsoft.AspNetCore.Components;
using Havit.Collections;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Electives
{
	public partial class SigningRuleList
	{
		[Inject] protected IHxMessengerService Messenger { get; set; }
		[Inject] protected ISigningRuleFacade SigningRuleFacade { get; set; }
		[Inject] protected NavigationManager NavigationManager { get; set; }

		private SigningRuleListQueryFilter signingRuleListFilter = new SigningRuleListQueryFilter();
		private HxGrid<SigningRuleDto> gridComponent;

		private async Task<GridDataProviderResult<SigningRuleDto>> LoadSigningRules(GridDataProviderRequest<SigningRuleDto> request)
		{
			var SigningRuleRequest = new DataFragmentRequest<SigningRuleListQueryFilter>()
			{
				Filter = signingRuleListFilter,
				StartIndex = request.StartIndex,
				Count = request.Count,
				Sorting = request.Sorting?.Select(s => new SortItem(s.SortString, s.SortDirection)).ToArray()
			};

			var signingRuleListResult = await SigningRuleFacade.GetSigningRuleListAsync(SigningRuleRequest, request.CancellationToken);

			return new()
			{
				Data = signingRuleListResult.Data ?? new(),
				TotalCount = signingRuleListResult.TotalCount
			};
		}
	}
}
