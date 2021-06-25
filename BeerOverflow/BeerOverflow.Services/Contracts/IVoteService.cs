using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.Contracts
{
    public interface IVoteService
    {
        public int CalculateVotes(Guid reviewId);
        public bool UnlistBeer(Guid beerId);
        public bool UpVoteReview(Guid userId, Guid reviewId);
    }
}
