using BeerOverflow.Services.Services.Main_Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Data.Entities;
using UnitTestBeerOverflow;
using System.Linq;
using System;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Services.Services;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BeerOverflow.UnitTests.BreweryServiceTests
{
    [TestClass]
    public class GetAllBreweriesShould
    {
        [TestMethod]
        public async Task GetAllBreweriesShould_Succeed()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var expected = new[] {
                 new BreweryDTO
               {
                   Id = BeerOverflowUtils.KamenitzaADId, // Unique Id
                   Name = "KamenitzaAD",
                   CountryId = BeerOverflowUtils.BulgariaId, // the same as Bulgaria Id
                   CountryName = "Bulgaria", // the same as Bulgaria Id
               },

               new BreweryDTO
               {
                   Id = BeerOverflowUtils.TuborgADId, // Unique Id
                   Name = "TuborgAD",
                   CountryId = BeerOverflowUtils.GermanyId, // The same as Germany Id
                   CountryName = "Germany", // the same as Bulgaria Id
               },
            };

            using (var arrangeContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }

            using (var assertContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                var sut = new BreweryService(assertContext, new BeerService(assertContext));
                var result = (await sut.GetAllBreweriesAsync()).ToArray();

                Assert.AreEqual(expected.Length, result.Length);
                for (int i = 0; i < result.Length; i++)
                {
                    Assert.AreEqual(expected[i].Name, result[i].Name);
                    Assert.AreEqual(expected[i].CountryId, result[i].CountryId);
                    Assert.AreEqual(expected[i].CountryName, result[i].CountryName);
                }
            }
        }

        [TestMethod]
        public async Task GetAllUndeletedBreweries_Succeed_With_Empty()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var breweries = new[] {
                new Brewery
               {
                   Id = BeerOverflowUtils.KamenitzaADId, // Unique Id
                   Name = "KamenitzaAD",
                   CountryId = BeerOverflowUtils.BulgariaId, // the same as Bulgaria Id
                   IsDeleted = true,
               },

               new Brewery
               {
                   Id = BeerOverflowUtils.TuborgADId, // Unique Id
                   Name = "TuborgAD",
                   CountryId = BeerOverflowUtils.GermanyId, // The same as Germany Id
                   IsDeleted = true,
               },
               new Brewery
               {
                   Id = BeerOverflowUtils.HeinekenADId, // Unique Id
                   Name = "HeinekenAD",
                   CountryId = BeerOverflowUtils.GermanyId, // The same as Germany Id
                   IsDeleted = true,
               }
            };
            using (var arrangeContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                arrangeContext.Breweries.AddRange(breweries);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                var sut = new BreweryService(assertContext, new BeerService(assertContext));
                var result = (await sut.GetAllBreweriesAsync()).ToList();

                Assert.AreEqual(0, result.Count);
            }
        }
    }
}
