using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Havit.Extensions.DependencyInjection.Abstractions;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Contracts.Crm;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories.Crm;
using Microsoft.AspNetCore.Authorization;

namespace MensaGymnazium.IntranetGen3.Facades.Crm
{
	[Service]
	[Authorize] // TODO Fine-tune authorization
	public class ContactFacade : IContactFacade
	{
		private readonly IContactRepository contactRepository;

		public ContactFacade(IContactRepository contactRepository)
		{
			this.contactRepository = contactRepository;
		}

		public async Task<Dto<List<ContactReferenceVM>>> GetAllContactReferencesAsync(CancellationToken cancellationToken = default)
		{
			return Dto.FromValue(await contactRepository.GetAllContactReferencesAsync(cancellationToken));
		}
	}
}
