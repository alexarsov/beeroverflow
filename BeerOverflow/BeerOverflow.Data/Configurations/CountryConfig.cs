using BeerOverflow.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerOverflow.Data.Configurations
{
    class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            // Primary Key
            builder.HasKey(key => key.Id);

            // Required fields
            builder.Property(brewery => brewery.Name).IsRequired();
        }
    }
}
