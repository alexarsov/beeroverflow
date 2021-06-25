using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace BeerOverflow.Web.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreweryController : ControllerBase
    {
        private readonly IBreweryService breweryService;

        public BreweryController(IBreweryService breweryService)
        {
            this.breweryService = breweryService ?? throw new ArgumentNullException(nameof(breweryService));
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBreweriesAsync()
        {
            var breweries = await this.breweryService.GetAllBreweriesAsync();

            return Ok(breweries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBreweryAsync(Guid id)
        {
            try
            {
                var model = await this.breweryService.GetBreweryAsync(id);
                return Ok(model);
            }

            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateBreweryAsync([FromBody] BreweryDTO model)
        {
            try
            {
                await this.breweryService.CreateBreweryAsync(model);

                return Ok();
            }

            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBreweryAsync(Guid id, [FromBody] BreweryDTO newBrewery)
        {
            if (id == Guid.Empty || newBrewery == null)
            {
                return BadRequest();
            }

            //var breweryDTO = 
            await this.breweryService.UpdateBreweryAsync(id, newBrewery);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBreweryAsync(Guid id)
        {
            try
            {
                var breweryDTO = await this.breweryService.DeleteBreweryAsync(id);

                return Ok(breweryDTO);
            }

            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}