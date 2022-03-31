using System.Net.Mail;

namespace MensaGymnazium.IntranetGen3.Services.Mailing;

public interface IMailingService
{
	void Send(MailMessage mailMessage);
}
