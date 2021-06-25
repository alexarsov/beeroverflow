using BeerOverflow.Services.Services.Main_Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Services.DTOs;
using UnitTestBeerOverflow;
using System;
using BeerOverflow.Services.Services;
using System.Threading.Tasks;
using System.Linq;

namespace BeerOverflow.UnitTests.BreweryServiceTests
{
    [TestClass]
    public class DeleteBreweryShould
    {
        [TestMethod]
        public async Task Delete_Brewery_Succeed_With_TrueAsync()
        {
            var breweryDTO = new BreweryDTO
            {
                Id = BeerOverflowUtils.TuborgADId, // Unique Id
                Name = "TuborgAD",
                CountryId = BeerOverflowUtils.GermanyId // The same as Germany Id
            };

            var beerDTO = new BeerDTO
            {
                Id = BeerOverflowUtils.TuborgId,
                Name = "Tuborg",
                CountryId = BeerOverflowUtils.GermanyId, // The same as Germany Country Id
                StyleId = BeerOverflowUtils.PremiumLightStyleId, // The same as Style Id
                BreweryId = BeerOverflowUtils.TuborgADId, // The same as Karlsberg
                ABV = 4.8,
            };

            using (var arrangeContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameof(Delete_Brewery_Succeed_With_TrueAsync))))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }

            using (var assertContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameof(Delete_Brewery_Succeed_With_TrueAsync))))
            {
                var sut = new BreweryService(assertContext, new BeerService(assertContext));
                var result = await sut.DeleteBreweryAsync(breweryDTO.Id);

                Assert.IsTrue(result);
                Assert.IsTrue(assertContext.Beers.First(x => x.Id == beerDTO.Id).IsDeleted);

            }
        }

        [TestMethod]
        public async Task Delete_Brewery_Succeed_With_FalseAsync()
        {

            using (var assertContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameof(Delete_Brewery_Succeed_With_FalseAsync))))

            {
                var sut = new BreweryService(assertContext, new BeerService(assertContext));
                var result = await sut.DeleteBreweryAsync(Guid.NewGuid());

                Assert.IsFalse(result);
            }
        }
    }
}
