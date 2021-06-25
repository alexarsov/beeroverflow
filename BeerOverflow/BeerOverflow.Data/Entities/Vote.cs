using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BeerOverflow.Data.Entities
{
    public class Vote
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; } // FK
        public Review Review { get; set; }
        public Guid ReviewId { get; set; } // FK
        public bool? UpVote { get; set; }
    }
}
