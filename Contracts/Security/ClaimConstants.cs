namespace MensaGymnazium.IntranetGen3.Contracts.Infrastructure.Security;

public static class ClaimConstants
{
	/// <summary>
	/// Název claim pro uložení User.Id
	/// </summary>
	public const string UserIdClaim = "UserId";

	/// <summary>
	/// Název vystavitele claimů, vystavených aplikací.
	/// </summary>
	public const string ApplicationIssuer = "MensaGymnazium.IntranetGen3";
}
