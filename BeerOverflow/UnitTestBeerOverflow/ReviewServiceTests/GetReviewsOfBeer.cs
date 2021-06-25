using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Services.Services;
using BeerOverflow.Services.Services.Help_Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestBeerOverflow;

namespace BeerOverflow.UnitTests.ReviewServiceTests
{
    [TestClass]
    public class GetReviewsOfBeer
    {
        [TestMethod]
        public async Task GetReviewsOfBeer_Succeed() 
        {
            var nameOfDb = Guid.NewGuid().ToString();

            var expected = new[] {
                new ReviewDTO
                {
                    BeerId = BeerOverflowUtils.HeinekenId,
                    UserId = BeerOverflowUtils.YaniId,
                    Rating = 2,
                    Text = "Try Tuborg!",
                    Like = false,
                }
            };

            using (var arrangeContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }

            using (var assertContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                var sut = new ReviewBeerService(assertContext);
                var result = (await sut.GetReviewsOfBeerAsync(expected[0].BeerId)).ToArray();

                Assert.AreEqual(expected.Length, result.Length);

                for (int i = 0; i < result.Length; i++)
                {
                    Assert.AreEqual(expected[i].UserId, result[i].UserId);
                    Assert.AreEqual(expected[i].BeerId, result[i].BeerId);
                    Assert.AreEqual(expected[i].IsFlagged, result[i].IsFlagged);
                    Assert.AreEqual(expected[i].Like, result[i].Like);
                    Assert.AreEqual(expected[i].Rating, result[i].Rating);
                    Assert.AreEqual(expected[i].Text, result[i].Text);
                }
            }
        }
    }
}
