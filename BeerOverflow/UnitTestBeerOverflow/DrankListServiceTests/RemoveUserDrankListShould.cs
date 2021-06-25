using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Services.Services.Help_Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestBeerOverflow;


namespace BeerOverflow.UnitTests.DrankListServiceTests
{
    [TestClass]
    public class RemoveUserDrankListShould
    {
        [TestMethod]
        public async Task RemoveUserDrankListShould_Succeed()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var options = BeerOverflowUtils.GetOptions(nameOfDb);
            var peshoDrankLists = new[] {
                 new UserDrankBeer
                {
                  Id = BeerOverflowUtils.DrankTuborgId,
                  BeerId = BeerOverflowUtils.TuborgId,
                  UserId = BeerOverflowUtils.PeshoId
                },
                 new UserDrankBeer
                 {
                     Id = BeerOverflowUtils.DrankHeinekenId,
                     BeerId = BeerOverflowUtils.HeinekenId,
                     UserId = BeerOverflowUtils.PeshoId
                 },
            };
            using (var arrangeContext = new BeerOverflowContext(options))
            {
                BeerOverflowUtils.Seed(arrangeContext);
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new DrankListService(assertContext);
                var result = await sut.RemoveUserDrankListAsync(BeerOverflowUtils.PeshoId);
                for (int i = 0; i < 2; i++)
                {
                    Assert.IsTrue(assertContext.DrankLists
                    .First(x => x.BeerId == peshoDrankLists[i].BeerId
                    && x.UserId == peshoDrankLists[i].UserId)
                    .IsDeleted);
                }
            }
        }
    }
}

