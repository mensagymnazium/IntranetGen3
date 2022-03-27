using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;
using Microsoft.AspNetCore.Components;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Electives
{
	public partial class SubjectDetail
	{
		[Parameter] public int? SubjectId { get; set; }

		[Inject] protected ISubjectFacade SubjectFacade { get; set; }
		[Inject] protected ISubjectCategoriesDataStore SubjectCategoriesDataStore { get; set; }
		[Inject] protected ISubjectTypesDataStore SubjectTypesDataStore { get; set; }
		[Inject] protected ITeachersDataStore TeachersDataStore { get; set; }

		private SubjectDto subject;
		private SubjectEdit subjectEditComponent;
		private int? loadedSubjectId;

		protected override async Task OnInitializedAsync()
		{
			await SubjectCategoriesDataStore.EnsureDataAsync();
			await SubjectTypesDataStore.EnsureDataAsync();
			await TeachersDataStore.EnsureDataAsync();
		}

		protected override async Task OnParametersSetAsync()
		{
			if (SubjectId != loadedSubjectId)
			{
				if (SubjectId.HasValue)
				{
					loadedSubjectId = SubjectId;
					subject = await SubjectFacade.GetSubjectDetailAsync(Dto.FromValue(SubjectId.Value));
				}
				else
				{
					loadedSubjectId = null;
				}
			}
		}

		private async Task HandleEditClick()
		{
			await subjectEditComponent.ShowAsync();
		}

		private string GetSubjectTypes(List<int> subjectTypesIds)
		{
			return String.Join(", ", subjectTypesIds.Select(id => SubjectTypesDataStore.GetByKey(id)?.Name))
				.Trim(',', ' ');
		}

		private string GetTeachers(List<int> teacherIds)
		{
			return String.Join(", ", teacherIds.Select(id => TeachersDataStore.GetByKey(id)?.Name))
				.Trim(',', ' ');
		}

	}
}
