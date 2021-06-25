using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.Services.Main_Services;
using BeerOverflow.Web.Models;
using BeerOverflow.Web.WebMappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IBanService banService;

        public UserController(IUserService userService, IBanService banService)
        {
            this.userService = userService;
            this.banService = banService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = (await this.userService.GetAllValidUsersAsync()).Select(x => x.MapToUserVM());
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var user = (await this.userService.GetUserAsync(id)).MapToUserVM();

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(Guid id)
        {
            await this.userService.DeleteUserAsync(id);
            return RedirectToAction("GetAllUsers");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult BanUser()
        {
            var banVM = new BanViewModel();
            return View(banVM);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> BanUser(BanViewModel banVM)
        {
            if (ModelState.IsValid)
            {
                string url = Request.GetDisplayUrl();

                var tokens = url.Split('/');
                var userId = Guid.Parse(tokens[tokens.Length - 1]);
                banVM.UserId = userId;
                banVM.ExpiresOn = DateTime.UtcNow.AddDays(7);
                var ban = await this.banService.BanUserAsync(banVM.MapToBanDTO());
                return RedirectToAction(nameof(GetAllUsers));
            }

            return BadRequest();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult UnbanUser()
        {
            var banVM = new BanViewModel();
            return View(banVM);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UnbanUser(BanViewModel banVM)
        {
            if (ModelState.IsValid)
            {
                string url = Request.GetDisplayUrl();

                var tokens = url.Split('/');
                var userId = Guid.Parse(tokens[tokens.Length - 1]);
                var ban = await this.banService.UnbanUserAsync(userId);
                return RedirectToAction(nameof(GetAllBannedUsers));
            }

            return BadRequest();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllBannedUsers()
        {
            var users = (await banService.GetAllBannedUsersAsync()).Select(x => x.MapToUserVM());

            return View(users);
        }
    }
}
