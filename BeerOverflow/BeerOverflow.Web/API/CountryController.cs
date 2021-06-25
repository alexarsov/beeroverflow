using BeerOverflow.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace BeerOverflow.Web.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService countryService;

        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService ?? throw new ArgumentNullException(nameof(countryService));
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCountriesAsync()
        {
            var countries = await this.countryService.GetAllCountriesAsync();

            return Ok(countries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountryAsync(Guid id)
        {
            try
            {
                var model = await this.countryService.GetCountryAsync(id);

                return Ok(model);
            }

            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateCountryAsync([FromBody] string name)
        {
            try
            {
                await this.countryService.CreateCountryAsync(name);

                return Ok();
            }

            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCountryAsync(Guid id, [FromBody] string newCountry)
        {
            if (id == Guid.Empty || newCountry == null)
            {
                return BadRequest();
            }

            //var country = 
            await this.countryService.UpdateCountryAsync(id, newCountry);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountryAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var country = await this.countryService.DeleteCountryAsync(id);

            return Ok(country);
        }
    }
}