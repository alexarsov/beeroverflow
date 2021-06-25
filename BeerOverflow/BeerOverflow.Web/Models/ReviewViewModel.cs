using System.ComponentModel.DataAnnotations;
using System;

namespace BeerOverflow.Web.Models
{
    public class ReviewViewModel
    {
        public Guid UserId { get; set; }
        public Guid BeerId { get; set; }
        public bool Like { get; set; }
        public bool IsFlagged { get; set; }
        public double Rating { get; set; }
        [Required(ErrorMessage = "You need to submit a review!")]
        [MinLength(2, ErrorMessage = "Review must be between 3 and 500 symbols"),
        MaxLength(30, ErrorMessage = "Title must be between 3 and 500 symbols")]
        public string Comment { get; set; }
    }
}
