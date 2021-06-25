using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services;
using BeerOverflow.Services.Services.Main_Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitTestBeerOverflow;

namespace BeerOverflow.UnitTests.StyleServiceTests
{
    [TestClass]
    public class GetStyleShould
    {
        [TestMethod]
        public async Task GetStyleShould_Succeed()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var expected = new Style
            {
                Id = BeerOverflowUtils.PremiumLightStyleId, 
                Name = "Premium Light",
            };

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new StyleService(assertContext);
                var result = (await sut.GetStyleAsync(expected.Id));

                Assert.AreEqual(expected.Id, result.Id);
                Assert.AreEqual(expected.Name, result.Name);

            }
        }
        [TestMethod]
        public async Task GetStyleShould_Throw()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var expected = new Style
            {
                Id = BeerOverflowUtils.PremiumLightStyleId, // Unique Id
                Name = "Premium Light",
            };

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new StyleService(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>
                    (async () => await sut.GetStyleAsync(expected.Id));
            }
        }
    }
}
