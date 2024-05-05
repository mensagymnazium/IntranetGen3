namespace MensaGymnazium.IntranetGen3.Web.Client.Pages.Electives;

public partial class ElectiveProgressComponent
{
	[Parameter] public bool MeetsCriteria { get; set; }
	/// <summary>
	/// Set to true if the entire registration is valid.
	/// This one component will gray itself out to show that it was not used
	/// if <see cref="MeetsCriteria"/> is <see langword="false"/> and this is <see langword="true"/>.
	/// </summary>
	[Parameter] public bool CompleteRegistrationIsValid { get; set; }
	[Parameter] public string CriteriaProgress { get; set; }
	[Parameter] public string CriteriaDescription { get; set; }
	[Parameter] public string CriteriaName { get; set; }
}