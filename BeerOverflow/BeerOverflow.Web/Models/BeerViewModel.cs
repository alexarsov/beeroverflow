using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;
using System.Collections.Generic;

namespace BeerOverflow.Web.Models
{
    public class BeerViewModel
    {
        [DisplayName("Beer Id")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        [MinLength(2, ErrorMessage = "Name must be between 3 and 30 symbols"),
        MaxLength(30, ErrorMessage = "Title must be between 3 and 30 symbols")]
        [DisplayName("Beer name")]
        public string Name { get; set; }
        [DisplayName("Style id")]
        public Guid StyleId { get; set; }
        [DisplayName("Beer style")]
        public string StyleName { get; set; }
        [DisplayName("Country Id")]
        public Guid CountryId { get; set; }
        [DisplayName("Country")]
        public string CountryName { get; set; }
        [DisplayName("Brewery Id")]
        public Guid BreweryId { get; set; }
        [DisplayName("Brewery")]
        public string BreweryName { get; set; }
        public double Rating { get; set; }
        public int Likes { get; set; }
        [DisplayName("Alcohol %")]
        public double ABV { get; set; }
        [DisplayName("Created On")]
        public DateTime CreatedOn { get; set; }
        [DisplayName("Modified On")]
        public DateTime? ModifiedOn { get; set; }
        public List<string> Comments { get; set; }
        public List<string> UserNames { get; set; }
    }
}
