using Havit.Data.EntityFrameworkCore.Attributes;

namespace MensaGymnazium.IntranetGen3.Model;

/// <summary>
/// M:N relation representing Subject.Types
/// </summary>
[Cache]
public class SubjectTypeRelation
{
	public Subject Subject { get; set; }
	public int SubjectId { get; set; }

	public SubjectType SubjectType { get; set; }
	public int SubjectTypeId { get; set; }
}
