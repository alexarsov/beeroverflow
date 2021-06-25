using BeerOverflow.Data.DataAccessContext;
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
    public class GetAllCountriesShould
    {
        [TestMethod]
        public async Task GetAllCountries_Should_Succeed() 
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var expected = new[] {
                 new CountryDTO
               {
                   Name = "Bulgaria"
               },

               new CountryDTO
               {
                   Name = "Germany"
               },
            };

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new CountryService(assertContext);
                var result = (await sut.GetAllCountriesAsync()).ToArray();

                Assert.AreEqual(expected.Length, result.Length);
                for (int i = 0; i < result.Length; i++)
                {
                    Assert.AreEqual(expected[i].Name, result[i].Name);
                }
            }
        }
    }
}
