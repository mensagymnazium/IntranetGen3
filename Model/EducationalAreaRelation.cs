using Havit.Data.EntityFrameworkCore.Attributes;

namespace MensaGymnazium.IntranetGen3.Model;

/// <summary>
/// M:N relation representing Subject.Types
/// </summary>
[Cache]
public class EducationalAreaRelation
{
	public Subject Subject { get; set; }
	public int SubjectId { get; set; }

	public EducationalArea EducationalArea { get; set; }
	public int EducationalAreaId { get; set; }
}
