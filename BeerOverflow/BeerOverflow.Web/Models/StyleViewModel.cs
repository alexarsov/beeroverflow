using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace BeerOverflow.Web.Models
{
    public class StyleViewModel
    {
        [DisplayName("Style id")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        [MinLength(2, ErrorMessage = "Name must be between 3 and 30 symbols"),
        MaxLength(30, ErrorMessage = "Title must be between 3 and 30 symbols")]
        [DisplayName("Beer style")]
        public string Name { get; set; }
        [DisplayName("Created On")]
        public DateTime CreatedOn { get; set; }
    }
}
