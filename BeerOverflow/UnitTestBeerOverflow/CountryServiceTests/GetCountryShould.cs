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
    public class GetCountryShould
    {
        [TestMethod]
        public async Task GetCountryShould_Succeed()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var expected = new Country
            {
                Id = BeerOverflowUtils.BulgariaId, // Unique Id
                Name = "Bulgaria"
            };

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                //arrangeContext.Countries.Add(expected);
                //arrangeContext.SaveChanges();
                BeerOverflowUtils.Seed(arrangeContext);
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new CountryService(assertContext);
                var result = (await sut.GetCountryAsync(expected.Id));

                Assert.AreEqual(expected.Id, result.Id);
                Assert.AreEqual(expected.Name, result.Name);

            }
        }
        [TestMethod]
        public async Task GetCountryShould_Throw()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var expected = new Country
            {
                Id = BeerOverflowUtils.BulgariaId, // Unique Id
                Name = "Bulgaria"
            };


            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new CountryService(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>
                    (async () => await sut.GetCountryAsync(expected.Id));
            }
        }
    }
}
