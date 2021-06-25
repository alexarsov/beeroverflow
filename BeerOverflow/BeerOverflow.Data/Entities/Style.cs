using System.ComponentModel.DataAnnotations.Schema;
using BeerOverflow.Data.Entities.AbstractClass;
using System.Collections.Generic;
using System;

namespace BeerOverflow.Data.Entities
{
    public class Style : Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Beer> BeerLists { get; set; } = new List<Beer>();
    }
}
