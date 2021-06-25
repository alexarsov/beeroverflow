using Microsoft.AspNetCore.Authorization;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Web.WebMappers;
using Microsoft.AspNetCore.Mvc;
using BeerOverflow.Web.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using NToastNotify;
using System;
using System.Linq;

namespace BeerOverflow.Web.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewBeerService reviewBeerService;
        private readonly IToastNotification _toastNotification;

        public ReviewController(IReviewBeerService reviewBeerService, IToastNotification _toastNotification)
        {
            this.reviewBeerService = reviewBeerService;
            this._toastNotification = _toastNotification;
        }

        [Authorize(Roles = "Admin, Member")]
        public async Task<IActionResult> AddReview(ReviewViewModel reviewVM)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                reviewVM.UserId = Guid.Parse(userId);

                await this.reviewBeerService.AddReviewAsync(reviewVM.MapToReviewDTO());

                _toastNotification.AddAlertToastMessage("Review successfully added");
                return RedirectToAction("Details", "Beer", new { id = reviewVM.BeerId });
            }

            return BadRequest();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetUserWishList()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Member")]
        public async Task<IActionResult> GetReviewOfBeer()
        {

            var getUser = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var reviews = (await this.reviewBeerService.GetReviewsOfBeerAsync(getUser)).Select(x => x.MapToReviewVM());

            return View(reviews);
        }
  
        [HttpPost]
        [Authorize(Roles = "Admin, Member")]
        public async Task<IActionResult> GetReviewOfBeer(Guid beerId)
        {
            if (beerId == null)
            {
                NotFound();
            }

            var getUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var reviews = await this.reviewBeerService.GetReviewOfBeerAsync(Guid.Parse(getUser), beerId);

            return View(reviews);
        }
        public async Task<IActionResult> UpdateReview(ReviewViewModel reviewVM)
        {
            if (ModelState.IsValid)
            {
                await this.reviewBeerService.UpdateReviewAsync(reviewVM.MapToReviewDTO());

                //TODO:  redirection should change
                return RedirectToAction(nameof(HomeController));
            }

            return BadRequest();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteReview()
        {
            return View();
        }

        [HttpPost, ActionName("DeleteReview")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteReviewConfirm(Guid beerId)
        {
            var getUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var review = await this.reviewBeerService.DeleteReviewAsync(Guid.Parse(getUser), beerId);

            return RedirectToAction(nameof(HomeController));
        }
    }
}
