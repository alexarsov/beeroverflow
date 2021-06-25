using Microsoft.EntityFrameworkCore;
using BeerOverflow.Data.Entities;
using System;
using Microsoft.AspNetCore.Identity;

public static class ModelBuilderExtension
{
    public static void Seeder(this ModelBuilder builder)
    {
        var hasher = new PasswordHasher<User>();
        builder.Entity<Country>().HasData // Country
            (
               new Country
               {
                   Id = Guid.Parse("0bab8f8f-0400-4573-9ddc-35850d47cb94"), // Unique Id
                   Name = "Bulgaria",
                   CreatedOn = DateTime.UtcNow
               },

               new Country
               {
                   Id = Guid.Parse("0e03d656-60cc-476b-9c4a-e12d771dbd62"), // Unique Id
                   Name = "Germany",
                   CreatedOn = DateTime.UtcNow
               },

               new Country
               {
                   Id = Guid.Parse("29473585-5e82-4cfc-844e-0c371a6690d6"), // Unique Id
                   Name = "Sweden",
                   CreatedOn = DateTime.UtcNow
               },

               new Country
               {
                   Id = Guid.Parse("7d4928db-2eb4-4cb9-9372-2a8cb8871615"), // Unique Id
                   Name = "England",
                   CreatedOn = DateTime.UtcNow
               },

               new Country
               {
                   Id = Guid.Parse("917bf455-9b03-41f3-923b-65b65983f916"), // Unique Id
                   Name = "Italy",
                   CreatedOn = DateTime.UtcNow
               },

               new Country
               {
                   Id = Guid.Parse("940ce711-c272-46bd-9aa4-9cf64cfd7d3a"), // Unique Id
                   Name = "France",
                   CreatedOn = DateTime.UtcNow
               },

               new Country
               {
                   Id = Guid.Parse("217193b7-0dc9-4ffa-a161-9cba9c8fbccb"), // Unique Id
                   Name = "Finland",
                   CreatedOn = DateTime.UtcNow
               },

               new Country
               {
                   Id = Guid.Parse("70a47634-234c-4105-b464-9cf3d7043b44"), // Unique Id
                   Name = "Denmark",
                   CreatedOn = DateTime.UtcNow
               },

               new Country
               {
                   Id = Guid.Parse("177cb837-9acd-4adc-85e7-983156b77189"), // Unique Id
                   Name = "Cuba",
                   CreatedOn = DateTime.UtcNow
               }
            );


        builder.Entity<Brewery>().HasData // Brewery
          (
               new Brewery
               {
                   Id = Guid.Parse("1aee9ea3-390a-4582-ac37-7a6020ec1553"), // Unique Id
                   Name = "Zagorka AD",
                   CountryId = Guid.Parse("0bab8f8f-0400-4573-9ddc-35850d47cb94"),
                   CreatedOn = DateTime.UtcNow // the same as Bulgaria Id
               },

               new Brewery
               {
                   Id = Guid.Parse("66dae4ad-753d-4170-90a7-5d58756b757f"), // Unique Id
                   Name = "Karlsberg",
                   CountryId = Guid.Parse("0e03d656-60cc-476b-9c4a-e12d771dbd62"),
                   CreatedOn = DateTime.UtcNow// The same as Germany Id
               },

               new Brewery
               {
                   Id = Guid.Parse("52547555-abb7-425a-9818-7eadf0d90e8b"), // Unique Id
                   Name = "Klackabacken",
                   CountryId = Guid.Parse("29473585-5e82-4cfc-844e-0c371a6690d6"),
                   CreatedOn = DateTime.UtcNow // The same as Sweden Id
               },

               new Brewery
               {
                   Id = Guid.Parse("4a3757a9-41bc-4f3c-a5b4-7765aa38fac4"), // Unique Id
                   Name = "Mad Squirrel",
                   CountryId = Guid.Parse("7d4928db-2eb4-4cb9-9372-2a8cb8871615"),
                   CreatedOn = DateTime.UtcNow // the same as England Id
               },

               new Brewery
               {
                   Id = Guid.Parse("551e3fa1-4d24-420d-8058-d3dd4118f500"), // Unique Id
                   Name = "Klanbarrique",
                   CountryId = Guid.Parse("917bf455-9b03-41f3-923b-65b65983f916"),
                   CreatedOn = DateTime.UtcNow // The same as Italy Id
               },

               new Brewery
               {
                   Id = Guid.Parse("e77ba42b-d8b0-41d9-ba13-98cba75ce8bc"), // Unique Id
                   Name = "Le Père Jules",
                   CountryId = Guid.Parse("940ce711-c272-46bd-9aa4-9cf64cfd7d3a"),
                   CreatedOn = DateTime.UtcNow // The same as France Id
               },

               new Brewery
               {
                   Id = Guid.Parse("18112ada-2fc5-41e1-8917-6ebfd4c4a0b7"), // Unique Id
                   Name = "CoolHead Brew",
                   CountryId = Guid.Parse("217193b7-0dc9-4ffa-a161-9cba9c8fbccb"),
                   CreatedOn = DateTime.UtcNow // the same as Finland Id
               },

               new Brewery
               {
                   Id = Guid.Parse("16e01b0a-827e-45af-bcc8-ccf753f4d462"), // Unique Id
                   Name = "Masis Brewery",
                   CountryId = Guid.Parse("70a47634-234c-4105-b464-9cf3d7043b44"),
                   CreatedOn = DateTime.UtcNow // the same as Denmark Id
               },

               new Brewery
               {
                   Id = Guid.Parse("f5da3b48-59d6-46d9-b407-5f7d376285e2"), // Unique Id
                   Name = "Maistila",
                   CountryId = Guid.Parse("177cb837-9acd-4adc-85e7-983156b77189"),
                   CreatedOn = DateTime.UtcNow // the same as Cuba Id
               }
          );


        builder.Entity<Style>().HasData // Style
            (
               new Style
               {
                   Id = Guid.Parse("0db937ea-3513-4ce7-b3f6-80ae7474bef2"), // Unique Id
                   Name = "Premium Light",
                   CreatedOn = DateTime.UtcNow
               },

               new Style
               {
                   Id = Guid.Parse("0e679a3c-5555-4a27-b0fa-594fba01ed68"), // Unique Id
                   Name = "Green",
                   CreatedOn = DateTime.UtcNow
               },

               new Style
               {
                   Id = Guid.Parse("20d79115-03e0-4123-8994-b0f2ceb45ca8"), // Unique Id
                   Name = "Lager",
                   CreatedOn = DateTime.UtcNow
               },

               new Style
               {
                   Id = Guid.Parse("953d28bf-c7f4-4824-ada9-b67d4256c28c"), // Unique Id
                   Name = "Traditional Ale",
                   CreatedOn = DateTime.UtcNow
               },

               new Style
               {
                   Id = Guid.Parse("44fdbf01-64b7-4869-ba2f-84290f10bc1f"), // Unique Id
                   Name = "Lager - Dark",
                   CreatedOn = DateTime.UtcNow
               },

               new Style
               {
                   Id = Guid.Parse("4ae1546e-9cc2-4f52-88f8-86077ae4bd36"), // Unique Id
                   Name = "Winter Warmer",
                   CreatedOn = DateTime.UtcNow
               },

               new Style
               {
                   Id = Guid.Parse("32bd8b79-eac4-456c-b87d-0bed55087031"), // Unique Id
                   Name = "Lager - Euro Dark",
                   CreatedOn = DateTime.UtcNow
               },

               new Style
               {
                   Id = Guid.Parse("e589fadb-0cda-4397-9301-f14e0fb7832b"), // Unique Id
                   Name = "Old Ale",
                   CreatedOn = DateTime.UtcNow
               },

               new Style
               {
                   Id = Guid.Parse("72e7e09e-2640-4db2-910a-84c1401f4c26"), // Unique Id
                   Name = "Porter - Baltic",
                   CreatedOn = DateTime.UtcNow
               }
         );

        builder.Entity<Beer>().HasData
            (
              new Beer
              {
                  Id = Guid.Parse("e23347c0-3a21-4f50-9d5c-c46253ee0715"),
                  Name = "Heineken",
                  CountryId = Guid.Parse("0bab8f8f-0400-4573-9ddc-35850d47cb94"), // The same as Bulgaria Country Id
                  StyleId = Guid.Parse("0db937ea-3513-4ce7-b3f6-80ae7474bef2"), // The same as Style Id
                  BreweryId = Guid.Parse("1aee9ea3-390a-4582-ac37-7a6020ec1553"), // The same as Zagorka AD
                  ABV = 5.2,
                  CreatedOn = DateTime.UtcNow
              },

              new Beer
              {
                  Id = Guid.Parse("6f6bd8b0-a68e-4409-bcda-15dbe334a26d"),
                  Name = "Tuborg",
                  CountryId = Guid.Parse("0bab8f8f-0400-4573-9ddc-35850d47cb94"), // The same as Germany Country Id
                  StyleId = Guid.Parse("0e679a3c-5555-4a27-b0fa-594fba01ed68"), // The same as Style Id
                  BreweryId = Guid.Parse("66dae4ad-753d-4170-90a7-5d58756b757f"), // The same as Karlsberg
                  ABV = 4.8,
                  CreatedOn = DateTime.UtcNow
              },

              new Beer
              {
                  Id = Guid.Parse("3efd593f-c900-4b05-80dc-e580a07bb7d2"),
                  Name = "Omnipollo Selassie",
                  CountryId = Guid.Parse("29473585-5e82-4cfc-844e-0c371a6690d6"), // The same as Sweden Country Id
                  StyleId = Guid.Parse("20d79115-03e0-4123-8994-b0f2ceb45ca8"), // The same as Style Id
                  BreweryId = Guid.Parse("52547555-abb7-425a-9818-7eadf0d90e8b"), // The same as Klackabacken
                  ABV = 4.3,
                  CreatedOn = DateTime.UtcNow
              },

              new Beer
              {
                  Id = Guid.Parse("bdbfa744-0f6c-4fd2-99cf-8867fb4b4b92"),
                  Name = "King Henry",
                  CountryId = Guid.Parse("7d4928db-2eb4-4cb9-9372-2a8cb8871615"), // The same as England Country Id
                  StyleId = Guid.Parse("953d28bf-c7f4-4824-ada9-b67d4256c28c"), // The same as Style Id
                  BreweryId = Guid.Parse("4a3757a9-41bc-4f3c-a5b4-7765aa38fac4"),
                  ABV = 7.8,
                  CreatedOn = DateTime.UtcNow
              },

              new Beer
              {
                  Id = Guid.Parse("1f6a31a3-b955-4190-b961-bd2b105e5103"),
                  Name = "Hardcore Mælk",
                  CountryId = Guid.Parse("917bf455-9b03-41f3-923b-65b65983f916"), // The same as Italy Country Id
                  StyleId = Guid.Parse("44fdbf01-64b7-4869-ba2f-84290f10bc1f"), // The same as Style Id
                  BreweryId = Guid.Parse("551e3fa1-4d24-420d-8058-d3dd4118f500"),
                  ABV = 5.5,
                  CreatedOn = DateTime.UtcNow
              },

              new Beer
              {
                  Id = Guid.Parse("6b99474b-00bd-42ed-8a46-48dc16f94ff8"),
                  Name = "Bière de Garde",
                  CountryId = Guid.Parse("940ce711-c272-46bd-9aa4-9cf64cfd7d3a"), // The same as France Country Id
                  StyleId = Guid.Parse("4ae1546e-9cc2-4f52-88f8-86077ae4bd36"), // The same as Style Id
                  BreweryId = Guid.Parse("e77ba42b-d8b0-41d9-ba13-98cba75ce8bc"),
                  ABV = 6.6,
                  CreatedOn = DateTime.UtcNow
              },

              new Beer
              {
                  Id = Guid.Parse("55742482-9d52-4272-92b6-60b5c417b924"),
                  Name = "Rye Beer",
                  CountryId = Guid.Parse("217193b7-0dc9-4ffa-a161-9cba9c8fbccb"),
                  StyleId = Guid.Parse("32bd8b79-eac4-456c-b87d-0bed55087031"),
                  BreweryId = Guid.Parse("18112ada-2fc5-41e1-8917-6ebfd4c4a0b7"),
                  ABV = 5.6,
                  CreatedOn = DateTime.UtcNow
              },

              new Beer
              {
                  Id = Guid.Parse("72bb2fe8-9b56-4bef-8941-e986b806ce98"),
                  Name = "Inverno",
                  CountryId = Guid.Parse("70a47634-234c-4105-b464-9cf3d7043b44"),
                  StyleId = Guid.Parse("e589fadb-0cda-4397-9301-f14e0fb7832b"),
                  BreweryId = Guid.Parse("16e01b0a-827e-45af-bcc8-ccf753f4d462"),
                  ABV = 12.6,
                  CreatedOn = DateTime.UtcNow
              },

               new Beer
               {
                   Id = Guid.Parse("db092ea6-2f6e-4c14-96f2-29cff514029b"),
                   Name = "Quiet Riot",
                   CountryId = Guid.Parse("177cb837-9acd-4adc-85e7-983156b77189"),
                   StyleId = Guid.Parse("72e7e09e-2640-4db2-910a-84c1401f4c26"),
                   BreweryId = Guid.Parse("f5da3b48-59d6-46d9-b407-5f7d376285e2"),
                   ABV = 7.1,
                   CreatedOn = DateTime.UtcNow
               }
           );
                   
        
        //Role
        builder.Entity<Role>().HasData(
             new Role { Id = Guid.Parse("CDDE12B9-E61A-4748-A239-C7331B4FB6A8"), Name = "Admin", NormalizedName = "ADMIN" },
             new Role { Id = Guid.Parse("43A08CC4-76AE-46D8-9E2C-CDE7B0479146"), Name = "Member", NormalizedName = "MEMBER" }
         );

        //Admin Account

        User adminUser = new User
        {
            Id = Guid.Parse("AEA4F481-DF4B-4272-9D12-022293D98E48"),
            UserName = "stacktrace@bo.net",
            NormalizedUserName = "STACKTRACE@BO.NET",
            Email = "stacktrace@bo.net",
            NormalizedEmail = "STACKTRACE@BO.NET",
            CreatedOn = DateTime.UtcNow,
            LockoutEnabled = true,
            SecurityStamp = "DC6E275DD1E24957A7781D42BB68293B"
        };
        
        adminUser.PasswordHash = hasher.HashPassword(adminUser, "stack1");

        
        builder.Entity<User>().HasData(adminUser);
        

        builder.Entity<IdentityUserRole<Guid>>().HasData(
            new IdentityUserRole<Guid>
            {
                RoleId = Guid.Parse("CDDE12B9-E61A-4748-A239-C7331B4FB6A8"),
                UserId = adminUser.Id
            });
    }
}
