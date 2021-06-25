using System;

namespace BeerOverflow.Services.DTOs
{
    public class ReviewDTO
    {
        public Guid UserId { get; set; } // FK
        public Guid BeerId { get; set; } // FK
        public bool? Like { get; set; }
        public bool IsFlagged { get; set; }
        public double Rating { get; set; }
        public string Text { get; set; }
    }
}
