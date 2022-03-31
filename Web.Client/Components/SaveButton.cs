using System;
using System.Threading.Tasks;
using Havit.Blazor.Components.Web.Bootstrap;
using Microsoft.AspNetCore.Components;

namespace MensaGymnazium.IntranetGen3.Web.Client.Components;

public class SaveButton : HxButton
{
	[Parameter] public bool IsNew { get; set; }

	public override async Task SetParametersAsync(ParameterView parameters)
	{
		await base.SetParametersAsync(parameters);

		this.Text = parameters.GetValueOrDefault<string>(nameof(Text), this.IsNew ? "Vytvořit" : "Uložit");
		this.Color = parameters.GetValueOrDefault(nameof(Color), ThemeColor.Primary);
	}
}
