using BeerOverflow.Data.Entities.AbstractClass;
using System;

namespace BeerOverflow.Services.DTOs
{
    public class BreweryDTO : Entity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
