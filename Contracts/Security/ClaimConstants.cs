﻿namespace MensaGymnazium.IntranetGen3.Contracts.Security;

public static class ClaimConstants
{
	public const string EmailClaimType = "unique_name";
	public const string NameClaimType = "name";
	public const string GroupClaimType = "groups";

	/// <summary>
	/// Název claim pro uložení User.Id
	/// </summary>
	public const string UserIdClaim = "UserId";

	/// <summary>
	/// Název vystavitele claimů, vystavených aplikací.
	/// </summary>
	public const string ApplicationIssuer = "MensaGymnazium.IntranetGen3";
}
