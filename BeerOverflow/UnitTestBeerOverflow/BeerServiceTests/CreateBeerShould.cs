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
    public class CreateBeerShould
    {
        [TestMethod]
        public async Task CreateBeer_Should_Succeed_NewBeer()
        {
            //arrange
            var nameOfDb = Guid.NewGuid().ToString();
            var expected = new BeerDTO
            {
                Id = BeerOverflowUtils.TuborgId,
                CountryId = BeerOverflowUtils.GermanyId,
                StyleId = BeerOverflowUtils.PremiumLightStyleId,
                BreweryId = BeerOverflowUtils.TuborgADId,
                ABV = 4.8,
            };
            using (var assertContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                var sut = new BeerService(assertContext);
                await sut.CreateBeerAsync(expected);
                var result = assertContext.Beers.First(x => x.Id == expected.Id);

                Assert.AreEqual(expected.Name, result.Name);
                Assert.AreEqual(expected.CountryId, result.CountryId);
                Assert.AreEqual(expected.StyleId, result.StyleId);
                Assert.AreEqual(expected.BreweryId, result.BreweryId);
                Assert.AreEqual(expected.ABV, result.ABV);
            }
        }
        [TestMethod]
        public async Task CreateBeer_Should_Succeed_DeletedBeer()
        {
            //arrange
            var nameOfDb = Guid.NewGuid().ToString();
            var expected = new BeerDTO
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
                await sut.CreateBeerAsync(expected);
                var result = assertContext.Beers.First(x => x.Id == expected.Id);

                Assert.AreEqual(expected.Name, result.Name);
                Assert.AreEqual(expected.CountryId, result.CountryId);
                Assert.AreEqual(expected.StyleId, result.StyleId);
                Assert.AreEqual(expected.BreweryId, result.BreweryId);
                Assert.AreEqual(expected.ABV, result.ABV);
            }
        }
        [TestMethod]
        public async Task CreateBeer_Should_Fail_ExistingBeer()
        {
            //arrange
            var nameOfDb = Guid.NewGuid().ToString();
            var beerDTO = new BeerDTO
            {
                Id = BeerOverflowUtils.TuborgId,
                Name = "Tuborg",
                CountryId = BeerOverflowUtils.GermanyId,         
                StyleId = BeerOverflowUtils.PremiumLightStyleId, 
                BreweryId = BeerOverflowUtils.TuborgADId,        
                ABV = 4.8,
            };
            using (var arrangeContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }
            using (var assertContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                var sut = new BeerService(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentException>
                    (async () => await sut.CreateBeerAsync(beerDTO));
            }
        }
    }
}
