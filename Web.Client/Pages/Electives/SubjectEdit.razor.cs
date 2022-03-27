using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Havit;
using Havit.Blazor.Components.Web.Bootstrap;
using MensaGymnazium.IntranetGen3.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Electives
{
	public partial class SubjectEdit
	{
		[Parameter] public int? SubjectId { get; set; }
		[Parameter] public EventCallback OnClosed { get; set; }

		[Inject] protected ISubjectFacade SubjectFacade { get; set; }

		private HxOffcanvas offcanvasComponent;
		private SubjectDto model = new();
		private EditContext editContext;

		protected override async Task OnParametersSetAsync()
		{
			if (SubjectId is null)
			{
				model = new();
				editContext = new EditContext(model);
			}
			else if (SubjectId != model.SubjectId)
			{
				model = await SubjectFacade.GetSubjectDetailAsync(Dto.FromValue(SubjectId.Value));
				editContext = new EditContext(model);
			}
		}

		public async Task ShowAsync()
		{
			await offcanvasComponent.ShowAsync();
		}

		public async Task HandleValidSubmit()
		{
			try
			{
				if (model.SubjectId == default)
				{
					model.SubjectId = (await SubjectFacade.CreateSubjectAsync(model)).Value;
				}
				else
				{
					await SubjectFacade.UpdateSubjectAsync(model);
				}

				await offcanvasComponent.HideAsync();
			}
			catch (OperationFailedException)
			{
				// NOOP - The user should be able to fix the issues and repeat the action
			}
		}
	}
}
