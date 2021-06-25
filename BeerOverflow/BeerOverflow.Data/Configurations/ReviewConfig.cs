using BeerOverflow.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerOverflow.Data.Configurations
{
    public class ReviewConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            // Primary Key
            builder.HasKey(key => key.Id);

            // No Required fields

            // Relations
            builder.HasOne(review => review.User)
                   .WithMany(user => user.ReviewList)
                   .HasForeignKey(key => key.UserId);

            builder.HasOne(review => review.Beer)
                   .WithMany(Beer => Beer.ReviewList)
                   .HasForeignKey(key => key.BeerId);
        }
    }
}
