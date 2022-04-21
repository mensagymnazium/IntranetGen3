using Microsoft.AspNetCore.Components.Rendering;

namespace MensaGymnazium.IntranetGen3.Web.Client.Components;

public class DebugView : ComponentBase
{
	[Parameter] public RenderFragment ChildContent { get; set; }

	protected override void BuildRenderTree(RenderTreeBuilder builder)
	{
#if DEBUG
		builder.AddContent(0, ChildContent);
#endif
	}
}
