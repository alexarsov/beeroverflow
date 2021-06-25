using System;

namespace BeerOverflow.Services.DTOs
{
    public class CountryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }       
    }
}
