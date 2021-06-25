using BeerOverflow.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerOverflow.Services.Contracts
{
    public interface IReviewBeerService
    {
        Task AddReviewAsync(ReviewDTO reviewDTO);
        Task<bool> DeleteReviewAsync(Guid beerId, Guid userId);
        Task<IEnumerable<ReviewDTO>> GetReviewsOfBeerAsync(Guid beerId);
        Task<ReviewDTO> GetReviewOfBeerAsync(Guid beerId, Guid userId);
        Task UpdateReviewAsync(ReviewDTO reviewDTO);
    }
}