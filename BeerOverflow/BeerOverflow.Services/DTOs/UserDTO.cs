using BeerOverflow.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeerOverflow.Services.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool IsBanned { get => Bans.Count == 0 ? false
                : !this.Bans.ToList()[Bans.Count - 1].HasExpired;}
        public bool IsDeleted { get; set; }
        public ICollection<Vote> Votes { get; set; } = new List<Vote>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Review> ReviewList { get; set; } = new List<Review>();
        public ICollection<UserDrankBeer> UserDrankBeers { get; set; } = new List<UserDrankBeer>();
        public ICollection<UserWishBeer> UserWishBeers { get; set; } = new List<UserWishBeer>();
        public ICollection<Ban> Bans { get; set; }
    }
}
