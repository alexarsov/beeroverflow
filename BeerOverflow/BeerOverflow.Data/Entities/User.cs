using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System;
using System.Linq;

namespace BeerOverflow.Data.Entities
{
    public class User : IdentityUser<Guid>
    {
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedOn { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public bool IsBaned { get => Bans.Count == 0 ? false
                : !this.Bans.ToList()[Bans.Count - 1].HasExpired; }
        public ICollection<Vote> Votes { get; set; } = new List<Vote>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Review> ReviewList { get; set; } = new List<Review>();
        public ICollection<UserDrankBeer> UserDrankBeers { get; set; } = new List<UserDrankBeer>();
        public ICollection<UserWishBeer> UserWishBeers { get; set; } = new List<UserWishBeer>();
        public ICollection<Ban> Bans { get; set; }
    }
}
