using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace BeerOverflow.Web.Models
{
    public class BreweryViewModel
    {
        [DisplayName("Brewery Id")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        [MinLength(2, ErrorMessage = "Name must be between 3 and 30 symbols"),
         MaxLength(30, ErrorMessage = "Title must be between 3 and 30 symbols")]
        [DisplayName("Brewery")]
        public string Name { get; set; }
        [DisplayName("Country Id")]
        public Guid CountryId { get; set; }
        [DisplayName("Country")]
        public string CountryName { get; set; }
        [DisplayName("Created On")]
        public DateTime CreatedOn { get; set; }
        [DisplayName("Modified On")]
        public DateTime? ModifiedOn { get; set; }
    }
}
