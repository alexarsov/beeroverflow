using BeerOverflow.Data.Entities;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Services.Mappers.Contracts;

namespace BeerOverflow.Services.Mappers
{
    public class WishListMapper : IDTOMapper<UserWishBeer, WishListDTO>
    {
        public WishListDTO MapFrom(UserWishBeer model)
        {
            return new WishListDTO
            { 
                BeerId = model.BeerId,
                UserId = model.UserId,
                BeerName = model.Beer.Name,
                UserName = model.User.Name,
            };
        }
    }
}
