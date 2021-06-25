using BeerOverflow.Data.Entities;
using BeerOverflow.Services.DTOs;

namespace BeerOverflow.Services.Mappers
{
    public static class CountryMapper
    {
        public static CountryDTO ToDTO(this Country country)
        {
            var countryDTO = new CountryDTO()
            {
                Id = country.Id,
                Name = country.Name,

                CreatedOn = country.CreatedOn,
                ModifiedOn = country.ModifiedOn
            };

            return countryDTO;
        }

        public static Country ToModel(this CountryDTO countryDTO)
        {
            var country = new Country()
            {
                Id = countryDTO.Id,
                Name = countryDTO.Name,
            };

            return country;
        }    
    }
}
