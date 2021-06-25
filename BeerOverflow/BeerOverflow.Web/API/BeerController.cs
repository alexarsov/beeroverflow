using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace BeerOverflow.Web.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly IBeerService beerService;
        private readonly IFilterBeerService filterBeerService;
        private readonly ISortBeerService sortBeerService;
        private readonly IReviewBeerService reviewService;

        public BeerController(IBeerService beerService, IFilterBeerService filterBeerService,
            ISortBeerService sortBeerService, IReviewBeerService reviewService)
        {
            this.beerService = beerService ?? throw new ArgumentNullException(nameof(beerService));
            this.sortBeerService = sortBeerService ?? throw new ArgumentNullException(nameof(sortBeerService));
            this.filterBeerService = filterBeerService ?? throw new ArgumentNullException(nameof(filterBeerService));
            this.reviewService = reviewService ?? throw new ArgumentNullException(nameof(filterBeerService));
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBeersAsync()
        {
            var beers = await this.beerService.GetAllBeersAsync();

            return Ok(beers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBeerByIdAsync(Guid id)
        {
            try
            {
                var model = await this.beerService.GetBeerAsync(id);
                return Ok(model);
            }

            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("country/{countryId}")]
        public async Task<IActionResult> FilterBeersByCountryIdAsync(Guid countryId)
        {
            try
            {
                var filterByCountry = await this.filterBeerService.FilterBeersByCountryIdAsync(countryId);
                return Ok(filterByCountry);
            }

            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("brewery/{breweryId}")]
        public async Task<IActionResult> FilterBeersByBreweryIdAsync(Guid breweryId)
        {
            try
            {
                var filterByBrewery = await this.filterBeerService.FilterBeersByBreweryIdAsync(breweryId);
                return Ok(filterByBrewery);
            }

            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("style/{styleId}")]
        public async Task<IActionResult> FilterBeersByStyleIdAsync(Guid styleId)
        {
            try
            {
                var filterByStyle = await this.filterBeerService.FilterBeersByStyleIdAsync(styleId);
                return Ok(filterByStyle);
            }

            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("sort/byname")]
        public async Task<IActionResult> SortBeersByNameAsync()
        {
            try
            {
                var beers = await this.sortBeerService.SortByNameAsync();
                return Ok(beers);
            }

            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("sort/byrating")]
        public async Task<IActionResult> SortBeersByRatingAsync()
        {
            try
            {
                var beers = await this.sortBeerService.SortByRatingAsync();
                return Ok(beers);
            }

            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("sort/byabv")]
        public async Task<IActionResult> SortBeersByAbvAsync()
        {
            try
            {
                var beers = await this.sortBeerService.SortByABVAsync();
                return Ok(beers);
            }

            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateBeerAsync([FromBody] BeerDTO model)
        {
            try
            {
                //var beerDTO = 
                    await this.beerService.CreateBeerAsync(model);
                return Ok();
            }

            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")] 
        public async Task<IActionResult> UpdateBeerAsync(Guid id, [FromBody] BeerDTO newBeer)
        {
            if (id == Guid.Empty || newBeer == null)
            {
                return BadRequest();
            }

           // var beerDTO = 
                await this.beerService.UpdateBeerAsync(id, newBeer);

            return Ok();
        }

        [HttpPut("rate")]
        public async Task<IActionResult> UpdateBeerRateAsync([FromBody] ReviewDTO review)
        {
            try
            {
                //var beerDTO =
                    await this.reviewService.UpdateReviewAsync(review);
                return Ok();
            }

            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeerAsync(Guid id)
        {
            try
            {
                var beerDTO = await this.beerService.DeleteBeerAsync(id);
                return Ok(beerDTO);
            }

            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}


