using System.Security.Claims;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Web.Client.Services;

public interface IClientAuthService
{
	Task<ClaimsPrincipal> GetCurrentClaimsPrincipalAsync();
	Task<GradeEntry?> GetCurrentStudentGradeIdAsync();
	Task<int?> GetCurrentUserIdAsync();
}