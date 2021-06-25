using BeerOverflow.Services.DTOs;
using BeerOverflow.Web.Models;

namespace BeerOverflow.Web.WebMappers
{
    public static class UserWebMapper
    {
        public static UserViewModel MapToUserVM(this UserDTO userDTO)
        {
            var userVM = new UserViewModel
            {
                Id = userDTO.Id,
                Email = userDTO.Email
                
            };

            return userVM;
        }
    }
}
