using BeerOverflow.Services.Services.Main_Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Services.DTOs;
using UnitTestBeerOverflow;
using System;
using BeerOverflow.Services.Services;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;

namespace BeerOverflow.UnitTests.BreweryServiceTests
{
    [TestClass]
    public class CreateBreweryShould
    {
        [TestMethod]
        public async Task CreateBreweryShould_Succeed_Inexisting()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var expected = new BreweryDTO
            {
                Id = BeerOverflowUtils.KamenitzaADId, // Unique Id
                Name = "KamenitzaAD",
                CountryId = BeerOverflowUtils.BulgariaId, // the same as Bulgaria Id
            };


            using (var assertContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                var sut = new BreweryService(assertContext, new BeerService(assertContext));
                await sut.CreateBreweryAsync(expected);
                var result = assertContext.Breweries.First(x => x.Id == expected.Id);
                Assert.AreEqual(expected.Name, result.Name);
                Assert.AreEqual(expected.CountryId, result.CountryId);
            }
        }
        [TestMethod]
        public async Task CreateBreweryShould_Succeed_DeletedAsync()
        {
            var nameOfDb = new StackTrace().GetFrame(0).GetMethod().Name;
            var expected = new BreweryDTO
            {
                Id = BeerOverflowUtils.HeinekenADId, // Unique Id
                Name = "HeinekenAD",
                CountryId = BeerOverflowUtils.GermanyId, // The same as Germany Id
                IsDeleted = true,
            };

            using (var arrangeContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }

            using (var assertContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                var sut = new BreweryService(assertContext, new BeerService(assertContext));
                await sut.CreateBreweryAsync(expected);
                var result = assertContext.Breweries.First(x => x.Id == expected.Id);
                Assert.AreEqual(expected.Name, result.Name);
                Assert.AreEqual(expected.CountryId, result.CountryId);
            }
        }
        [TestMethod]
        public async Task CreateBreweryShould_ThrowAsync()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var expected = new BreweryDTO
            {
                Id = BeerOverflowUtils.KamenitzaADId, // Unique Id
                Name = "KamenitzaAD",
                CountryId = BeerOverflowUtils.BulgariaId, // the same as Bulgaria Id
            };

            using (var arrangeContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {                                                                                
                BeerOverflowUtils.Seed(arrangeContext);                                      
            }                                                                                
                                                                                             
            using (var assertContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                var sut = new BreweryService(assertContext, new BeerService(assertContext));
                ;
                var result = assertContext.Breweries.First(x => x.Id == expected.Id);
                await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await sut.CreateBreweryAsync(expected));
            }
        }
    }
}

