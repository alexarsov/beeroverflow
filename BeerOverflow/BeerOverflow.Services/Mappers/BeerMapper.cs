using BeerOverflow.Data.Entities;
using BeerOverflow.Services.DTOs;
using System.Linq;

namespace BeerOverflow.Services.Mappers
{
    public static class BeerMapper
    {
        public static BeerDTO ToDTO(this Beer beer)
        {
            var comments = beer.ReviewList.Where(r => r.BeerId == beer.Id).Select(t => t.Text).ToArray();
            var raitingsList = beer.ReviewList.Where(r => r.BeerId == beer.Id).Select(r => r.Rating).ToArray();
            var likes = beer.ReviewList.Where(r => r.BeerId == beer.Id).Count(r => r.Like ==true);
            var userNames = beer.ReviewList.Where(r => r.BeerId == beer.Id).Select(r => r.User.Email).ToArray();
            var beerDTO = new BeerDTO
            {
                Id = beer.Id,
                Name = beer.Name,
                StyleId = beer.StyleId,
                CountryId = beer.CountryId,
                BreweryId = beer.BreweryId,
                StyleName = beer.Style.Name,
                Comments = comments,     
                UserNames = userNames,
                Likes = likes,
                CountryName = beer.Country.Name,
                BreweryName = beer.Brewery.Name,
                Rating = (raitingsList.Length == 0 ? 0 : raitingsList.Average()),
                ABV = beer.ABV,

                CreatedOn = beer.CreatedOn,
                ModifiedOn = beer.ModifiedOn
            };

            return beerDTO;
        }

        public static Beer TakeInfoFrom(this Beer beer, BeerDTO beerDto)
        {
            beer.Id = beerDto.Id;
            beer.Name = beerDto.Name;
            beer.StyleId = beerDto.StyleId;
            beer.CountryId = beerDto.CountryId;
            beer.BreweryId = beerDto.BreweryId;
            beer.ABV = beerDto.ABV;

            return beer;
        }
    }
}
