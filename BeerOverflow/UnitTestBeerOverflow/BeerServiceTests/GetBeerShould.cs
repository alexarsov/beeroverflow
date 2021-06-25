using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Services.Services;
using BeerOverflow.Services.DTOs;
using System.Threading.Tasks;
using System.Diagnostics;
using System;

namespace UnitTestBeerOverflow.BeerServiceTests
{
    [TestClass]
    public class GetBeerShould
    {
        [TestMethod]
        public async Task GetBeerShould_Throw()
        {
            var nameOfDb = new StackTrace().GetFrame(0).GetMethod().Name;

            using (var assertContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                var sut = new BeerService(assertContext);
                _ = await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await sut.GetBeerAsync(Guid.NewGuid()));
            }

        }

        [TestMethod]
        public async Task GetBeerShould_Succeed()
        {
            //Arrange
            var nameOfDb = Guid.NewGuid().ToString();

            var expected = new BeerDTO
            {
                Id = BeerOverflowUtils.KamenitzaId,
                Name = "Kamenitza",
                CountryId = BeerOverflowUtils.BulgariaId,
                CountryName = "Bulgaria",
                StyleId = BeerOverflowUtils.PremiumLightStyleId,
                StyleName = "Premium Light",
                BreweryId = BeerOverflowUtils.KamenitzaADId,
                BreweryName = "KamenitzaAD",
                ABV = 5.2
            };
            using (var arrangeContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }

            using (var assertContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                var sut = new BeerService(assertContext);
                var result = await sut.GetBeerAsync(expected.Id);

                Assert.AreEqual(expected.Id, result.Id);
                Assert.AreEqual(expected.Name, result.Name);
                Assert.AreEqual(expected.CountryId, result.CountryId);
                Assert.AreEqual(expected.CountryName, result.CountryName);
                Assert.AreEqual(expected.StyleId, result.StyleId);
                Assert.AreEqual(expected.StyleName, result.StyleName);
                Assert.AreEqual(expected.BreweryId, result.BreweryId);
                Assert.AreEqual(expected.BreweryName, result.BreweryName);
                Assert.AreEqual(expected.ABV, result.ABV);
            }
        }
    }
}
