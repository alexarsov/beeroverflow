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
    public class BanUserShould
    {
        [TestMethod]
        public async Task BanUserShould_Succeed_True()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var banDTO = new BanDTO
            {
                UserId = BeerOverflowUtils.BaniId,
                Description = "Verbal abuse",
                ExpiresOn = DateTime.Today.AddDays(2),
            };
            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Users.Add(new User { Id = BeerOverflowUtils.BaniId });
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BanService(assertContext);
                var result1 = await sut.BanUserAsync(banDTO);
                var result2 = assertContext.Bans.First().HasExpired;
                var result3 = assertContext.Users
                    .Include(x => x.Bans)
                    .First(x => x.Id == banDTO.UserId).IsBaned;
                Assert.IsTrue(result1);
                Assert.IsFalse(result2);
                Assert.IsTrue(result3);
            }
        }
        [TestMethod]
        public async Task BanUserShould_Succeed_False()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var banDTO = new BanDTO
            {
                UserId = BeerOverflowUtils.BaniId,
                Description = "Verbal abuse",
                ExpiresOn = DateTime.UtcNow,
            };
            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Users.Add(new User { Id = BeerOverflowUtils.BaniId });
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BanService(assertContext);
                var result1 = await sut.BanUserAsync(banDTO);
                var result2 = assertContext.Bans.First().HasExpired;
                var result3 = assertContext.Users.First(x => x.Id == banDTO.UserId).IsBaned;
                Assert.IsTrue(result1);
                Assert.IsTrue(result2);
                Assert.IsFalse(result3);
            }
        }
    }
}