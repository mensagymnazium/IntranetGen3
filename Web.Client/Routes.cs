namespace MensaGymnazium.IntranetGen3.Web.Client;

public static class Routes
{
	public const string Home = "/";

	public static class Electives
	{
		public const string Subjects = "/electives/subjects";
		public const string SubjectDetail = "/electives/subjects/{SubjectId:int}";
		public const string SigningRuleList = "/electives/signingRule";
		public const string StudentSubjectRegistrationList = "/electives/registrations";
		public const string StudentWithSigningRuleList = "/electives/reports/student-signingRule";
		public static string GetSubjectDetail(int subjectId) => $"/electives/subjects/{subjectId}";

	}

	public static class Administration
	{
		public const string Index = "/admin/";
		public const string Teachers = "/admin/teachers";
	}

	public static class UserAdministration
	{
		public const string PageName = "/admin/user/page-name";
	}

	public static class Diagnostics
	{
		public const string Info = "/diag/info";
	}
}
