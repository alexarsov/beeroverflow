//using BeerOverflow.Data.DataAccessContext;
//using BeerOverflow.Services.Contracts;
//using BeerOverflow.Services.DTOs;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//namespace BeerOverflow.Services.Services.Help_Services
//{
//    public class VoteService
//    {
//        private readonly BeerOverflowContext context;
//        private readonly IReviewBeerService reviewService;
//        public VoteService(BeerOverflowContext context)
//        {
//            this.context = context;
//        }
//        public async Task<ReviewDTO> UnVote(Guid reviewId) 
//        {
//            var reviewDTO = await reviewService.GetReviewAsync(reviewId);
//        }
//        public async Task<ReviewDTO> UpVote()
//        {

//        }
//        public async Task<ReviewDTO> DownVote()
//        {

//        }
//    }
//}
