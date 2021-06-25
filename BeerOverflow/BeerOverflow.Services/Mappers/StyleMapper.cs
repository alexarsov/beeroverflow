using BeerOverflow.Data.Entities;
using BeerOverflow.Services.DTOs;

namespace BeerOverflow.Services.Mappers
{
    public static class StyleMapper
    {
        public static StyleDTO ToDTO(this Style style)
        {
            var styleDTO = new StyleDTO()
            {
                Id = style.Id,
                Name = style.Name,

                CreatedOn = style.CreatedOn,
                ModifiedOn = style.ModifiedOn
            };

            return styleDTO;
        }

        public static Style ToModel(this CountryDTO styleDTO)
        {
            var style = new Style()
            {
                Id = styleDTO.Id,
                Name = styleDTO.Name,
            };

            return style;
        }
    }
}
