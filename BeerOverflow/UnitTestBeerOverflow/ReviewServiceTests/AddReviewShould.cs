using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Services.Services.Help_Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
    public class AddReviewShould
    {
       
        [TestMethod]
        public async Task AddReviewShould_SucceedAsync()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var reviewDTO = new ReviewDTO
            {
                BeerId = BeerOverflowUtils.KamenitzaId,
                UserId = BeerOverflowUtils.PeshoId,
                Rating = 3,
                Text = "Its a nice beer!",
                Like = true,
            };
            var expected = new Review
            {
                BeerId = BeerOverflowUtils.KamenitzaId,
                UserId = BeerOverflowUtils.PeshoId,
                Rating = 3,
                Text = "Its a nice beer!",
                Like = true,
            };

            using (var assertContext = new BeerOverflowContext(BeerOverflowUtils.GetOptions(nameOfDb)))
            {
                var sut = new ReviewBeerService(assertContext);
                await sut.AddReviewAsync(reviewDTO);
                var result = assertContext.Reviews.First();
                Assert.AreEqual(expected.BeerId, result.BeerId);
                Assert.AreEqual(expected.UserId, result.UserId);
                Assert.AreEqual(expected.Rating, result.Rating);
                Assert.AreEqual(expected.Text, result.Text);
                Assert.AreEqual(expected.Like, result.Like);
            }
        }
    }
}
