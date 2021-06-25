using BeerOverflow.Services.Services.Main_Services;
using BeerOverflow.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace BeerOverflow.Web.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            try
            {
                var user = await this.userService.GetUserAsync(id);

                return Ok(user);
            }

            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllUsersApi()
        {
            try
            {
                var user = await this.userService.GetAllValidUsersAsync();

                return Ok(user);
            }

            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserDTO userDTO)
        {
            try
            {
                await this.userService.CreateUserAsync(userDTO);

                return Ok();
            }

            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync(Guid id, [FromBody] UserDTO userDTO)
        {
            if (id == Guid.Empty || userDTO == null)
            {
                return BadRequest();
            }

            await this.userService.UpdateUserAsync(id, userDTO);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(Guid id)

        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            await this.userService.DeleteUserAsync(id);

            return Ok();
        }
    }
}
