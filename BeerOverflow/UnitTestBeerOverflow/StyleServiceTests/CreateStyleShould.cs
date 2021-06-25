using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Data.Entities;
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
    public class CreateStyleShould
    {
        [TestMethod]
        public async Task CreateStyleShould_Succeed_NewStyle()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var expected = new Style
            {
                Id = BeerOverflowUtils.PremiumLightStyleId,
                Name = "Premium Light",
            };
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new StyleService(assertContext);
                await sut.CreateStyleAsync(expected.Name);
                var result = assertContext.Styles.First();
                Assert.AreEqual(expected.Name, result.Name);
            }
        }
        [TestMethod]
        public async Task CreateStyleShould_Succeed_DeletedStyle()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var expected = new Style
            {
                Id = BeerOverflowUtils.DarkStyleId, // Unique Id
                Name = "Dark",
            };
            using (var arrangeContext = new BeerOverflowContext(options))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new StyleService(assertContext);
                await sut.CreateStyleAsync(expected.Name);
                var result = assertContext.Styles.First(x => x.Name == expected.Name);
                Assert.AreEqual(expected.Name, result.Name);
            }
        }
        [TestMethod]
        public async Task CreateStyleShould_Throw_Existing()
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
                await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await sut.CreateStyleAsync(expected.Name));
            }
        }
    }
}
