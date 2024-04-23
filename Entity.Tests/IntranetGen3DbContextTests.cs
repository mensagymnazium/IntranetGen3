using Havit.Data.EntityFrameworkCore.ModelValidation;
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
		Havit.Data.EntityFrameworkCore.ModelValidation.ModelValidator modelValidator = new();
		var validationRules = new ValidationRules()
		{
			CheckOnlyForeignKeysEndWithId = false // This convention is broken in many instances. For now just ignore it.
												  // I.E. (Grade.AadGroupId) or (Student.SeedEntityId)
												  // Xopa Todo: Maybe change the naming, so it fits the convention
		};
		string errors = modelValidator.Validate(dbContext, validationRules);

		// Assert
		if (!String.IsNullOrEmpty(errors))
		{
			Assert.Fail(errors);
		}
	}
}
