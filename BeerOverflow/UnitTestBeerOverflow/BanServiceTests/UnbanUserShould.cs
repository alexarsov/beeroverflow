using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Services.Services.Help_Services;
using Microsoft.EntityFrameworkCore;
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
    public class UnbanUserShould
    {
        [TestMethod]
        public async Task UnbanUserShould_Succeed_Return_True()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BanService(assertContext);
                Assert.IsFalse(await sut.UnbanUserAsync(BeerOverflowUtils.YaniId));
                Assert.IsFalse((assertContext.Users
                    .Include(x => x.Bans)
                    .First(x => x.Id == BeerOverflowUtils.YaniId)).IsBaned);
            }
        }
        [TestMethod]
        public async Task UnbanUserShould_Succeed_Return_False()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BanService(assertContext);
                Assert.IsTrue(await sut.UnbanUserAsync(BeerOverflowUtils.BaniId));
                var result = (assertContext.Users
                    .First(x => x.Id == BeerOverflowUtils.BaniId)).IsBaned;
                Assert.IsFalse(result);
            }
        }
        //public async Task<bool> UnbanUserAsync(Guid userId)
        //{
        //    var ban = await context.Bans.FirstOrDefaultAsync(b => b.UserId == userId);
        //    ban.ExpiresOn = DateTime.UtcNow;
        //    _ = context.SaveChangesAsync();
        //    return true;
        //}
    }
}