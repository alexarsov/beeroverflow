using BeerOverflow.Data.Entities;
using BeerOverflow.Services.DTOs;

namespace BeerOverflow.Services.Mappers
{
    public static class ReviewMapper
    {
        public static ReviewDTO ToDTO(this Review review) 
        {
            return new ReviewDTO
            {
                BeerId = review.BeerId,
                UserId = review.UserId,
                IsFlagged = review.IsFlagged,
                Like = review.Like,
                Rating = review.Rating,
                Text = review.Text,
            };
        }
        public static Review TakeInfoFrom(this Review review, ReviewDTO reviewDTO)
        {
            review.BeerId = reviewDTO.BeerId;
            review.UserId = reviewDTO.UserId;
            review.IsFlagged = reviewDTO.IsFlagged;
            review.Like = reviewDTO.Like;
            review.Rating = reviewDTO.Rating;
            review.Text = reviewDTO.Text;
            return review;
        }
    }
}
