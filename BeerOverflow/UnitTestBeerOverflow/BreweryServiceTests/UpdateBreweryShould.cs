using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Services.Services;
using BeerOverflow.Services.Services.Main_Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UnitTestBeerOverflow;

namespace BeerOverflow.UnitTests.BreweryServiceTests
{
    [TestClass]
    public class UpdateBreweryShould
    {
        [TestMethod]
        public async Task UpdateBreweryShould_Throw()
        {
            var nameOfDb = new StackTrace().GetFrame(0).GetMethod().Name;
            using (var assertContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                var sut = new BreweryService(assertContext, new BeerService(assertContext));
                await Assert.ThrowsExceptionAsync<ArgumentNullException>
                    (async () => await sut.UpdateBreweryAsync(Guid.NewGuid(), new BreweryDTO()));
            }
        }
        [TestMethod]
        public async Task UpdateBreweryShould_SucceedAsync()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var expected = new BreweryDTO
            {
                Id = BeerOverflowUtils.KamenitzaADId, // Unique Id
                Name = "KamenitzaAD",
                CountryId = BeerOverflowUtils.BulgariaId, // the same as Bulgaria Id
                CountryName = "Bulgaria", // the same as Bulgaria Id
            };

            using (var arrangeContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }

            using (var assertContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                var sut = new BreweryService(assertContext, new BeerService(assertContext));
                await sut.UpdateBreweryAsync(expected.Id, expected);
                var result = assertContext.Breweries.First(x => x.Id == expected.Id);

                Assert.AreEqual(expected.Id, result.Id);
                Assert.AreEqual(expected.Name, result.Name);
                Assert.AreEqual(expected.CountryId, result.CountryId);
            }
        }
    }
}