using Havit.ComponentModel;

namespace MensaGymnazium.IntranetGen3.Contracts;

[ApiContract]
public interface ISubjectCategoryFacade
{
	Task<List<SubjectCategoryDto>> GetAllSubjectCategoriesAsync(CancellationToken cancellationToken = default);
}
