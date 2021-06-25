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

namespace BeerOverflow.UnitTests.StyleServiceTests
{
    [TestClass]
    public class DeleteStyleShould
    {
        [TestMethod]
        public async Task DeleteStyleShould_Return_True()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var style = new Style
            {
                Id = BeerOverflowUtils.GreenStyleId, // Unique Id
                Name = "Green",
            };

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new StyleService(assertContext);
                var result = (await sut.DeleteStyleAsync(style.Id));

                Assert.IsTrue(result);
                Assert.IsTrue(assertContext.Styles.First(x => x.Id == style.Id).IsDeleted);

            }
        }
        [TestMethod]
        public async Task DeleteStyleShould_Return_False()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var style = new Style
            {
                Id = BeerOverflowUtils.BulgariaId, // Unique Id
                Name = "Bulgaria"
            };

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new StyleService(assertContext);
                var result = (await sut.DeleteStyleAsync(style.Id));

                Assert.IsFalse(result);
            }
        }
    }
}