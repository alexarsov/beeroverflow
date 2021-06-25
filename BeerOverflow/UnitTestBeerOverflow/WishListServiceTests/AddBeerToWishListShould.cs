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

namespace BeerOverflow.UnitTests.WishListServiceTests
{
    [TestClass]
    public class AddBeerToWishListShould
    {
        [TestMethod]
        public async Task AddBeerToWishListShould_Succeed_NewWishList()
        //bad ids are not considered
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var expected = new UserWishBeer
            {
                BeerId = BeerOverflowUtils.TuborgId,
                UserId = BeerOverflowUtils.PeshoId,
            };
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new WishListService(assertContext);
                await sut.AddBeerToWishListAsync(expected.BeerId, expected.UserId);
                var result = assertContext.WishLists
                    .First(x => x.BeerId == expected.BeerId && x.UserId == expected.UserId);
                Assert.AreNotEqual(null, result);
            }
        }

        [TestMethod]
        public async Task AddBeerToWishListShould_Succeed_Existing()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var expected = new UserWishBeer
            {
                BeerId = BeerOverflowUtils.WishHeinekenId,
                UserId = BeerOverflowUtils.PeshoId,
            };
            using (var arrangeContext = new BeerOverflowContext(options))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new WishListService(assertContext);
                await sut.AddBeerToWishListAsync(expected.BeerId, expected.UserId);
                Assert.IsTrue(await sut.AddBeerToWishListAsync(expected.BeerId, expected.UserId));
            }
        }
    }
}