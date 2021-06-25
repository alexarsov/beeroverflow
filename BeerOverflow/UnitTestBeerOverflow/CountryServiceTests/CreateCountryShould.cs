using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services;
using BeerOverflow.Services.DTOs;
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
    public class CreateCountryShould
    {
        [TestMethod]
        public async Task CreateCountryShould_Succeed_NewCountry()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var expected = new Country
            {
                Name = "Bulgaria"
            };
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new CountryService(assertContext);
                await sut.CreateCountryAsync(expected.Name);
                var result = assertContext.Countries.First(x => x.Name == expected.Name);
                Assert.AreEqual(expected.Name, result.Name);
            }
        }
        [TestMethod]
        public async Task CreateCountryShould_Succeed_DeletedCountry()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var expected = new Country
            {
                Name = "Croatia"
            };
            using (var arrangeContext = new BeerOverflowContext(options))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new CountryService(assertContext);
                await sut.CreateCountryAsync(expected.Name);
                var result = assertContext.Countries.First(x => x.Name == expected.Name);
                Assert.AreEqual(expected.Name, result.Name);
            }
        }
        [TestMethod]
        public async Task CreateCountryShould_Throw_Existing()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var expected = new Country
            {
                Name = "Bulgaria"
            };
            using (var arrangeContext = new BeerOverflowContext(options))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new CountryService(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await sut.CreateCountryAsync(expected.Name));
            }
        }
    }
}