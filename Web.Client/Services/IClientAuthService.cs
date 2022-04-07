using System.Security.Claims;

namespace MensaGymnazium.IntranetGen3.Web.Client.Services;

public interface IClientAuthService
{
	Task<ClaimsPrincipal> GetCurrentClaimsPrincipal();
	Task<int?> GetCurrentStudentGradeIdAsync();
}