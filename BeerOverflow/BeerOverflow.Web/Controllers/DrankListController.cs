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
    public class DrankListController : Controller
    {
        private readonly IDrankListService drankListService;
        private readonly IToastNotification _toastNotification;

        public DrankListController(IDrankListService drankListService, IToastNotification _toastNotification)
        {
            this.drankListService = drankListService;
            this._toastNotification = _toastNotification;
        }

        [Authorize(Roles = "Admin, Member")]
        public async Task<IActionResult> AddBeerToDrankList(Guid beerId)
        {
            if (beerId == Guid.Empty)
            {
                throw new ArgumentException();
            }

            var getUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var drankList = await this.drankListService.AddBeerToDrankListAsync(beerId, Guid.Parse(getUser));
            _toastNotification.AddAlertToastMessage("Beer was successfully added to DrankList");
            return RedirectToAction("Details", "Beer", new { id = beerId });
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Member")]
        public async Task<IActionResult> GetUserDrankList()
        {
            var getUser = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var userDrankList = (await this.drankListService
                .GetUserDrankListAsync(Guid.Parse(getUser)))
                .Select(x => x.MapToBeerVM());

            return View(userDrankList);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Member")]
        public async Task<IActionResult> GetDrankList(Guid userId)
        {
            if (userId == null)
            {
                NotFound();
            }

            var getUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var drankList = await this.drankListService.GetUserDrankListAsync(Guid.Parse(getUser));

            return View(drankList);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult RemoveBeerFromDrankList()
        {
            return View();
        }

        [HttpPost]
        [HttpPost, ActionName("RemoveBeerFromDrankList")]
        [Authorize(Roles = "Admin, Member")]
        public async Task<IActionResult> RemoveBeerFromDrankListConfirm(Guid beerId)
        {
            if (beerId == Guid.Empty)
            {
                NotFound();
            }

            var getUser = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var beerToRemove = await this.drankListService.RemoveBeerFromDrankListAsync(beerId, Guid.Parse(getUser));

            //TODO:  redirection should change
            return RedirectToAction(nameof(AddBeerToDrankList));
        }

        //[HttpGet]
        //[Authorize(Roles = "Admin, Member")]
        //public async Task<IActionResult> GetDrankList()
        //{
        //    return View();
        //}

        //// TODO: should return BeerDTO?
        //[HttpPost]
        //[Authorize(Roles = "Admin, Member")]
        //public async Task<IActionResult> GetDrankList(Guid userId)
        //{
        //    if (userId == null)
        //    {
        //        NotFound();
        //    }

        //    var getUser = (await user.GetUserAsync(User)).Id;

        //    var getDrankList = await this.GetDrankListAsync(getUser);

        //    return View(getDrankList);
        //}
    }
}
