using Havit.Services.FileStorage;

namespace MensaGymnazium.IntranetGen3.Services.Infrastructure.FileStorages;

public class ApplicationFileStorageService : FileStorageWrappingService<ApplicationFileStorage>, IApplicationFileStorageService
{
	public ApplicationFileStorageService(IFileStorageService<ApplicationFileStorage> fileStorageService) : base(fileStorageService)
	{
	}
}
