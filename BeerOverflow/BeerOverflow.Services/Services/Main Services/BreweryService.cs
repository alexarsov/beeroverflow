using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using BeerOverflow.Services.Mappers;
using BeerOverflow.Data.Entities;
using System.Collections.Generic;
using BeerOverflow.Services.DTOs;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace BeerOverflow.Services.Services.Main_Services
{
    public class BreweryService : IBreweryService
    {
        private readonly BeerOverflowContext context;
        private readonly IBeerService beerService;
        public BreweryService(BeerOverflowContext context,
            IBeerService beerService)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.beerService = beerService;
        }
        public async Task CreateBreweryAsync(BreweryDTO breweryDTO)
        {
            var brewery = await context.Breweries.FirstOrDefaultAsync(x => x.Name == breweryDTO.Name);
            if (brewery == null)
            {
                brewery = new Brewery();
                brewery.TakeInfoFrom(breweryDTO);
                _ = await this.context.Breweries.AddAsync(brewery);
            }
            else if (brewery.IsDeleted == true)
            {
                brewery.TakeInfoFrom(breweryDTO);
                brewery.IsDeleted = false;
            }
            else
            {
                throw new ArgumentException();
            }
            brewery.CreatedOn = DateTime.UtcNow;
            _ = await this.context.SaveChangesAsync();
        }
        public async Task<BreweryDTO> GetBreweryAsync(Guid id)
        {
            var brewery = await this.context.Breweries
                .Where(brw => brw.Id == id && brw.IsDeleted == false)
                .Include(brw => brw.Country)
                .FirstOrDefaultAsync();

            if (brewery == null)
            {
                throw new ArgumentNullException();
            }

            var breweryDTO = brewery.ToDTO();
            return breweryDTO;
        }
        public async Task<IEnumerable<BreweryDTO>> GetAllBreweriesAsync()
        {
            var breweries = await this.context.Breweries
                 .Where(c => c.IsDeleted == false)
                 .Include(brw => brw.Country)
                 .ToArrayAsync();

            var breweryDTO = breweries.Select(c => c.ToDTO());

            return breweryDTO;
        }
        public async Task UpdateBreweryAsync(Guid id, DTOs.BreweryDTO breweryDTO)
        {
            breweryDTO.Id = id;
            var brewery = await this.context.Breweries
                .Include(brw => brw.Country)
                .FirstOrDefaultAsync(brw => brw.Id == id && brw.IsDeleted == false);
            if (brewery == null)
            {
                throw new ArgumentNullException();
            }

            brewery.TakeInfoFrom(breweryDTO);
            brewery.ModifiedOn = DateTime.UtcNow;
            _ = await this.context.SaveChangesAsync();
        }
        public async Task<bool> DeleteBreweryAsync(Guid id)
        {
            var brewery = this.context.Breweries
                .Include(b => b.Beers)
                .FirstOrDefault(b => b.Id == id);

            if (brewery == null)
            {
                return false;
            }
            _ = await this.beerService.DeleteBeersAsync(brewery.Beers);
            brewery.IsDeleted = true;
            brewery.CreatedOn = DateTime.UtcNow;
            _ = this.context.SaveChangesAsync();

            return true;
        }
        internal async Task<bool> DeleteBreweriesAsync(ICollection<Brewery> breweries)
        {
            foreach (var brewery in breweries)
            {
                await DeleteBreweryAsync(brewery.Id);
            }
            return true;
        }
    }
}
