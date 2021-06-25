using BeerOverflow.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using BeerOverflow.Services.Contracts;

namespace BeerOverflow.Services.Services.Main_Services
{
    public interface IUserService
    {
        Task CreateUserAsync(UserDTO userDTO);
        Task<bool> DeleteUserAsync(Guid id);
        Task<IEnumerable<UserDTO>> GetAllValidUsersAsync();
        Task<UserDTO> GetUserAsync(Guid id);
        Task UpdateUserAsync(Guid id, UserDTO userDTO);
        Task<UserDTO> GetUserByEmail(string email);
    }
}