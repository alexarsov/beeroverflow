using BeerOverflow.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace BeerOverflow.Services.Contracts
{
    public interface IDrankListService
    {
        public Task<bool> AddBeerToDrankListAsync(Guid beerId, Guid userId);
        public Task<ICollection<BeerDTO>> GetUserDrankListAsync(Guid userId);
        public Task<bool> RemoveBeerFromDrankListAsync(Guid beerId, Guid userId);
        public Task<bool> RemoveUserDrankListAsync(Guid userId); 
    }
}