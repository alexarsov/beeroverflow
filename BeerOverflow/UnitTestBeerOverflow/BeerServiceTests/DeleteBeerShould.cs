using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Services.Contracts;
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
    public class DeleteBeerShould
    {
        [TestMethod]
        public async Task DeleteBeerShould_Return_True()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var beerDTO = new BeerDTO
            {
                Id = BeerOverflowUtils.KamenitzaId,
                Name = "Kamenitza",
                CountryId = BeerOverflowUtils.BulgariaId, // The same as Bulgaria Country Id
                StyleId = BeerOverflowUtils.PremiumLightStyleId, // The same as Style Id
                BreweryId = BeerOverflowUtils.KamenitzaADId, // The same as Zagorka AD
                ABV = 5.2
            };
            using (var arrangeContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }

            using (var assertContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                var sut = new BeerService(assertContext);

                Assert.IsTrue(await sut.DeleteBeerAsync(beerDTO.Id));
                Assert.IsTrue(assertContext.Beers.First(x=>x.Id == beerDTO.Id).IsDeleted);
            }
        }
        [TestMethod]
        public async Task DeleteBeerShould_Return_True_DeleteExistant()
        {
            var nameOfDb = Guid.NewGuid().ToString(); 
            var beerDTO = new BeerDTO
            {
                Id = BeerOverflowUtils.HeinekenId,
                Name = "Heineken",
                CountryId = BeerOverflowUtils.GermanyId, // The same as Germany Country Id
                StyleId = BeerOverflowUtils.PremiumLightStyleId, // The same as Style Id
                BreweryId = BeerOverflowUtils.HeinekenADId, // The same as Karlsberg
                ABV = 4.8,
            };
            using (var arrangeContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }

            using (var assertContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                var sut = new BeerService(assertContext);

                Assert.IsTrue(await sut.DeleteBeerAsync(beerDTO.Id));
                Assert.IsTrue(assertContext.Beers.First(x => x.Id == beerDTO.Id).IsDeleted);
            }
        }
        [TestMethod]
        public async Task DeleteBeerShould_Return_False_Inexistent()
        {
            var nameOfDb = Guid.NewGuid().ToString();

            using (var assertContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                var sut = new BeerService(assertContext);

                Assert.IsFalse(await sut.DeleteBeerAsync(Guid.NewGuid()));
            }
        }
    }
}
