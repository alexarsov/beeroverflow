using System;
using System.Collections.Generic;

namespace BeerOverflow.Services.DTOs
{
    public class BeerDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid StyleId { get; set; }
        public Guid CountryId { get; set; }
        public Guid BreweryId { get; set; }
        public string StyleName { get; set; }
        public string CountryName { get; set; }
        public string BreweryName { get; set; }
        public double Rating { get; set; } // Holds the AVG from rating list
        public int Likes { get; set; }
        public double ABV { get; set; } // Alcohol by volume
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public ICollection<string> Comments { get; set; }
        public ICollection<string> UserNames { get; set; }
    }
}
