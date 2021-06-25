using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UnitTestBeerOverflow;

namespace BeerOverflow.UnitTests.BeerServiceTests.FilterTests
{
    [TestClass]
    public class FilterBeersByCountryNameShould
    {
        [TestMethod]
        public async System.Threading.Tasks.Task FilterBeersByCountryNameShould_SucceedAsync()
        {
            var nameOfDb = Guid.NewGuid().ToString(); 
            var expected = new BeerDTO[] {
              new BeerDTO
              {
                  Id = BeerOverflowUtils.TuborgId,
                  Name = "Tuborg",
                  CountryId = BeerOverflowUtils.GermanyId,
                  CountryName = "Germany",
                  StyleId = BeerOverflowUtils.PremiumLightStyleId,
                  StyleName = "Premium Light",
                  BreweryId = BeerOverflowUtils.TuborgADId,
                  BreweryName = "TuborgAD",
                  ABV = 4.8,
              },
            };
            using (var arrangeContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }

            using (var assertContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                var sut = new FilterBeerService(assertContext);
                var result = (await sut.FilterBeersByCountryNameAsync(expected[0].CountryName)).ToArray();

                Assert.AreEqual(expected.Length, result.Length);

                for (int i = 0; i < result.Length; i++)
                {
                    Assert.AreEqual(expected[i].Name, result[i].Name);
                    Assert.AreEqual(expected[i].CountryId, result[i].CountryId);
                    Assert.AreEqual(expected[i].CountryName, result[i].CountryName);
                    Assert.AreEqual(expected[i].StyleId, result[i].StyleId);
                    Assert.AreEqual(expected[i].StyleName, result[i].StyleName);
                    Assert.AreEqual(expected[i].BreweryId, result[i].BreweryId);
                    Assert.AreEqual(expected[i].BreweryName, result[i].BreweryName);
                    Assert.AreEqual(expected[i].ABV, result[i].ABV);
                }
            }

        }
    }
}
