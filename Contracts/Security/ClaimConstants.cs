namespace MensaGymnazium.IntranetGen3.Contracts.Security;

public static class ClaimConstants
{
	public const string EmailClaimType = "unique_name";
	public const string NameClaimType = "name";
	public const string GroupClaimType = "groups";
	public const string StudentGradeIdClaimType = "StudentGradeId";
	public const string UserIdClaimType = "UserId";

	/// <summary>
	/// Název vystavitele claimů, vystavených aplikací.
	/// </summary>
	public const string ApplicationIssuer = "MensaGymnazium.IntranetGen3";
}
