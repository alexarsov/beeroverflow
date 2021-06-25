using BeerOverflow.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerOverflow.Data.Configurations
{
    public class BeerConfig : IEntityTypeConfiguration<Beer>

    {
        public void Configure(EntityTypeBuilder<Beer> builder)
        {
            // Primary Key
            builder.HasKey(key => key.Id);

            // Required fields //TODO: how it works
            //builder.Property(beer => beer.Name).IsRequired();

            //Relations
            builder.HasOne(beer => beer.Brewery)
                .WithMany(brewery => brewery.Beers)
                .HasForeignKey(key => key.BreweryId);

            builder.HasOne(beer => beer.Country)
                .WithMany(country => country.BeersList)
                .HasForeignKey(key => key.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(beer => beer.Style)
               .WithMany(style => style.BeerLists)
               .HasForeignKey(key => key.StyleId);


        }
    }
}
