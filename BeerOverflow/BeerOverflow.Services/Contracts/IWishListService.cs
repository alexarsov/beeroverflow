using BeerOverflow.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerOverflow.Services.Contracts
{
    public interface IWishListService
    {
        Task<bool> AddBeerToWishListAsync(Guid beerId, Guid userId);
        Task<ICollection<BeerDTO>> GetUserWishListAsync(Guid userId);
        Task<bool> RemoveBeerFromWishListAsync(Guid beerId, Guid userId);
        Task<bool> RemoveUserWishListAsync(Guid userId);
    }
}