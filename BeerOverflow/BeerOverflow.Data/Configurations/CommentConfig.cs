using BeerOverflow.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerOverflow.Data.Configurations
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            // Composition Keys
            builder.HasKey(key => new { key.UserId, key.ReviewId });

            // Required fields
            builder.Property(c => c.Text).IsRequired();

            //Relations
            builder.HasOne(comment => comment.User)
                .WithMany(user => user.Comments)
                .HasForeignKey(key => key.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(comment => comment.Review)
                .WithMany(review => review.Comments)
                .HasForeignKey(key => key.ReviewId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
