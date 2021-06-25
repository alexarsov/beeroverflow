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
    public class RemoveBeerFromDrankListShould
    {
        [TestMethod]
        public async Task RemoveBeerFromDrankListShould_Succeed_Existing()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var expected = new BeerDTO
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
            };
            using (var arrangeContext = new BeerOverflowContext(options))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new DrankListService(assertContext);
                var result1 = (await sut
                    .RemoveBeerFromDrankListAsync
                    (BeerOverflowUtils.TuborgId, BeerOverflowUtils.PeshoId));

                var result2 = assertContext.DrankLists
                    .First(x => x.BeerId == BeerOverflowUtils.TuborgId
                    && x.UserId == BeerOverflowUtils.PeshoId).IsDeleted;
                Assert.IsTrue(result1);
                Assert.IsTrue(result2);

            }
        }
    }

}
