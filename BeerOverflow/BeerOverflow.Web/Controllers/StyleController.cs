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
    public class StyleController : Controller
    {
        private readonly IStyleService styleService;

        public StyleController(IStyleService styleService)
        {
            this.styleService = styleService;
        }

        [HttpGet]
        public async Task<IActionResult> List(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var styles = (await styleService.GetAllStylesAsync())
                .Select(c => new StyleViewModel { Id = c.Id, Name = c.Name });

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.StyleSortParm = sortOrder == "Style" ? "style_desc" : "Style";

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
                styles = styles.Where(item => item.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    styles = styles.OrderByDescending(n => n.Name);
                    break;
                case "Style":
                    styles = styles.OrderBy(s => s.Id);
                    break;
                case "style_desc":
                    styles = styles.OrderByDescending(s => s.Id);
                    break;
                default:
                    styles = styles.OrderBy(n => n.Name);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(styles.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var style = await this.styleService.GetStyleAsync(id.Value);

            if (style == null)
            {
                return NotFound();
            }

            return View(style.MapToStyleVM());
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Member")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Member")]
        public async Task<IActionResult> Create(StyleViewModel styleModel)
        {
            if (ModelState.IsValid)
            {

                await this.styleService.CreateStyleAsync(styleModel.Name.ToString());

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

            var styleID = (await styleService.GetStyleAsync(id)).MapToStyleVM();

            return View(styleID);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Member")]
        public async Task<IActionResult> Edit(Guid id, string name)
        {
            if (ModelState.IsValid)
            {
                await this.styleService.UpdateStyleAsync(id, name);

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

            var style = await this.styleService.GetStyleAsync(id.Value);

            if (style == null)
            {
                return NotFound();
            }

            return View(style.MapToStyleVM());
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirm(Guid id)
        {
            var style = await this.styleService.DeleteStyleAsync(id);

            return RedirectToAction(nameof(List));
        }
    }
}