using Microsoft.AspNetCore.Authorization;
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
    public class CountryController : Controller
    {
        private readonly ICountryService countryService;

        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> List(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var countries = (await countryService.GetAllCountriesAsync())
                .Select(c => new CountryViewModel { Id = c.Id, Name = c.Name });

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.StyleSortParm = sortOrder == "Country" ? "country_desc" : "Country";

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
                countries = countries.Where(item => item.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    countries = countries.OrderByDescending(n => n.Name);
                    break;
                case "Country":
                    countries = countries.OrderBy(s => s.Id);
                    break;
                case "country_desc":
                    countries = countries.OrderByDescending(s => s.Id);
                    break;
                default:
                    countries = countries.OrderBy(n => n.Name);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(countries.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var country = await this.countryService.GetCountryAsync(id.Value);

            if (country == null)
            {
                return NotFound();
            }

            return View(country.MapToCountryVM());
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Member")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Member")]
        public async Task<IActionResult> Create(CountryViewModel countryModel)
        {
            if (ModelState.IsValid)
            {
                await this.countryService
                .CreateCountryAsync(countryModel.Name.ToString());
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

            var countryId = (await countryService.GetCountryAsync(id)).MapToCountryVM();

            return View(countryId);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Member")]
        public async Task<IActionResult> Edit(Guid id, string name)
        {
            if (ModelState.IsValid)
            {
                await this.countryService
                .UpdateCountryAsync(id, name);

                return RedirectToAction(nameof(List));
            }

            return BadRequest();
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirm(Guid id)
        {
            var country = await this.countryService.DeleteCountryAsync(id);
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

            var country = await this.countryService.GetCountryAsync(id.Value);

            if (country == null)
            {
                return NotFound();
            }

            return View(country.MapToCountryVM());
        }

    }
}