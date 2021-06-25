using System.ComponentModel.DataAnnotations.Schema;
using BeerOverflow.Data.Entities.AbstractClass;
using System.Collections.Generic;
using System;

namespace BeerOverflow.Data.Entities
{
    public class Brewery : Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<Beer> Beers { get; set; } = new List<Beer>();
    }
}
