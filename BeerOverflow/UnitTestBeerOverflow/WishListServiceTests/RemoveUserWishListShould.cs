using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Services.Services.Help_Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestBeerOverflow;


namespace BeerOverflow.UnitTests.WishListServiceTests
{
    [TestClass]
    public class RemoveUserWishListShould
    {
        [TestMethod]
        public async Task RemoveUserWishListShould_Succeed()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var peshoWishLists = new[] {
                 new UserWishBeer
                {
                  Id =  BeerOverflowUtils.WishTuborgId,
                  BeerId = BeerOverflowUtils.TuborgId,
                  UserId = BeerOverflowUtils.PeshoId
                },
                 new UserWishBeer
                 {
                     Id =  BeerOverflowUtils.WishHeinekenId,
                     BeerId = BeerOverflowUtils.HeinekenId,
                     UserId = BeerOverflowUtils.PeshoId
                 },
            };
            using (var arrangeContext = new BeerOverflowContext(options))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new WishListService(assertContext);
                var result = await sut.RemoveUserWishListAsync(BeerOverflowUtils.PeshoId);
                for (int i = 0; i < 2; i++)
                {
                    Assert.IsTrue(assertContext.WishLists
                    .First(x => x.BeerId == peshoWishLists[i].BeerId
                    && x.UserId == peshoWishLists[i].UserId)
                    .IsDeleted);
                }
            }
        }
    }
}

