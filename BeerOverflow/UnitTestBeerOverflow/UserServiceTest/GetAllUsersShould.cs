using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Data.Entities;
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
    public class GetAllUsersShould
    {
        [TestMethod]
        public async Task GetAllUsers_Should_Succeed()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var expected = new[] {
                 new User
                {
                    Id = BeerOverflowUtils.PeshoId,
                    Email = "Pesho@qwe.com"
                },
                new User
                {
                    Id = BeerOverflowUtils.YaniId,
                    Email = "Yani@qwe.com"
                },
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
                var result = (await sut.GetAllValidUsersAsync()).ToArray();

                Assert.AreEqual(expected.Length, result.Length);
                for (int i = 0; i < result.Length; i++)
                {
                    Assert.AreEqual(expected[i].Email, result[i].Email);
                }
            }
        }
    }
}
