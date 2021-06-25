using BeerOverflow.Data.Entities;
using BeerOverflow.Services.DTOs;

namespace BeerOverflow.Services.Mappers
{
    public static class UserMapper
    {
        public static UserDTO ToDTO(this User user)
        {
            var userDTO = new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                UserDrankBeers = user.UserDrankBeers,
                Bans = user.Bans,
                IsDeleted = user.IsDeleted,
                Comments = user.Comments,
                ReviewList = user.ReviewList,
                UserWishBeers = user.UserWishBeers,
                Votes = user.Votes,
            };
            return userDTO;
        }

        public static User TakeInfoFrom(this User user, UserDTO userDTO)
        {
            user.Email = userDTO.Email;
            user.UserDrankBeers = userDTO.UserDrankBeers;
            user.Bans = userDTO.Bans;
            user.Comments = userDTO.Comments;
            user.ReviewList = userDTO.ReviewList;
            user.UserWishBeers = userDTO.UserWishBeers;
            user.Votes = userDTO.Votes;

            return user;
        }
    }
}
