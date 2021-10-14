using System.Threading.Tasks;

namespace MensaGymnazium.IntranetGen3.Web.Client.Shared
{
	public partial class LoginDisplay
	{
		private async Task BeginSignOut()
		{
			await SignOutManager.SetSignOutState();
			Navigation.NavigateTo("authentication/logout");
		}

		/// <summary>
		/// Takes an email or name of the user and returns the user's initials.
		/// </summary>
		/// <returns>The initials of first and last name.</returns>
		private string NameToInitials(string name)
		{
			if (name is null)
			{
				return "?";
			}

			if (name.Contains('@'))
			{
				var mail = name.Split('@')[0].Split('.');
				return mail.Length == 1 ? mail[0][0].ToString().ToUpper() : (mail[0][0].ToString() + mail[^1][0].ToString()).ToUpper();
			}
			var names = name.Split(' ');
			return names.Length == 1 ? names[0][0].ToString().ToUpper() : (names[0][0].ToString() + names[^1][0].ToString()).ToUpper();
		}
	}
}
