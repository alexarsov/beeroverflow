using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerOverflow.Data.Entities
{
    public class Ban
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime ExpiresOn { get; set; }
        public bool HasExpired { get => (this.ExpiresOn < DateTime.UtcNow) ? true : false; }
    }
}

