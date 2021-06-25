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
    public class DeleteCountryShould
    {
        [TestMethod]
        public async Task DeleteCountryShould_Return_True()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var country = new Country
            {
                Id = BeerOverflowUtils.BulgariaId, // Unique Id
                Name = "Bulgaria"
            };

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new CountryService(assertContext);
                var result = (await sut.DeleteCountryAsync(country.Id));

                Assert.IsTrue(result);
                Assert.IsTrue(assertContext.Countries.First(x => x.Id == country.Id).IsDeleted);

            }
        }
        [TestMethod]
        public async Task DeleteCountryShould_Return_False()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var country = new Country
            {
                Id = BeerOverflowUtils.BulgariaId, // Unique Id
                Name = "Bulgaria"
            };

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new CountryService(assertContext);
                var result = (await sut.DeleteCountryAsync(country.Id));

                Assert.IsFalse(result);
            }
        }
    }
}
