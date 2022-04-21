using System.Globalization;
using System.Text.RegularExpressions;
using System.Web;
using Havit;
using MensaGymnazium.IntranetGen3.Primitives;
using Microsoft.AspNetCore.Components;

namespace MensaGymnazium.IntranetGen3.Web.Client.Services;

public static class ValueFormatter
{
	/// <summary>
	/// Vrátí řetězec bez mezer, prázdných znaků (whitespace) na začátku, konci i uprostřed
	/// </summary>
	public static string WithoutWhitespaces(this string inputString)
	{
		if (string.IsNullOrWhiteSpace(inputString))
		{
			return string.Empty;
		}
		else
		{
			StringBuilder sb = new StringBuilder(inputString.Length);
			for (int i = 0; i < inputString.Length; i++)
			{
				char c = inputString[i];
				if (!char.IsWhiteSpace(c))
				{
					sb.Append(c);
				}
			}
			return sb.ToString();
		}
	}

	/// <summary>
	/// Vrátí řetězec vhodný pro zobrazení jako tel. číslo tak, že trojice čísel odděluje nedělitelnou mezerou
	/// </summary>
	public static string AsPhone(this string phone)
	{
		if (string.IsNullOrWhiteSpace(phone))
		{
			return string.Empty;
		}

		phone = WithoutWhitespaces(phone);

		if (phone.Length < 3)
		{
			return phone;
		}
		else if (phone.Length <= 6)
		{
			return string.Format("{0}\u00A0{1}", phone.Substring(0, phone.Length - 3), phone.Substring(phone.Length - 3, 3));
		}
		else if (phone.Length < 9)
		{
			return string.Format("{0}\u00A0{1}\u00A0{2}", phone.Substring(0, phone.Length - 6), phone.Substring(phone.Length - 6, 3), phone.Substring(phone.Length - 3, 3));
		}
		else if (phone.Length == 9)
		{
			return string.Format("{0}\u00A0{1}\u00A0{2}", phone.Substring(0, 3), phone.Substring(3, 3), phone.Substring(6, 3));
		}
		else
		{
			return string.Format("{0}\u00A0{1}\u00A0{2}\u00A0{3}", phone.Substring(0, phone.Length - 9), phone.Substring(phone.Length - 9, 3), phone.Substring(phone.Length - 6, 3), phone.Substring(phone.Length - 3, 3));
		}
	}

	public static string AsBirthNumber(this string birthNumber)
	{
		if (string.IsNullOrWhiteSpace(birthNumber))
		{
			return birthNumber;
		}

		if (Regex.IsMatch(birthNumber, @"\d{9,}"))
		{
			return birthNumber.Left(6) + "/" + birthNumber.Substring(6);
		}

		return birthNumber;
	}

	public static string AsEnumValueDescription(this Enum enumValue)
	{
		return EnumExt.GetDescription(enumValue.GetType(), enumValue);
	}

	public static DateTime? GetBirthDateFromBirthNumber(string birthNumber)
	{
		if (string.IsNullOrWhiteSpace(birthNumber))
		{
			return null;
		}
		string inputValue = birthNumber.Trim();
		if (inputValue.Length < 6)
		{
			return null;
		}

		string inputYearString = inputValue.Substring(0, 2);
		string inputMonthString = inputValue.Substring(2, 2);
		string inputDayString = inputValue.Substring(4, 2);

		if (!int.TryParse(inputYearString, out int year))
		{
			return null;
		}
		if (year >= 54)
		{
			year += 1900;
		}
		else
		{
			year += 2000;
		}
		if (year < DateTime.MinValue.Year || year > DateTime.MaxValue.Year)
		{
			return null;
		}

		if (!int.TryParse(inputMonthString, out int month))
		{
			return null;
		}
		if (month > 50)
		{
			month -= 50;
		}
		if (month < 1 || month > 12)
		{
			return null;
		}

		if (!int.TryParse(inputDayString, out int day))
		{
			return null;
		}
		if (day < 0 || day > DateTime.DaysInMonth(year, month))
		{
			return null;
		}

		return new DateTime(year, month, day, 0, 0, 0);
	}

	/// <summary>
	/// Zkontroluje, jestli string má string neprázdnou hodnotu (IsNullOrWhiteSpace) a případně vrátí zadanou výchozí hodnotu.
	/// </summary>
	public static string WithDefaultValue(this string inputString, string defaultValue)
	{
		return string.IsNullOrWhiteSpace(inputString) ? defaultValue : inputString;
	}

	/// <summary>
	/// Vrátí MarkupString pro renderování HTML, kde jsou znaky zalomení řádku nahrazeny za &lt;br /&gt;
	/// </summary>
	public static MarkupString WithNewLinesAsHtmlBreak(this string inputString)
	{
		if (string.IsNullOrWhiteSpace(inputString))
		{
			return (MarkupString)string.Empty;
		}
		else
		{
			return (MarkupString)HttpUtility.HtmlEncode(inputString).Replace(Environment.NewLine, "<br />");
		}
	}

	public static string GetScheduleTimeSlot(DayOfWeek? dayOfWeek, ScheduleSlotInDay? scheduleSlotInDay)
	{
		if (dayOfWeek == null || scheduleSlotInDay == null)
		{
			return string.Empty;
		}

		return string.Format("{0}, {1}", DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName(dayOfWeek.Value), scheduleSlotInDay.Value.AsEnumValueDescription());
	}
}
