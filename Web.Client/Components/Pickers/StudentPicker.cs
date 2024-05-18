using Havit.Text.RegularExpressions;
using MensaGymnazium.IntranetGen3.Contracts.Security;
using MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;
using Microsoft.AspNetCore.Components;

namespace MensaGymnazium.IntranetGen3.Web.Client.Components.Pickers;

public class StudentPicker : HxAutosuggest<StudentReferenceDto, int?>
{
	[Inject] protected IStudentsDataStore StudentsDataStore { get; set; }

	public StudentPicker()
	{
		this.DataProvider = GetSuggestionsAsync;
		this.ItemFromValueResolver = ResolveItemFromIdAsync;
		this.ValueSelector = (c => c.Id);
		this.TextSelector = (c => c.Name);
	}

	private async Task<AutosuggestDataProviderResult<StudentReferenceDto>> GetSuggestionsAsync(AutosuggestDataProviderRequest request)
	{
		var data = await StudentsDataStore.GetAllAsync();
		return new AutosuggestDataProviderResult<StudentReferenceDto>()
		{
			Data = data
				.Where(c => !c.IsDeleted)
				.Where(c => RegexPatterns.IsWildcardMatch("*" + request.UserInput + "*", c.Name))
				.OrderBy(c => c.Name.StartsWith(request.UserInput, StringComparison.OrdinalIgnoreCase) ? 0 : 1)
				.ThenBy(c => c.Name)
				.Take(5)
				.ToList(),
		};
	}

	private async Task<StudentReferenceDto> ResolveItemFromIdAsync(int? id)
	{
		if (id == null)
		{
			return null;
		}

		return await StudentsDataStore.GetByKeyAsync(id.Value);
	}
}
