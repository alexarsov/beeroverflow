using BeerOverflow.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerOverflow.Data.Configurations
{
    public class UserWishBeerConfig : IEntityTypeConfiguration<UserWishBeer>
    {
        public void Configure(EntityTypeBuilder<UserWishBeer> builder)
        {
            // Composition keys
            builder.HasKey(x => new { x.UserId, x.BeerId });

            builder.HasOne(d => d.User)
                .WithMany(u => u.UserWishBeers)
                .HasForeignKey(d => d.UserId);

            builder.HasOne(d => d.Beer)
                .WithMany(b => b.UserWishBeers)
                .HasForeignKey(d => d.BeerId);
        }
    }
}
