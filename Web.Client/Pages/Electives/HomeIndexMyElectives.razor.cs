using Havit.Collections;
using MensaGymnazium.IntranetGen3.Contracts;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Electives;

public partial class HomeIndexMyElectives
{
	[Inject] protected Func<ISubjectRegistrationsManagerFacade> SubjectRegistrationsManagerFacade { get; set; }

	private async Task<GridDataProviderResult<StudentWithSigningRuleListItemDto>> GetStudentWithSigningRuleGridData(GridDataProviderRequest<StudentWithSigningRuleListItemDto> request)
	{
		var facadeRequest = new DataFragmentRequest<StudentWithSigningRuleListQueryFilter>()
		{
			Filter = new() { CurrentStudentOnly = true },
			StartIndex = request.StartIndex,
			Count = request.Count,
			Sorting = request.Sorting?.Select(s => new SortItem(s.SortString, s.SortDirection)).ToArray()
		};

		var signingRuleListResult = await SubjectRegistrationsManagerFacade().GetStudentWithSigningRuleListAsync(facadeRequest, request.CancellationToken);

		return new()
		{
			Data = signingRuleListResult.Data ?? new(),
			TotalCount = signingRuleListResult.TotalCount
		};
	}

}