using BeerOverflow.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerOverflow.Data.Configurations
{
    public class BreweryConfig : IEntityTypeConfiguration<Brewery>
    {
        public void Configure(EntityTypeBuilder<Brewery> builder)
        {
            // Primary Key
            builder.HasKey(brewery => brewery.Id);

            // Required fields
            builder.Property(brewery => brewery.Name).IsRequired();

            // Relations
            builder.HasOne(country => country.Country)
                .WithMany(beer => beer.BreweriesList)
                .HasForeignKey(key => key.CountryId);
        }
    }
}
