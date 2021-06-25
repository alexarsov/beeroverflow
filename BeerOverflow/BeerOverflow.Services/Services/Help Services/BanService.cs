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

namespace BeerOverflow.Services.Services.Help_Services
{
    public class BanService : IBanService
    {
        private readonly BeerOverflowContext context;
        public BanService(BeerOverflowContext context)
        {
            this.context = context;
        }
        public async Task<bool> BanUserAsync(BanDTO banDTO)
        {
            var ban = new Ban
            {
                UserId = banDTO.UserId,
                ExpiresOn = banDTO.ExpiresOn,
                Description = banDTO.Description,
            };
            _ = await context.Bans.AddAsync(ban);
            _ = context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UnbanUserAsync(Guid userId)
        {
            var user = await context.Users.Include(x => x.Bans).FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
            {
                return false;
            }
            foreach (var ban in user.Bans)
            {
                ban.ExpiresOn = DateTime.UtcNow.AddDays(-1);
            }
            _ = context.SaveChangesAsync();
            return true;
        }
        public async Task<ICollection<UserDTO>> GetAllBannedUsersAsync()
        {

            var users = await context.Users.Include(x => x.Bans).ToListAsync();
            foreach (var item in users)
            {
                _ = item.IsBaned;
            }
            var banedUsers = users.Where(x => x.IsBaned);

            return banedUsers.Select(x => x.ToDTO()).ToList();
        }
        public async Task<UserDTO> GetBannedUserAsync(Guid id)
        {
            var bannedUser = await context.Bans
                .Include(b => b.User).ThenInclude(x => x.Bans)
                .FirstOrDefaultAsync(x => x.UserId == id);
            if (bannedUser == null)
            {
                throw new ArgumentNullException();
            }
            if (bannedUser.User.IsBaned == false)
            {
                throw new ArgumentException();
            }
            return bannedUser.User.ToDTO();
        }
        public async Task<bool> IsBannedAsync(Guid userId)
        {
            var bannedUser = await context.Bans
                .FirstOrDefaultAsync(x => x.UserId == userId && x.HasExpired == false);
            if (bannedUser == null)
            {
                return false;
            }
            return true;
        }
    }
}
