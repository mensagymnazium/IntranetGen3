using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MensaGymnazium.IntranetGen3.Model.Security;

namespace MensaGymnazium.IntranetGen3.Model;

/// <summary>
/// Who teaches the subject - M:N relation.
/// </summary>
public class SubjectTeacherRelation
{
	public Subject Subject { get; set; }
	public int SubjectId { get; set; }

	public Teacher Teacher { get; set; }
	public int TeacherId { get; set; }
}
