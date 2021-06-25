using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestBeerOverflow
{
    public class BeerOverflowUtils
    {
        public static readonly Guid BulgariaId = Guid.NewGuid();
        public static readonly Guid GermanyId = Guid.NewGuid();
        public static readonly Guid CroatiaId = Guid.NewGuid();
        public static readonly Guid TuborgADId = Guid.NewGuid();
        public static readonly Guid KamenitzaADId = Guid.NewGuid();
        public static readonly Guid HeinekenADId = Guid.NewGuid();
        public static readonly Guid StaropramenADId = Guid.NewGuid();
        public static readonly Guid PeshoId = Guid.NewGuid();
        public static readonly Guid BaniId = Guid.NewGuid();
        public static readonly Guid YaniId = Guid.NewGuid();
        public static readonly Guid IvchoId = Guid.NewGuid();
        public static readonly Guid PremiumLightStyleId = Guid.NewGuid();
        public static readonly Guid GreenStyleId = Guid.NewGuid();
        public static readonly Guid DarkStyleId = Guid.NewGuid();
        public static readonly Guid TuborgId = Guid.NewGuid();
        public static readonly Guid KamenitzaId = Guid.NewGuid();
        public static readonly Guid HeinekenId = Guid.NewGuid();
        public static readonly Guid WishTuborgId = Guid.NewGuid();
        public static readonly Guid WishHeinekenId = Guid.NewGuid();
        public static readonly Guid DrankTuborgId = Guid.NewGuid();
        public static readonly Guid DrankHeinekenId = Guid.NewGuid();

        public static DbContextOptions<BeerOverflowContext> GetOptions(string nameOfDb)
        {
            return new DbContextOptionsBuilder<BeerOverflowContext>()
                .UseInMemoryDatabase(databaseName: nameOfDb)
                .Options;
        }
        public static void Seed(BeerOverflowContext context)
        {

            var countries = new[] {
                 new Country
               {
                   Id = BulgariaId, // Unique Id
                   Name = "Bulgaria"
               },

               new Country
               {
                   Id = GermanyId, // Unique Id
                   Name = "Germany"
               },
               new Country
               {
                   Id = CroatiaId, // Unique Id
                   IsDeleted = true,
                   Name = "Croatia"
               }
            };
            var styles = new[] {
                 new Style
               {
                   Id = PremiumLightStyleId, // Unique Id
                   Name = "Premium Light",
               },

               new Style
               {
                   Id = GreenStyleId, // Unique Id
                   Name = "Green",
               },
                new Style
               {
                   Id = DarkStyleId, // Unique Id
                   IsDeleted = true,
                   Name = "Dark",
               }
            };
            var breweries = new[] {
                new Brewery
               {
                   Id = KamenitzaADId, // Unique Id
                   Name = "KamenitzaAD",
                   CountryId = BulgariaId // the same as Bulgaria Id
               },

               new Brewery
               {
                   Id = TuborgADId, // Unique Id
                   Name = "TuborgAD",
                   CountryId = GermanyId // The same as Germany Id
               },
               new Brewery
               {
                   Id = HeinekenADId, // Unique Id
                   Name = "HeinekenAD",
                   CountryId = GermanyId, // The same as Germany Id
                   IsDeleted = true,
               }
            };
            var users = new[] {
                new User
                {
                    Id = PeshoId,
                    Email = "Pesho@qwe.com"
                },
                new User
                {
                    Id = YaniId,
                    Email = "Yani@qwe.com"
                },
                new User
                {
                    Id = IvchoId,
                    IsDeleted = true,
                    Email = "Ivcho@qwe.com"
                },
                 new User
                {
                    Id = BaniId,
                    Email = "Bani@qwe.com"
                }
            };
            var beers = new[]{
                new Beer
              {
                  Id = TuborgId,
                  Name = "Tuborg",
                  CountryId = GermanyId, // The same as Germany Country Id
                  StyleId = PremiumLightStyleId, // The same as Style Id
                  BreweryId = TuborgADId, // The same as Karlsberg
                  ABV = 4.8,
              },
                new Beer
              {
                  Id = HeinekenId,
                  Name = "Heineken",
                  CountryId = GermanyId, // The same as Germany Country Id
                  StyleId = PremiumLightStyleId, // The same as Style Id
                  BreweryId = HeinekenADId, // The same as Karlsberg
                  ABV = 4.8,
                  IsDeleted = true
              },
                new Beer
              {
                  Id = KamenitzaId,
                  Name = "Kamenitza",
                  CountryId = BulgariaId, // The same as Bulgaria Country Id
                  StyleId = PremiumLightStyleId, // The same as Style Id
                  BreweryId = KamenitzaADId, // The same as Zagorka AD
                  ABV = 5.2
              }
            };

            var reviews = new[] {
                new Review
                {
                    BeerId = KamenitzaId,
                    UserId = PeshoId,
                    Rating = 3,
                    Text = "Its a nice beer!",
                    Like = true,
                },
                new Review
                {
                    BeerId = KamenitzaId,
                    UserId = YaniId,
                    Rating = 3,
                    Text = "Its a very nice beer!",
                    Like = true,
                    IsFlagged = true
                },
                new Review
                {
                    BeerId = HeinekenId,
                    UserId = YaniId,
                    Rating = 2,
                    Text = "Try Tuborg!",
                    Like = false,
                }
            };
            var wishList = new[] {
                new UserWishBeer
                {
                  Id =  WishTuborgId,
                  BeerId = TuborgId,
                  UserId = YaniId
                },
                 new UserWishBeer
                {
                  Id =  WishTuborgId,
                  BeerId = TuborgId,
                  UserId = PeshoId
                },
                 new UserWishBeer
                 {
                     Id =  WishHeinekenId,
                     BeerId = HeinekenId,
                     UserId = PeshoId
                 },
            };
            var drankList = new[] {
                new UserDrankBeer
                {
                  Id =  DrankTuborgId,
                  BeerId = TuborgId,
                  UserId = YaniId
                },
                 new UserDrankBeer
                {
                  Id =  DrankTuborgId,
                  BeerId = TuborgId,
                  UserId = PeshoId
                },
                 new UserDrankBeer
                 {
                     Id =  DrankHeinekenId,
                     BeerId = HeinekenId,
                     UserId = PeshoId
                 },
            };
            var bans = new[]
            {
                new Ban
                {
                    UserId = BaniId,
                    Description = "Verbal abuse",
                    ExpiresOn = DateTime.Today.AddDays(2),
                },
            };
            context.Countries.AddRange(countries);
            context.Styles.AddRange(styles);
            context.Breweries.AddRange(breweries);
            context.Beers.AddRange(beers);
            context.Users.AddRange(users);
            context.Reviews.AddRange(reviews);
            context.WishLists.AddRange(wishList);
            context.DrankLists.AddRange(drankList);
            context.Bans.AddRange(bans);

            context.SaveChanges();
        }
    }
}
