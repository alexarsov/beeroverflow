using BeerOverflow.Services.DTOs;
using BeerOverflow.Web.Models;

namespace BeerOverflow.Web.WebMappers
{
    public static class BanUserWebMapper
    {
        public static BanViewModel MapToBanVM(this BanDTO banDTO)
        {
            var banVM = new BanViewModel
            {
                UserId = banDTO.UserId,
                Description = banDTO.Description,
                ExpiresOn = banDTO.ExpiresOn
            };

            return banVM;
        }

        public static BanDTO MapToBanDTO(this BanViewModel banVM)
        {
            var banDTO = new BanDTO
            {
                UserId = banVM.UserId,
                Description = banVM.Description,
                ExpiresOn = banVM.ExpiresOn
            };

            return banDTO;
        }
    }
}
