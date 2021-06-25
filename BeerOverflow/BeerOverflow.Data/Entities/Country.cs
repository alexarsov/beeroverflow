using BeerOverflow.Data.Entities.AbstractClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerOverflow.Data.Entities
{
    public class Country : Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Beer> BeersList { get; set; } = new List<Beer>();
        public ICollection<Brewery> BreweriesList { get; set; } = new List<Brewery>();
    }
}
