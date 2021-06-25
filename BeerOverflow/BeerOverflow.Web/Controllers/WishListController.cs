using Microsoft.AspNetCore.Authorization;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Web.WebMappers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using NToastNotify;
using System.Linq;
using System;

namespace BeerOverflow.Web.Controllers
{
    public class WishListController : Controller
    {
        private readonly IWishListService wishListService;
        private readonly IToastNotification _toastNotification;

        public WishListController(IWishListService wishListService, IToastNotification _toastNotification)
        {
            this.wishListService = wishListService;
            this._toastNotification = _toastNotification;
        }

        [Authorize(Roles = "Admin, Member")]
        public async Task<IActionResult> AddBeerToWishList(Guid beerId)
        {
            if (beerId == Guid.Empty)
            {
                throw new ArgumentException();
            }

            var getUser = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.wishListService.AddBeerToWishListAsync(beerId, Guid.Parse(getUser));
            _toastNotification.AddAlertToastMessage("Beer was successfully added to WishList");

            return RedirectToAction("Details", "Beer", new { id = beerId });
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Member")]
        public async Task<IActionResult> GetUserWishList()
        {

            var getUser = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var userWishList = (await this.wishListService.
                GetUserWishListAsync(Guid.Parse(getUser))).
                Select(x => x.MapToBeerVM());

            return View(userWishList);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult RemoveBeerFromWishList()
        {
            return View();
        }

        [HttpPost]
        [HttpPost, ActionName("RemoveBeerFromWishList")]
        [Authorize(Roles = "Admin, Member")]
        public async Task<IActionResult> RemoveBeerFromWishList(Guid beerId)
        {
            if (beerId == Guid.Empty)
            {
                NotFound();
            }

            var getUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var beerToRemove = await this.wishListService.RemoveBeerFromWishListAsync(beerId, Guid.Parse(getUser));

            //TODO:  redirection should change
            return RedirectToAction(nameof(AddBeerToWishList));
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveUserWish(Guid userId)
        {
            if (userId == null)
            {
                NotFound();
            }

            var getUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var removeUserWish = await this.wishListService.RemoveUserWishListAsync(Guid.Parse(getUser));

            return View(removeUserWish);
        }
    }
}
