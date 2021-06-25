using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace BeerOverflow.Data.Entities
{
    public class Review
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; } // FK
        public Beer Beer { get; set; }
        public Guid BeerId { get; set; } // FK
        public bool? Like { get; set; }
        public bool IsFlagged { get; set; }
        public double Rating { get; set; }
        public string Text { get; set; }
        public ICollection<Vote> Votes { get; set; } = new List<Vote>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}
