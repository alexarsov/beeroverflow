using BeerOverflow.Services.DTOs;
using BeerOverflow.Web.Models;

namespace BeerOverflow.Web.WebMappers
{
    public static class ReviewWebMapper
    {
        public static ReviewViewModel MapToReviewVM(this ReviewDTO reviewDTO)
        {
            var reviewVM = new ReviewViewModel
            {
                UserId = reviewDTO.UserId,
                BeerId = reviewDTO.BeerId,
                Like = (bool)reviewDTO.Like,
                IsFlagged = reviewDTO.IsFlagged,
                Rating = reviewDTO.Rating,
                Comment = reviewDTO.Text
            };

            return reviewVM;
        }

        public static ReviewDTO MapToReviewDTO(this ReviewViewModel reviewVM)
        {
            var reviewDTO = new ReviewDTO
            {
                UserId = reviewVM.UserId,
                BeerId = reviewVM.BeerId,
                IsFlagged = reviewVM.IsFlagged,
                Rating = reviewVM.Rating,
                Like =  reviewVM.Like,
                Text = reviewVM.Comment
            };

            return reviewDTO;
        }
    }
}
