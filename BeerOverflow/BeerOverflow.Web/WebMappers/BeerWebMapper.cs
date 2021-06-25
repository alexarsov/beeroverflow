using BeerOverflow.Services.DTOs;
using BeerOverflow.Web.Models;
using System.Linq;

namespace BeerOverflow.Web.WebMappers
{
    public static class BeerWebMapper
    {
        public static BeerViewModel MapToBeerVM(this BeerDTO beerDTO)
        {
            var beerVM = new BeerViewModel
            {
                Id = beerDTO.Id,
                Name = beerDTO.Name,
                StyleId = beerDTO.StyleId,
                CountryId = beerDTO.CountryId,
                BreweryId = beerDTO.BreweryId,
                StyleName = beerDTO.StyleName,
                Rating = beerDTO.Rating,
                Likes = beerDTO.Likes,
                UserNames = beerDTO.UserNames.ToList(),
                CountryName = beerDTO.CountryName,
                BreweryName = beerDTO.BreweryName,
                ABV = beerDTO.ABV,
                Comments = beerDTO.Comments.ToList(),
                CreatedOn = beerDTO.CreatedOn,
                ModifiedOn = beerDTO.ModifiedOn
            };

            return beerVM;
        }

        public static BeerDTO MapToBeerDTO(this BeerViewModel beerVM)
        {
            var beerDTO = new BeerDTO
            {
                Id = beerVM.Id,
                Name = beerVM.Name,
                StyleId = beerVM.StyleId,
                CountryId = beerVM.CountryId,
                BreweryId = beerVM.BreweryId,
    
                ABV = beerVM.ABV,

                CreatedOn = beerVM.CreatedOn,
                ModifiedOn = beerVM.ModifiedOn
            };

            return beerDTO;
        }
    }
}
