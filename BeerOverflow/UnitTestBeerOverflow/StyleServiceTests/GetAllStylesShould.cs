using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Services.Services.Main_Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestBeerOverflow;

namespace BeerOverflow.UnitTests.StyleServiceTests
{
    [TestClass]
    public class GetAllStylesShould
    {
        [TestMethod]
        public async Task GetAllStyles_Should_Succeed()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var expected = new[] {
                new StyleDTO
               {
                   Id = BeerOverflowUtils.PremiumLightStyleId, // Unique Id
                   Name = "Premium Light",
               },

               new StyleDTO
               {
                   Id = BeerOverflowUtils.GreenStyleId, // Unique Id
                   Name = "Green",
               },
            };

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new StyleService(assertContext);
                var result = (await sut.GetAllStylesAsync()).ToArray();

                Assert.AreEqual(expected.Length, result.Length);
                for (int i = 0; i < result.Length; i++)
                {
                    Assert.AreEqual(expected[i].Name, result[i].Name);
                }
            }
        }
    }
}
