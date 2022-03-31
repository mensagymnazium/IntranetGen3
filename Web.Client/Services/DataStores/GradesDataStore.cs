using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Havit.Blazor.Components.Web.Services.DataStores;
using MensaGymnazium.IntranetGen3.Contracts;

namespace MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

public class GradesDataStore : DictionaryStaticDataStore<int, GradeDto>, IGradesDataStore
{
	private readonly IGradeFacade GradeFacade;

	public GradesDataStore(IGradeFacade GradeFacade)
	{
		this.GradeFacade = GradeFacade;
	}

	protected override Func<GradeDto, int> KeySelector => (Grade) => Grade.Id;
	protected override bool ShouldRefresh() => false; // just hit F5 :-D

	protected async override Task<IEnumerable<GradeDto>> LoadDataAsync()
	{
		var dto = await GradeFacade.GetAllGradesAsync();
		return dto ?? new List<GradeDto>();
	}
}
