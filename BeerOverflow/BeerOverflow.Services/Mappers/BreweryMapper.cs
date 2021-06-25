namespace BeerOverflow.Services.Mappers
{
    public static class BreweryMapper
    {
        public static DTOs.BreweryDTO ToDTO(this Data.Entities.Brewery brewery)
        {
            var breweryDTO = new DTOs.BreweryDTO()
            {
                Id = brewery.Id,
                Name = brewery.Name,
                CountryId = brewery.CountryId,
                CountryName = brewery.Country.Name,
                CreatedOn = brewery.CreatedOn,
                ModifiedOn = brewery.ModifiedOn
            };

            return breweryDTO;
        }

        public static Data.Entities.Brewery TakeInfoFrom(this Data.Entities.Brewery brewery, DTOs.BreweryDTO breweryDTO)
        {
            brewery.Id = breweryDTO.Id;
            brewery.Name = breweryDTO.Name;
            brewery.CountryId = breweryDTO.CountryId;

            return brewery;
        }
    }
}
