using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Services.Services.Help_Services;
using BeerOverflow.Services.Services.Main_Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestBeerOverflow;

namespace BeerOverflow.UnitTests.UserServiceTests
{

    [TestClass]
    public class UpdateUserShould
    {
        [TestMethod]
        public async Task UpdateUserShould_Succeed_NewUser()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var Id = BeerOverflowUtils.YaniId;
            var expected = new UserDTO
            {
                Email = "Yai@qwe.com",
            };
            using (var arrangeContext = new BeerOverflowContext(options))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new UserService(assertContext,
                    new WishListService(assertContext),
                    new DrankListService(assertContext));
                await sut.UpdateUserAsync(Id, expected);
                var result = assertContext.Users.First(x => x.Id == Id);
                Assert.AreEqual(Id, result.Id);
                Assert.AreEqual(expected.Email, result.Email);
            }
        }

        [TestMethod]
        public async Task UpdateUserShould_Throw_Inexisting()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var Id = Guid.NewGuid();
            var expected = new UserDTO
            {
                Email = "TestUser@qwe.com"
            };
            using (var arrangeContext = new BeerOverflowContext(options))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new UserService(assertContext,
                    new WishListService(assertContext),
                    new DrankListService(assertContext));
                await Assert.ThrowsExceptionAsync<ArgumentNullException>
                    (async () => await sut.UpdateUserAsync(Id, expected));
            }
        }
    }
}
