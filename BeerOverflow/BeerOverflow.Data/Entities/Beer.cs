using BeerOverflow.Data.Entities.AbstractClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerOverflow.Data.Entities
{
    public class Beer : Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
        public Style Style { get; set; }
        public Guid StyleId { get; set; } // FK
        public Country Country { get; set; }
        public Guid CountryId { get; set; } // FK
        public Brewery Brewery { get; set; }
        public Guid BreweryId { get; set; } // FK
        public double ABV { get; set; } // Alcohol by volume
        public ICollection<Review> ReviewList { get; set; } = new List<Review>();
        public ICollection<UserDrankBeer> UserDrankBeers { get; set; } = new List<UserDrankBeer>();
        public ICollection<UserWishBeer> UserWishBeers { get; set; } = new List<UserWishBeer>();
    }
}
