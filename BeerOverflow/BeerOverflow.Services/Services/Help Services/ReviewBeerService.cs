using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.Mappers;
using Microsoft.EntityFrameworkCore;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace BeerOverflow.Services.Services.Help_Services
{
    public class ReviewBeerService : IReviewBeerService
    {
        private readonly BeerOverflowContext context;
        public ReviewBeerService(BeerOverflowContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<ReviewDTO>> GetReviewsOfBeerAsync(Guid beerId)
        {
            return await context.Reviews.Include(x => x.User).Where(x => x.BeerId == beerId && x.IsFlagged == false).Select(x => x.ToDTO()).ToArrayAsync();
        }
        public async Task AddReviewAsync(ReviewDTO reviewDTO)
        {
            var existing = await context.Reviews.FirstOrDefaultAsync(x => x.UserId == reviewDTO.UserId && x.BeerId == reviewDTO.BeerId);
            if (existing == null)
            {
                Review review = new Review();
                review.TakeInfoFrom(reviewDTO);
                _ = await context.AddAsync(review);
                _ = await context.SaveChangesAsync();
            }
            else if (existing.IsFlagged)
            {
                throw new ArgumentException();
            }
            else
            {
                await UpdateReviewAsync(reviewDTO);
            }
            return;
        }
        public async Task UpdateReviewAsync(ReviewDTO reviewDTO)
        {
            var review = await context.Reviews
                .FirstOrDefaultAsync(x => x.UserId == reviewDTO.UserId && x.BeerId == reviewDTO.BeerId);
            if (review == null)
            {
                throw new ArgumentNullException();
            }
            if (review.IsFlagged)
            {
                throw new ArgumentException();
            }
            review.TakeInfoFrom(reviewDTO);
            _ = await context.SaveChangesAsync(); 
        }
        public async Task<bool> DeleteReviewAsync(Guid beerId, Guid userId)
        {
            var review = await context.Reviews.FirstOrDefaultAsync(x => x.UserId == userId && x.BeerId == beerId);
            if (review == null)
            {
                return false;
            }
            review.IsFlagged = true;
            _ = await context.SaveChangesAsync();
            return true;
        }
        public async Task<ReviewDTO> GetReviewOfBeerAsync(Guid beerId, Guid userId)
        {
            var review = await context.Reviews
                .FirstOrDefaultAsync(x => x.BeerId == beerId && x.BeerId == beerId && x.IsFlagged == false);
            if (review == null)
            {
                throw new ArgumentNullException();
            }
            return review.ToDTO();
        }
    }
}
