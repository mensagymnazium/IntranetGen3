using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Havit.Services.FileStorage;

namespace MensaGymnazium.IntranetGen3.Services.Infrastructure.FileStorages;

public class ApplicationFileStorageService : FileStorageWrappingService<ApplicationFileStorage>, IApplicationFileStorageService
{
	public ApplicationFileStorageService(IFileStorageService<ApplicationFileStorage> fileStorageService) : base(fileStorageService)
	{
	}
}
