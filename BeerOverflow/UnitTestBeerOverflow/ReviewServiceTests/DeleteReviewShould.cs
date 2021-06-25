using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services.Services.Help_Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using UnitTestBeerOverflow;

namespace BeerOverflow.UnitTests.ReviewServiceTests
{
    [TestClass]
    public class DeleteReviewShould
    {
        [TestMethod]
        public async Task DeleteReviewShould_Return_False()
        {
            var nameOfDb = new StackTrace().GetFrame(0).GetMethod().Name;

            using (var assertContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                var sut = new ReviewBeerService(assertContext);
                Assert.IsFalse(await sut.DeleteReviewAsync(Guid.NewGuid(), Guid.NewGuid()));
            }
        }
        [TestMethod]
        public async Task DeleteReviewShould_Return_True_WhenDeleted()
        {
            var nameOfDb = Guid.NewGuid().ToString();

            var reviewDTO = new Review
            {
                BeerId = BeerOverflowUtils.KamenitzaId,
                UserId = BeerOverflowUtils.YaniId,
                Rating = 3,
                Text = "Its a very nice beer!",
                Like = true,
                IsFlagged = true
            };
            using (var arrangeContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }
            using (var assertContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                var sut = new ReviewBeerService(assertContext);
                Assert.IsTrue(await sut.DeleteReviewAsync(reviewDTO.BeerId, reviewDTO.UserId));
            }
        }
        [TestMethod]
        public async Task DeleteReviewShould_Return_True_WhenNotDeleted()
        {
            var nameOfDb = Guid.NewGuid().ToString();

            var reviewDTO = new Review
            {
                BeerId = BeerOverflowUtils.HeinekenId,
                UserId = BeerOverflowUtils.YaniId,
                Rating = 2,
                Text = "Try Tuborg!",
                Like = false,
            };


            using (var arrangeContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }
            using (var assertContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                var sut = new ReviewBeerService(assertContext);
                Assert.IsTrue(await sut.DeleteReviewAsync(reviewDTO.BeerId, reviewDTO.UserId));
            }
        }
    }
}
