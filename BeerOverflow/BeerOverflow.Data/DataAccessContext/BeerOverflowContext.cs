using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BeerOverflow.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using BeerOverflow.Data.Entities;
using System;

namespace BeerOverflow.Data.DataAccessContext
{
    public class BeerOverflowContext : IdentityDbContext<User, Role, Guid>
    {
        public BeerOverflowContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<UserWishBeer> WishLists { get; set; }
        public DbSet<Ban> Bans { get; set; }
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brewery> Breweries { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<UserDrankBeer> DrankLists { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Style> Styles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BanConfig());
            builder.ApplyConfiguration(new BeerConfig());
            builder.ApplyConfiguration(new BreweryConfig());
            builder.ApplyConfiguration(new CommentConfig());
            builder.ApplyConfiguration(new CountryConfig());
            builder.ApplyConfiguration(new ReviewConfig());
            builder.ApplyConfiguration(new StyleConfig());
            builder.ApplyConfiguration(new VoteConfig());
            builder.ApplyConfiguration(new UserDrankBeerConfig());
            builder.ApplyConfiguration(new UserWishBeerConfig());

            builder.Seeder();
            base.OnModelCreating(builder);
        }
    }
}
