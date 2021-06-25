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
using System.Security.Claims;
using BeerOverflow.Services.Services.Main_Services;

namespace BeerOverflow.Web.Controllers
{
    public class BeerController : Controller
    {
        private readonly IBeerService beerService;
        private readonly IUserService userService;
        private readonly IStyleService styleService;
        private readonly ICountryService countryService;
        private readonly IBreweryService breweryService;

        public BeerController(IBeerService beerService, IStyleService styleService,
            ICountryService countryService, IBreweryService breweryService, IUserService userService)
        {
            this.beerService = beerService;
            this.styleService = styleService;
            this.countryService = countryService;
            this.breweryService = breweryService;
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> List(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var beers = (await this.beerService.GetAllBeersAsync()).Select(x => x.MapToBeerVM());

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CountrySortParm = sortOrder == "Country" ? "county_desc" : "Country";
            ViewBag.StyleSortParm = sortOrder == "Style" ? "style_desc" : "Style";
            ViewBag.BrewerySortParm = sortOrder == "Brewery" ? "brewery_desc" : "Brewery";
            ViewBag.AlcoholSortParm = sortOrder == "Alcohol %" ? "abv_desc" : "Alcohol %";

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
                beers = beers.Where(item => item.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    beers = beers.OrderByDescending(n => n.Name);
                    break;
                case "Style":
                    beers = beers.OrderBy(s => s.StyleId);
                    break;
                case "style_desc":
                    beers = beers.OrderByDescending(s => s.StyleId);
                    break;
                case "Country":
                    beers = beers.OrderBy(c => c.CountryId);
                    break;
                case "county_desc":
                    beers = beers.OrderByDescending(c => c.CountryId);
                    break;
                case "Brewery":
                    beers = beers.OrderBy(b => b.BreweryId);
                    break;
                case "brewery_desc":
                    beers = beers.OrderByDescending(b => b.BreweryId);
                    break;
                case "Alcohol %":
                    beers = beers.OrderBy(a => a.ABV);
                    break;
                case "abv_desc":
                    beers = beers.OrderByDescending(a => a.ABV);
                    break;
                default:
                    beers = beers.OrderBy(n => n.Name);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(beers.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var beer = await this.beerService.GetBeerAsync(id.Value);

            if (beer == null)
            {
                return NotFound();
            }

            var beerVM = beer.MapToBeerVM();
            
            return View(beerVM);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Member")]
        public async Task<IActionResult> CreateAsync()
        {
            ViewData["StyleId"] = new SelectList(await styleService.GetAllStylesAsync(), "Id", "Name");
            ViewData["CountryId"] = new SelectList(await countryService.GetAllCountriesAsync(), "Id", "Name");
            ViewData["BreweryId"] = new SelectList(await breweryService.GetAllBreweriesAsync(), "Id", "Name");

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Member")]
        public async Task<IActionResult> Create(BeerViewModel beerModel)
        {
            if (ModelState.IsValid)
            {
                await this.beerService.CreateBeerAsync(beerModel.MapToBeerDTO());
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

            var beerID = (await beerService.GetBeerAsync(id)).MapToBeerVM();

            ViewData["StyleId"] = new SelectList(await styleService.GetAllStylesAsync(), "Id", "Name");
            ViewData["CountryId"] = new SelectList(await countryService.GetAllCountriesAsync(), "Id", "Name");
            ViewData["BreweryId"] = new SelectList(await this.breweryService.GetAllBreweriesAsync(), "Id", "Name");

            return View(beerID);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Member")]
        public async Task<IActionResult> Edit(Guid id, BeerViewModel beerModel)
        {
            if (ModelState.IsValid)
            {
                await this.beerService.UpdateBeerAsync(id, beerModel.MapToBeerDTO());
                return RedirectToAction(nameof(List));
            }

            return BadRequest();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var beer = await this.beerService.GetBeerAsync(id.Value);

            if (beer == null)
            {
                return NotFound();
            }

            return View(beer.MapToBeerVM());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(Guid id)
        {
            var beer = await this.beerService.DeleteBeerAsync(id);

            return RedirectToAction(nameof(List));
        }
    }
}