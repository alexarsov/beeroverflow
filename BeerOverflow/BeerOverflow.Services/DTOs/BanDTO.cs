using BeerOverflow.Data.Entities;
using System;

namespace BeerOverflow.Services.DTOs
{
    public class BanDTO
    {
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime ExpiresOn { get; set; }
        public bool HasExpired { get => (this.ExpiresOn < DateTime.UtcNow) ? true : false; } 
    }
}
