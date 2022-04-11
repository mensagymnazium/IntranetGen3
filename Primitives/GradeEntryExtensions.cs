namespace MensaGymnazium.IntranetGen3.Primitives;

public static class GradeEntryExtensions
{
	public static GradeEntry? NextGrade(this GradeEntry grade)
	{
		if (grade == GradeEntry.Oktava)
		{
			return null;
		}
		return (grade - 1); // negative values!
	}
}
