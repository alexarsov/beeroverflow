using BeerOverflow.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Data.Configurations
{
    public class VoteConfig : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            // Composition keys
            builder.HasKey(key => key.Id);

            //TODO: add relation with user

            builder.HasOne(v => v.User)
               .WithMany(u => u.Votes)
               .HasForeignKey(v => v.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(v => v.Review)
                .WithMany(r => r.Votes)
                .HasForeignKey(v => v.ReviewId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
