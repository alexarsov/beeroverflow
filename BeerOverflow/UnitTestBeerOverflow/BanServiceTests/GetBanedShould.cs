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
    public class GetBanedShould
    {
        [TestMethod]
        public async Task GetBanedShould_Succeed()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            User expected;
            using (var arrangeContext = new BeerOverflowContext(options))
            {
                BeerOverflowUtils.Seed(arrangeContext);
                expected = arrangeContext.Users.First(x => x.Id == BeerOverflowUtils.BaniId);
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BanService(assertContext);
                var result = await sut.GetBannedUserAsync(BeerOverflowUtils.BaniId);
                Assert.AreEqual("Bani@qwe.com", result.Email);
                Assert.IsTrue(result.IsBanned);
            }
        }
    }
}