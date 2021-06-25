﻿using System;

namespace BeerOverflow.Data.Entities.AbstractClass
{
    public abstract class Entity
    {
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; } 
        public bool IsDeleted { get; set; }
    }
}
