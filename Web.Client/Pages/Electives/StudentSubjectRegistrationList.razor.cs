using Havit.Collections;
using MensaGymnazium.IntranetGen3.Contracts;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Electives;

public partial class StudentSubjectRegistrationList
{
	[Inject] protected Func<IStudentSubjectRegistrationFacade> StudentSubjectRegistrationFacade { get; set; }

	private StudentSubjectRegistrationsGrid gridComponent;
	private StudentSubjectRegistrationListQueryFilter filterModel = new StudentSubjectRegistrationListQueryFilter();

	private async Task<GridDataProviderResult<StudentSubjectRegistrationDto>> GetStudentRegistrations(GridDataProviderRequest<StudentSubjectRegistrationDto> request)
	{
		var response = await StudentSubjectRegistrationFacade().GetStudentSubjectRegistrationListAsync(
			new DataFragmentRequest<StudentSubjectRegistrationListQueryFilter>()
			{
				Filter = filterModel,
				Count = request.Count,
				StartIndex = request.StartIndex,
				Sorting = request.Sorting.Select(s => new SortItem(s.SortString, s.SortDirection)).ToArray()
			});

		return new()
		{
			Data = response.Data,
			TotalCount = response.TotalCount,
		};
	}

	private async Task HandleFilterModelChanged(StudentSubjectRegistrationListQueryFilter newFilterModel)
	{
		filterModel = newFilterModel;
		await gridComponent.RefreshDataAsync();
	}

}
