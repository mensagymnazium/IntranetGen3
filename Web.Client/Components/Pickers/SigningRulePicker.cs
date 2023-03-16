using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Primitives;
using MensaGymnazium.IntranetGen3.Web.Client.Services;
using MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;

namespace MensaGymnazium.IntranetGen3.Web.Client.Components.Pickers;

public class SigningRulePicker : HxSelectBase<int?, SigningRuleReferenceDto>
{
	[Parameter] public string NullText { get => NullTextImpl; set => NullTextImpl = value; }
	[Parameter] public bool RestrictStudentGrade { get; set; } = false;

	[Inject] protected ISigningRulesDataStore SigningRulesDataStore { get; set; }
	[Inject] protected IClientAuthService ClientAuthService { get; set; }

	public SigningRulePicker()
	{
		this.NullableImpl = true;
		this.NullDataTextImpl = "načítám";
		this.NullTextImpl = "-vyberte-";
		this.ValueSelectorImpl = (c => c.Id);
		this.TextSelectorImpl = (c => c.Name);
		this.AutoSortImpl = false;
	}

	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();

		var data = (await SigningRulesDataStore.GetAllAsync());

		if (RestrictStudentGrade) // not expected to change during component lifecycle
		{
			var gradeId = await ClientAuthService.GetCurrentStudentGradeIdAsync();
			if (gradeId is not null)
			{
				data = data.Where(c => c.GradeId == gradeId.Value);
			}
		}

		DataImpl = data.ToList();
	}
}
