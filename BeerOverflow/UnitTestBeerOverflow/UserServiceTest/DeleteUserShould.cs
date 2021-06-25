using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitTestBeerOverflow;
using BeerOverflow.Data.Entities;
using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Services.Services.Main_Services;
using System.Linq;
using BeerOverflow.Services.Services.Help_Services;

namespace BeerOverflow.UnitTests.UserServiceTests
{
    [TestClass]
    public class DeleteUserShould
    {
        [TestMethod]
        public async Task DeleteUserShould_Return_True()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var User = new User
            {
                Id = BeerOverflowUtils.PeshoId,
                Email = "Pesho@qwe.com"
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
                var result = (await sut.DeleteUserAsync(User.Id));

                Assert.IsTrue(result);
                Assert.IsTrue(assertContext.Users.First(x => x.Id == User.Id).IsDeleted);

            }
        }
        [TestMethod]
        public async Task DeleteUserShould_Return_False()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var User = new User
            {
                Id = BeerOverflowUtils.BulgariaId, // Unique Id
                Name = "Bulgaria"
            };

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new UserService(assertContext,
                    new WishListService(assertContext),
                    new DrankListService(assertContext));
                var result = (await sut.DeleteUserAsync(User.Id));

                Assert.IsFalse(result);
            }
        }
    }
}