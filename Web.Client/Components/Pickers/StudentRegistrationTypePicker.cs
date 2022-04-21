using Havit;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Web.Client.Components.Pickers;

public class StudentRegistrationTypePicker : HxSelectBase<StudentRegistrationType?, StudentRegistrationType>
{
	[Parameter] public string NullText { get => NullTextImpl; set => NullTextImpl = value; }

	public StudentRegistrationTypePicker()
	{
		this.NullableImpl = true;
		this.NullDataTextImpl = "načítám";
		this.NullTextImpl = "-vyberte-";
		this.ValueSelectorImpl = (i => i);
		this.TextSelectorImpl = (i => EnumExt.GetDescription(typeof(StudentRegistrationType), i));
		this.AutoSortImpl = false;
		this.DataImpl = Enum.GetValues<StudentRegistrationType>();
	}
}
