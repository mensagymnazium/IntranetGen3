using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Havit.ComponentModel;

namespace MensaGymnazium.IntranetGen3.Contracts.Security;

[ApiContract]
public interface ITeacherFacade
{
	Task<List<TeacherReferenceDto>> GetAllTeacherReferencesAsync(CancellationToken cancellationToken = default);
}
