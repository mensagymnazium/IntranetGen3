using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Havit.Blazor.Components.Web.Bootstrap;
using MensaGymnazium.IntranetGen3.Contracts.Security;
using MensaGymnazium.IntranetGen3.Web.Client.Services.DataStores;
using Microsoft.AspNetCore.Components;

namespace MensaGymnazium.IntranetGen3.Web.Client.Components.Pickers;

public class TeacherPicker : HxSelectBase<int?, TeacherReferenceDto>
{
	[Parameter] public string NullText { get => NullTextImpl; set => NullTextImpl = value; }

	[Inject] protected ITeachersDataStore TeachersDataStore { get; set; }

	public TeacherPicker()
	{
		this.NullableImpl = true;
		this.NullDataTextImpl = "načítám";
		this.NullTextImpl = "-vyberte-";
		this.ValueSelectorImpl = (c => c.TeacherId);
		this.TextSelectorImpl = (c => c.Name);
	}

	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();

		this.DataImpl = (await TeachersDataStore.GetAllAsync()).Where(t => !t.IsDeleted).ToList();
	}
}
