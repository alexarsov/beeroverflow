using BeerOverflow.Services.DTOs;
using BeerOverflow.Web.Models;

namespace BeerOverflow.Web.WebMappers
{
    public static class CountryWebMapper
    {
        public static CountryViewModel MapToCountryVM(this CountryDTO countryDTO)
        {
            var countryVM = new CountryViewModel
            {
                Id = countryDTO.Id,
                Name = countryDTO.Name,
                CreatedOn = countryDTO.CreatedOn
            };

            return countryVM;
        }

        public static CountryDTO MapToCountryDTO(this CountryViewModel countryVM)
        {
            var countryDTO = new CountryDTO
            {
                Id = countryVM.Id,
                Name = countryVM.Name,
                CreatedOn = countryVM.CreatedOn
            };

            return countryDTO;
        }
    }
}
