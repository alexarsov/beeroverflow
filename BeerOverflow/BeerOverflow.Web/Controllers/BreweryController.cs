using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Web.WebMappers;
using Microsoft.AspNetCore.Mvc;
using BeerOverflow.Web.Models;
using System.Threading.Tasks;
using System.Linq;
using X.PagedList;
using System;

namespace BeerOverflow.Web.Controllers
{
    public class BreweryController : Controller
    {
        private readonly IBreweryService breweryService;
        private readonly ICountryService countryService;

        public BreweryController(IBreweryService breweryService, ICountryService countryService)
        {
            this.breweryService = breweryService;
            this.countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> List(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var breweries = (await breweryService.GetAllBreweriesAsync()).Select(x => x.MapToBreweryVM());

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CountrySortParm = sortOrder == "Country" ? "county_desc" : "Country";

            if (searchString != null)
            {
                page = 1;
            }

            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            //Search box
            if (!String.IsNullOrEmpty(searchString))
            {
                breweries = breweries.Where(item => item.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    breweries = breweries.OrderByDescending(n => n.Name);
                    break;
                case "Country":
                    breweries = breweries.OrderBy(c => c.CountryName);
                    break;
                case "county_desc":
                    breweries = breweries.OrderByDescending(c => c.CountryName);
                    break;
                default:
                    breweries = breweries.OrderBy(n => n.Name);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(breweries.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var brewery = await this.breweryService.GetBreweryAsync(id.Value);

            if (brewery == null)
            {
                return NotFound();
            }

            return View(brewery.MapToBreweryVM());
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Member")]
        public async Task<IActionResult> Create()
        {
            ViewData["CountryId"] = new SelectList(await countryService.GetAllCountriesAsync(), "Id", "Name");

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Member")]
        public async Task<IActionResult> Create(BreweryViewModel breweryModel)
        {
            if (ModelState.IsValid)
            {
                await this.breweryService.CreateBreweryAsync(breweryModel.MapToBreweryDTO());
                return RedirectToAction(nameof(List));
            }

            return BadRequest();
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Member")]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var breweryID = (await breweryService.GetBreweryAsync(id)).MapToBreweryVM();

            ViewData["CountryId"] = new SelectList(await countryService.GetAllCountriesAsync(), "Id", "Name");

            return View(breweryID);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Member")]
        public async Task<IActionResult> Edit(Guid id, BreweryViewModel breweryModel)
        {
            if (ModelState.IsValid)
            {
                await this.breweryService
                .UpdateBreweryAsync(id, breweryModel.MapToBreweryDTO());

                return RedirectToAction(nameof(List));
            }

            return BadRequest();
        }


        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var brewery = await this.breweryService.DeleteBreweryAsync(id);

            return RedirectToAction("List");
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var brewery = await this.breweryService.GetBreweryAsync(id.Value);

            if (brewery == null)
            {
                return NotFound();
            }

            return View(brewery.MapToBreweryVM());
        }

      
    }
}
