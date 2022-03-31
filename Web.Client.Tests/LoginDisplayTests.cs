using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MensaGymnazium.IntranetGen3.Web.Client.Shared;

namespace MensaGymnazium.IntranetGen3.Web.Client.Tests;

[TestClass]
public class LoginDisplayTests
{
	[TestMethod]
	public void LoginDisplay_NameToInitials_NameIsNull()
	{
		// Arrange
		string name = null;
		var ld = new LoginDisplay();
		var expected = "?";

		// Act
		var actual = ld.NameToInitials(name);

		// Assert
		Assert.AreEqual(expected, actual);
	}
	[TestMethod]
	public void LoginDisplay_NameToInitials_NameIsEmptyString()
	{
		// Arrange
		string name = string.Empty;
		var ld = new LoginDisplay();
		var expected = "?";

		// Act
		var actual = ld.NameToInitials(name);

		// Assert
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void LoginDisplay_NameToInitials_NameIsOneWord()
	{
		// Arrange
		string name = "Petr";
		var ld = new LoginDisplay();
		var expected = "P";

		// Act
		var actual = ld.NameToInitials(name);

		// Assert
		Assert.AreEqual(expected, actual);

	}

	[TestMethod]
	public void LoginDisplay_NameToInitials_NameIsTwoWords()
	{
		// Arrange
		string name = "Petr Vomáčka";
		var ld = new LoginDisplay();
		var expected = "PV";

		// Act
		var actual = ld.NameToInitials(name);

		// Assert
		Assert.AreEqual(expected, actual);

	}

	[TestMethod]
	public void LoginDisplay_NameToInitials_NameIsThreeWords()
	{
		/// Arrange
		string name = "Petr Jan Vomáčka";
		var ld = new LoginDisplay();
		var expected = "PV";

		// Act
		var actual = ld.NameToInitials(name);

		// Assert
		Assert.AreEqual(expected, actual);

	}

	[TestMethod]
	public void LoginDisplay_NameToInitials_NameIsFourWords()
	{
		// Arrange
		string name = "Petr Jan Vomáčka Procházka";
		var ld = new LoginDisplay();
		var expected = "PP";

		// Act
		var actual = ld.NameToInitials(name);

		// Assert
		Assert.AreEqual(expected, actual);

	}

	[TestMethod]
	public void LoginDisplay_NameToInitials_EmailIsOneWord()
	{
		/// Arrange
		string name = "petr@email.cz";
		var ld = new LoginDisplay();
		var expected = "P";

		// Act
		var actual = ld.NameToInitials(name);

		// Assert
		Assert.AreEqual(expected, actual);

	}

	[TestMethod]
	public void LoginDisplay_NameToInitials_EmailIsTwoWords()
	{
		// Arrange
		string name = "petr.vomacka@email.cz";
		var ld = new LoginDisplay();
		var expected = "PV";

		// Act
		var actual = ld.NameToInitials(name);

		// Assert
		Assert.AreEqual(expected, actual);

	}

	[TestMethod]
	public void LoginDisplay_NameToInitials_EmailIsThreeWords()
	{
		/// Arrange
		string name = "petr.jan.vomacka@email.cz";
		var ld = new LoginDisplay();
		var expected = "PV";

		// Act
		var actual = ld.NameToInitials(name);

		// Assert
		Assert.AreEqual(expected, actual);

	}

	[TestMethod]
	public void LoginDisplay_NameToInitials_EmailIsFourWords()
	{
		/// Arrange
		string name = "op.ravdu.realnej.email@email.cz";
		var ld = new LoginDisplay();
		var expected = "OE";

		// Act
		var actual = ld.NameToInitials(name);

		// Assert
		Assert.AreEqual(expected, actual);

	}

}
