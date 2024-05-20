using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Primitives;
using MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

namespace MensaGymnazium.IntranetGen3.Web.Client.Components.Pickers;

public class GradePicker : HxSelectBase<int?, GradeDto>
{
	[Inject] protected IGradesDataStore GradesDataStore { get; set; }

	/// <summary>
	/// Grades that won't appear in the selection
	/// </summary>
	[Parameter]
	public GradeEntry[] ExcludedGrades { get; set; } = Array.Empty<GradeEntry>();

	public GradePicker()
	{
		this.NullTextImpl = "-vyberte-";
		this.ValueSelectorImpl = (c => c.Id);
		this.TextSelectorImpl = (c => c.Name);
		this.SortKeySelectorImpl = (c => -c.Id);
	}

	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();

		this.DataImpl = (await GradesDataStore.GetAllAsync())
			.Where(g => !ExcludedGrades.Contains((GradeEntry)g.Id))
			.ToList();
	}
}
