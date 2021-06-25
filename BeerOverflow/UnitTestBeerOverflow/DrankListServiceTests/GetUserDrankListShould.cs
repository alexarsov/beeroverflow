using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Services.Services.Help_Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestBeerOverflow;

namespace BeerOverflow.UnitTests.DrankListServiceTests
{
    [TestClass]
    public class GetUserDrankListShould
    {
        [TestMethod]
        public async Task GetUserDrankListShould_Succeed_Existing()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var expected = new[]
            {
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
            using (var arrangeContext = new BeerOverflowContext(options))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new DrankListService(assertContext);
                var result = (await sut.GetUserDrankListAsync(BeerOverflowUtils.PeshoId)).ToArray();
                Assert.AreEqual(expected.Length, result.Length);

                for (int i = 0; i < expected.Length; i++)
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
