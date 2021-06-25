using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestBeerOverflow.BeerServiceTests
{
    [TestClass]
    public class UpdateBeerShould
    {
        [TestMethod]
        public async Task UpdateBeerShould_Throw()
        {
            var nameOfDb = Guid.NewGuid().ToString();

            using (var assertContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                var sut = new BeerService(assertContext);
                _ = await Assert.ThrowsExceptionAsync<ArgumentNullException>
                    (async () => await sut.UpdateBeerAsync(Guid.NewGuid(), new BeerDTO()));
            }

        }
        [TestMethod]
        public async Task UpdateBeerShould_Succeed()
        {
            var nameOfDb = Guid.NewGuid().ToString();

            var expected = new BeerDTO
            {
                Id = BeerOverflowUtils.TuborgId,
                CountryId = BeerOverflowUtils.BulgariaId,
                StyleId = BeerOverflowUtils.PremiumLightStyleId,
                BreweryId = BeerOverflowUtils.KamenitzaADId,
                ABV = 5.2
            };
            using (var arrangeContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }

            using (var assertContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                var sut = new BeerService(assertContext);
                await sut.UpdateBeerAsync(expected.Id, expected);
                var result = assertContext.Beers.First(x => x.Id == expected.Id);

                Assert.AreEqual(expected.Id, result.Id);
                Assert.AreEqual(expected.Name, result.Name);
                Assert.AreEqual(expected.CountryId, result.CountryId);
                Assert.AreEqual(expected.StyleId, result.StyleId);
                Assert.AreEqual(expected.BreweryId, result.BreweryId);
                Assert.AreEqual(expected.ABV, result.ABV);
            }
        }
    }
}
