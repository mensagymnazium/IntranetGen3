using System.Security.Claims;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Web.Client.Services;

public interface IClientAuthService
{
	Task<ClaimsPrincipal> GetCurrentClaimsPrincipal();
	Task<GradeEntry?> GetCurrentStudentGradeIdAsync();
	Task<int?> GetCurrentUserIdAsync();
}