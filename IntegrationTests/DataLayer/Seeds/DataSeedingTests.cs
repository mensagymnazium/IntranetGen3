using Havit.Data.Patterns.DataSeeds;
using MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using MensaGymnazium.IntranetGen3.TestHelpers;
using MensaGymnazium.IntranetGen3.DataLayer.Seeds.Demo;

namespace MensaGymnazium.IntranetGen3.IntegrationTests.DataLayer.Seeds
{
#if DEBUG
	[TestClass]
	public class DataSeedingTests : IntegrationTestBase
	{
		protected override bool UseLocalDb => true;
		protected override bool DeleteDbData => true; // default, but to be sure :D
		protected override bool SeedData => false;

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

		[TestMethod]
		public void DataSeeds_DemoProfile()
		{
			// arrange
			var seedRunner = ServiceProvider.GetRequiredService<IDataSeedRunner>();

			// act
			seedRunner.SeedData<DemoProfile>();

			// assert
			// no exception
		}
	}
#endif
}
