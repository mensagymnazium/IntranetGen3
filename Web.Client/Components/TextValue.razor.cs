using Microsoft.AspNetCore.Components;

namespace MensaGymnazium.IntranetGen3.Web.Client.Components;

public partial class TextValue
{
	[Parameter] public string Label { get; set; }
	[Parameter] public RenderFragment LabelTemplate { get; set; }
	[Parameter] public string Value { get; set; }
	[Parameter] public RenderFragment ValueTemplate { get; set; }
}
