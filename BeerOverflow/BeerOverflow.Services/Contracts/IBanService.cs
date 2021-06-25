using BeerOverflow.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace BeerOverflow.Services.Contracts
{
    public interface IBanService
    {
        Task<bool> BanUserAsync(BanDTO banDTO);
        Task<ICollection<UserDTO>> GetAllBannedUsersAsync();
        Task<UserDTO> GetBannedUserAsync(Guid id);
        Task<bool> IsBannedAsync(Guid userId);
        Task<bool> UnbanUserAsync(Guid userId);
    }
}