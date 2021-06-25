using BeerOverflow.Services.DTOs;
using BeerOverflow.Web.Models;

namespace BeerOverflow.Web.WebMappers
{
    public static class BreweryWebMapper
    {
        public static BreweryViewModel MapToBreweryVM(this BreweryDTO breweryDTO)
        {
            var breweryVM = new BreweryViewModel()
            {
                Id = breweryDTO.Id,
                Name = breweryDTO.Name,
                CountryId = breweryDTO.CountryId,
                CountryName = breweryDTO.CountryName,
                CreatedOn = breweryDTO.CreatedOn,
                ModifiedOn = breweryDTO.ModifiedOn
            };

            return breweryVM;
        }

        public static BreweryDTO MapToBreweryDTO(this BreweryViewModel breweryVM)
        {
            var breweryDTO = new BreweryDTO
            {
                Id = breweryVM.Id,
                Name = breweryVM.Name,
                CountryId = breweryVM.CountryId,
                CreatedOn = breweryVM.CreatedOn,
                ModifiedOn = breweryVM.ModifiedOn
            };

            return breweryDTO;
        }
    }
}
