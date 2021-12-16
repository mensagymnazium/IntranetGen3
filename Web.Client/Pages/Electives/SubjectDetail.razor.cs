using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Electives
{
	public partial class SubjectDetail
	{
		[Parameter] public int? SubjectId { get; set; }

		private SubjectEdit subjectEditComponent;

		private async Task HandleEditClick()
		{
			await subjectEditComponent.ShowAsync();
		}
	}
}
