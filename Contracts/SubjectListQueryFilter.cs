using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensaGymnazium.IntranetGen3.Contracts;

public record SubjectListQueryFilter
{
	public string Name { get; set; }
	public int? SubjectTypeId { get; set; }
	public int? SubjectCategoryId { get; set; }
	public int? TeacherId { get; set; }
}
