using BeerOverflow.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.DTOs
{
    public class WishListDTO
    {
        public string UserName { get; set; }
        public string BeerName { get; set; }
        public Guid UserId { get; set; }
        public Guid BeerId { get; set; }
    }
}
