namespace MensaGymnazium.IntranetGen3.DependencyInjection.ConfigrationOptions;

public class FileStorageOptions
{
	public const string FileStorageOptionsKey = "AppSettings:FileStorage";

	public string PathOrContainerName { get; set; }
}
