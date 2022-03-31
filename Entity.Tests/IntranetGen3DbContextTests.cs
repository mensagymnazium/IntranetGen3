using System;
using MensaGymnazium.IntranetGen3.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MensaGymnazium.IntranetGen3.Entity.Tests;

[TestClass]
public class IntranetGen3DbContextTests
{
	[TestMethod]
	public void IntranetGen3DbContext_CheckModelConventions()
	{
		// Arrange
		DbContextOptions<IntranetGen3DbContext> options = new DbContextOptionsBuilder<IntranetGen3DbContext>()
			.UseInMemoryDatabase(nameof(IntranetGen3DbContext))
			.Options;
		IntranetGen3DbContext dbContext = new IntranetGen3DbContext(options);

		// Act
		Havit.Data.EntityFrameworkCore.ModelValidation.ModelValidator modelValidator = new Havit.Data.EntityFrameworkCore.ModelValidation.ModelValidator();
		string errors = modelValidator.Validate(dbContext);

		// Assert
		if (!String.IsNullOrEmpty(errors))
		{
			Assert.Fail(errors);
		}
	}
}
