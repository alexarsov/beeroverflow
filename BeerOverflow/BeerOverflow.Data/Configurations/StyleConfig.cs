using BeerOverflow.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BeerOverflow.Data.Configurations
{
    class StyleConfig : IEntityTypeConfiguration<Style>
    {
        public void Configure(EntityTypeBuilder<Style> builder)
        {
            // Primary Key
            builder.HasKey(key => key.Id);

            // Required fields
            builder.Property(style => style.Name).IsRequired();

            // Relations
            builder.HasMany(style => style.BeerLists)
                   .WithOne(beers => beers.Style)
                   .HasForeignKey(key => key.StyleId);
        }
    }
}
