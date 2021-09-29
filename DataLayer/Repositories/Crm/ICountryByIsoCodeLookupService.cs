using MensaGymnazium.IntranetGen3.Model.Crm;

namespace MensaGymnazium.IntranetGen3.DataLayer.Repositories.Crm
{
	public interface ICountryByIsoCodeLookupService
	{
		Country GetCountryByIsoCode(string isoCode);
	}
}