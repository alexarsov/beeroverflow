using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.Mappers;
using Microsoft.EntityFrameworkCore;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace BeerOverflow.Services.Services.Main_Services
{
    public class UserService : IUserService
    {
        private readonly BeerOverflowContext context;
        private readonly IWishListService wishListService;
        private readonly IDrankListService drankListService;
        public UserService(BeerOverflowContext context,
            IWishListService wishListService, IDrankListService drankListService)
        {
            this.context = context;
            this.wishListService = wishListService;
            this.drankListService = drankListService;
        }
        public async Task<UserDTO> GetUserAsync(Guid id)
        {
            var user = await context.Users
                .Include(x => x.Bans)
                .FirstOrDefaultAsync(u => u.Id == id 
                && u.IsDeleted == false);

            if (user == null)
            {
                throw new ArgumentException();
            }
            return user.ToDTO();

        }
        //public async Task<UserDTO> GetUserAsync(string Name)
        //{
        //    var user = await context.Users
        //        .Include(x => x.Bans)
        //        .FirstOrDefaultAsync(u => u.Name == Name && u.IsDeleted == false);
        //    if (user == null)
        //    {
        //        throw new ArgumentException();
        //    }
        //    return user.ToDTO();

        //}
        public async Task<IEnumerable<UserDTO>> GetAllValidUsersAsync()
        {
            var users = await context.Users
                .Include(x => x.Bans)
                .Where(u => u.IsDeleted == false).ToArrayAsync();
            var userDTOs = users.Where(u => u.IsBaned == false)
                .Select(u => u.ToDTO());
            return userDTOs;
        }
        public async Task CreateUserAsync(UserDTO userDTO)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Email == userDTO.Email);
            if (user == null)
            {
                user = new User();
                user.TakeInfoFrom(userDTO);
                _ = await this.context.Users.AddAsync(user);
            }
            else if (user.IsDeleted == true)
            {
                user.TakeInfoFrom(userDTO);
                user.IsDeleted = false;
            }
            else
            {
                throw new ArgumentException();
            }
            _ = await this.context.SaveChangesAsync();
        }
        public async Task UpdateUserAsync(Guid id, UserDTO userDTO)
        {
            var user = await this.context.Users
                .Include(x => x.Bans)
                .FirstOrDefaultAsync(u => u.Id == id && u.IsDeleted == false);
            if (user == null)
            {
                throw new ArgumentNullException();
            }
            user.TakeInfoFrom(userDTO);
            _ = await this.context.SaveChangesAsync();
        }
        public async Task<UserDTO> GetUserByEmail(string email) 
        {
            var user = await context.Users
                .Include(x => x.Bans)
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                throw new ArgumentException();
            }
            return user.ToDTO();
        }
        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await this.context.Users
                .Include(x => x.UserWishBeers)
                .Include(x => x.UserDrankBeers)
                .FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return false;
            }
            user.IsDeleted = true;
            await wishListService.RemoveUserWishListAsync(id);
            await drankListService.RemoveUserDrankListAsync(id);
            await this.context.SaveChangesAsync();

            return true;
        }
    }
}
