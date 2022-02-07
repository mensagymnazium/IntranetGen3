using Havit.Data.Patterns.DataSeeds;
using MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using MensaGymnazium.IntranetGen3.TestHelpers;

namespace MensaGymnazium.IntranetGen3.IntegrationTests.DataLayer.Seeds
{
#if DEBUG
	[TestClass]
	public class DataSeedingTests : IntegrationTestBase
	{
		protected override bool UseLocalDb => true;
		protected override bool DeleteDbData => true; // default, but to be sure :D

		[TestMethod]
		public void DataSeeds_CoreProfile()
		{
			// arrange
			var seedRunner = ServiceProvider.GetRequiredService<IDataSeedRunner>();

			// act
			seedRunner.SeedData<CoreProfile>();

			// assert
			// no exception
		}
	}
#endif
}
