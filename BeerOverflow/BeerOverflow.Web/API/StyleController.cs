using BeerOverflow.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace BeerOverflow.Web.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StyleController : ControllerBase
    {
        private readonly IStyleService styleService;

        public StyleController(IStyleService styleService)
        {
            this.styleService = styleService ?? throw new ArgumentNullException(nameof(styleService));
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllStylesAsync()
        {
            var styles = await this.styleService.GetAllStylesAsync();

            return Ok(styles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStyleAsync(Guid id)
        {
            try
            {
                var model = await this.styleService.GetStyleAsync(id);

                return Ok(model);
            }

            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateStyleAsync([FromBody] string name)
        {
            try
            {
                await this.styleService.CreateStyleAsync(name);

                return Ok();
            }

            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStyleAsync(Guid id, [FromBody] string newStyle)
        {
            if (id == Guid.Empty || newStyle == null)
            {
                return BadRequest();
            }

            //var style = 
            await this.styleService.UpdateStyleAsync(id, newStyle);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStyleAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var style = await this.styleService.DeleteStyleAsync(id);

            return Ok(style);
        }
    }
}