using BeerOverflow.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerOverflow.Data
{
    public class UserDrankBeerConfig : IEntityTypeConfiguration<UserDrankBeer>
    {
        public void Configure(EntityTypeBuilder<UserDrankBeer> builder)
        {
            // Composition keys
            builder.HasKey(x => new { x.UserId, x.BeerId });

            builder.HasOne(d => d.User)
                   .WithMany(u => u.UserDrankBeers)
                   .HasForeignKey(d => d.UserId);

            builder.HasOne(d => d.Beer)
                .WithMany(b => b.UserDrankBeers)
                .HasForeignKey(d => d.BeerId);
        }
    }
}

