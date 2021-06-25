using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestBeerOverflow;

namespace BeerOverflow.UnitTests.CountryServiceTests
{

    [TestClass]
    public class UpdateCountryShould
    {
        [TestMethod]
        public async Task UpdateCountryShould_Succeed_NewCountry()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var expected = new Country
            {
                Id = BeerOverflowUtils.BulgariaId, // Unique Id
                Name = "TestCountry"
            };
            using (var arrangeContext = new BeerOverflowContext(options))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new CountryService(assertContext);
                await sut.UpdateCountryAsync(expected.Id, expected.Name);
                var result = assertContext.Countries.First(x => x.Id == expected.Id);
                Assert.AreEqual(expected.Id, result.Id);
                Assert.AreEqual(expected.Name, result.Name);
            }
        }

        [TestMethod]
        public async Task UpdateCountryShould_Throw_Inexisting()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var expected = new Country
            {
                Id = BeerOverflowUtils.CroatiaId,
                Name = "Croatia"
            };
            using (var arrangeContext = new BeerOverflowContext(options))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new CountryService(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentNullException>
                    (async () => await sut.UpdateCountryAsync(expected.Id, expected.Name));
            }
        }
    }
}
