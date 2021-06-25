using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services;
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
    public class UpdateStyleShould
    {
        [TestMethod]
        public async Task UpdateStyleShould_Succeed_NewStyle()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var expected = new Style
            {
                Id = BeerOverflowUtils.GreenStyleId, // Unique Id
                Name = "TestStyle"
            };
            using (var arrangeContext = new BeerOverflowContext(options))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new StyleService(assertContext);
                await sut.UpdateStyleAsync(expected.Id, expected.Name);
                var result = assertContext.Styles.First(x => x.Id == expected.Id);
                Assert.AreEqual(expected.Id, result.Id);
                Assert.AreEqual(expected.Name, result.Name);
            }
        }

        [TestMethod]
        public async Task UpdateStyleShould_Throw_Inexisting()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var expected = new Style
            {
                Id = Guid.NewGuid(),
                Name = "TestStyle"
            };
            using (var arrangeContext = new BeerOverflowContext(options))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new StyleService(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentNullException>
                    (async () => await sut.UpdateStyleAsync(expected.Id, expected.Name));
            }
        }
    }
}
