using BeerOverflow.Services.DTOs;
using BeerOverflow.Web.Models;

namespace BeerOverflow.Web.WebMappers
{
    public static class StyleWebMapper
    {
        public static StyleViewModel MapToStyleVM(this StyleDTO styleDTO)
        {
            var styleVM = new StyleViewModel
            {
                Id = styleDTO.Id,
                Name = styleDTO.Name,
                CreatedOn = styleDTO.CreatedOn
            };

            return styleVM;
        }

        public static StyleDTO MapToStyleDTO(this StyleViewModel styleVM)
        {
            var styleDTO = new StyleDTO
            {
                Id = styleVM.Id,
                Name = styleVM.Name,
                CreatedOn = styleVM.CreatedOn
            };

            return styleDTO;
        }
    }
}
