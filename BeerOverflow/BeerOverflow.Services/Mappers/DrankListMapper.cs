using System;

namespace BeerOverflow.Services.Mappers
{
    public class DrankListDTO
    {
        public string UserName { get; set; }
        public string BeerName { get; set; }
        public Guid UserId { get; set; }
        public Guid BeerId { get; set; }
    }
}
