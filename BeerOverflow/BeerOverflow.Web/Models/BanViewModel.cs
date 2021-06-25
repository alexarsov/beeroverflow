using System;
using System.ComponentModel.DataAnnotations;

namespace BeerOverflow.Web.Models
{
    public class BanViewModel
    {
        [Required(ErrorMessage = "Description is required!")]
        [MinLength(2, ErrorMessage = "Description must be between 3 and 30 symbols"),
         MaxLength(30, ErrorMessage = "Title must be between 3 and 30 symbols")]
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public DateTime ExpiresOn { get; set; }
        public bool HasExpired { get => (this.ExpiresOn < DateTime.UtcNow) ? true : false; }
    }
}
