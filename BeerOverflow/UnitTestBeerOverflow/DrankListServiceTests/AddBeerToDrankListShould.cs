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
    public class AddBeerToDrankListShould
    {
        [TestMethod]
        public async Task AddBeerToDrankListShould_Succeed_NewDrankList()
        //bad ids are not considered
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var expected = new UserDrankBeer
            {
                Id = BeerOverflowUtils.DrankTuborgId,
                BeerId = BeerOverflowUtils.TuborgId,
                UserId = BeerOverflowUtils.PeshoId
            };
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new DrankListService(assertContext);
                await sut.AddBeerToDrankListAsync(expected.BeerId, expected.UserId);
                var result = assertContext.DrankLists
                    .First(x => x.BeerId == expected.BeerId && x.UserId == expected.UserId);
                Assert.AreNotEqual(null, result);
            }
        }

        [TestMethod]
        public async Task AddBeerToDrankListShould_Succeed_Existing()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var expected = new UserDrankBeer
            {
                BeerId = BeerOverflowUtils.DrankHeinekenId,
                UserId = BeerOverflowUtils.PeshoId,
            };
            using (var arrangeContext = new BeerOverflowContext(options))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new DrankListService(assertContext);
                await sut.AddBeerToDrankListAsync(expected.BeerId, expected.UserId);
                Assert.IsTrue(await sut.AddBeerToDrankListAsync(expected.BeerId, expected.UserId));
            }
        }
    }
}