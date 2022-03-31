using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Havit.Blazor.Components.Web.Services.DataStores;
using MensaGymnazium.IntranetGen3.Contracts;

namespace MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

public class SubjectCategoriesDataStore : DictionaryStaticDataStore<int, SubjectCategoryDto>, ISubjectCategoriesDataStore
{
	private readonly ISubjectCategoryFacade SubjectCategoryFacade;

	public SubjectCategoriesDataStore(ISubjectCategoryFacade SubjectCategoryFacade)
	{
		this.SubjectCategoryFacade = SubjectCategoryFacade;
	}

	protected override Func<SubjectCategoryDto, int> KeySelector => (SubjectCategory) => SubjectCategory.Id;
	protected override bool ShouldRefresh() => false; // just hit F5 :-D

	protected async override Task<IEnumerable<SubjectCategoryDto>> LoadDataAsync()
	{
		var dto = await SubjectCategoryFacade.GetAllSubjectCategoriesAsync();
		return dto ?? new List<SubjectCategoryDto>();
	}
}
