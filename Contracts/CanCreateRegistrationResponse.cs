namespace MensaGymnazium.IntranetGen3.Contracts;

public record CanCreateRegistrationResponse
{
	public bool IsRegistrationPossible { get; set; }
	public string Reason { get; set; }

	public static CanCreateRegistrationResponse NotPossible(string reason)
	{
		return new CanCreateRegistrationResponse
		{
			IsRegistrationPossible = false,
			Reason = reason
		};
	}

	public static CanCreateRegistrationResponse YesPossible()
	{
		return new CanCreateRegistrationResponse
		{
			IsRegistrationPossible = true,
			Reason = string.Empty
		};
	}
}