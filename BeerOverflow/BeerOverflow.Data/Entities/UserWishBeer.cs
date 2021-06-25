using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace BeerOverflow.Data.Entities
{
    public class UserWishBeer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public Beer Beer { get; set; }
        public Guid BeerId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
