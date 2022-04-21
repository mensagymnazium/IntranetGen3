namespace MensaGymnazium.IntranetGen3.Primitives;

[Flags]
public enum Role
{
	Unknown = 0,
	Student = 0b_0000_0001,
	Teacher = 0b_0000_0010,
	Administrator = 0b_0000_0100,
}
