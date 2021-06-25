using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Services.DTOs;
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
    public class UpdateReviewShould
    {
        [TestMethod]
        public async Task UpdateReviewShould_Throw()
        {
            var nameOfDb = new StackTrace().GetFrame(0).GetMethod().Name;

            using (var assertContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                var sut = new ReviewBeerService(assertContext);

                _ = await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await sut.UpdateReviewAsync(new ReviewDTO()));
            }
        }
        [TestMethod]
        public async Task UpdateReviewShould_SucceedAsync()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var expected = new ReviewDTO
            {
                BeerId = BeerOverflowUtils.KamenitzaId,
                UserId = BeerOverflowUtils.PeshoId,
                Rating = 5,
                Text = "Its a nice beer!",
                Like = true,
            };

            using (var arrangeContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }

            using (var assertContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                var sut = new ReviewBeerService(assertContext);
                await sut.UpdateReviewAsync(expected);
                var result = assertContext.Reviews
                    .First(x=>x.BeerId == expected.BeerId && x.UserId == expected.UserId);
                Assert.AreEqual(expected.BeerId, result.BeerId);
                Assert.AreEqual(expected.UserId, result.UserId);
                Assert.AreEqual(expected.Rating, result.Rating);
                Assert.AreEqual(expected.Text, result.Text);
                Assert.AreEqual(expected.Like, result.Like);
            }
        }
    }
}
