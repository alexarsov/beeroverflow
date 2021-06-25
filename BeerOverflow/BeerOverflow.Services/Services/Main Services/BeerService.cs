using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.Mappers;
using Microsoft.EntityFrameworkCore;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace BeerOverflow.Services.Services
{
    public class BeerService : IBeerService
    {
        private readonly BeerOverflowContext context;

        public BeerService(BeerOverflowContext context)
        {
            this.context = context;
        }

        public async Task CreateBeerAsync(BeerDTO beerDTO)
        {
            var beer = await context.Beers
                .FirstOrDefaultAsync(x => x.Name == beerDTO.Name);
            if (beer == null)
            {
                beer = new Beer();
                beer.TakeInfoFrom(beerDTO);
                _ = await context.Beers.AddAsync(beer);
            }
            else if (beer.IsDeleted == true)
            {
                beer.TakeInfoFrom(beerDTO);
                beer.IsDeleted = false;
            }
            else
            {
                throw new ArgumentException();
            }

            beer.CreatedOn = DateTime.UtcNow;
            _ = await this.context.SaveChangesAsync();
        }
        public async Task<BeerDTO> GetBeerAsync(Guid id)
        {
            var beer = await context.Beers
                .Where(b => b.Id == id && b.IsDeleted == false)
                .Include(b => b.Style)
                .Include(b => b.Country)
                .Include(b => b.Brewery)
                .Include(b => b.ReviewList).ThenInclude(b => b.User)
                .FirstOrDefaultAsync();

            if (beer == null)
            {
                throw new ArgumentNullException();
            }

            var beerDTO = beer.ToDTO();
            return beerDTO;
        }
        public async Task<IEnumerable<BeerDTO>> GetAllBeersAsync()
        {
            //  var beers = await context.Beers.ToListAsync();

            var beerDTOs = await context.Beers
                .Where(b => b.IsDeleted == false)
                .Include(b => b.Style)
                .Include(b => b.Country)
                .Include(b => b.Brewery)
                .Include(b => b.ReviewList).ThenInclude(x=>x.User)
                .Select(b => b.ToDTO())
                .ToArrayAsync();

            return beerDTOs;
        }
        public async Task UpdateBeerAsync(Guid id, BeerDTO beerDTO)
        {
            beerDTO.Id = id;
            var beer = await this.context.Beers
                .Where(b => b.Id == id && b.IsDeleted == false)
                .Include(b => b.Style)
                .Include(b => b.Country)
                .Include(b => b.Brewery)
                .Include(b => b.ReviewList)
                .FirstOrDefaultAsync();

            if (beer == null)
            {
                throw new ArgumentNullException();
            }

            beer.TakeInfoFrom(beerDTO);
            beer.ModifiedOn = DateTime.UtcNow;
            await this.context.SaveChangesAsync();
        }
        public async Task<bool> DeleteBeerAsync(Guid id)
        {
            var beer = await this.context.Beers
           .FirstOrDefaultAsync(b => b.Id == id);

            if (beer == null)
            {
                return false;
            }

            beer.IsDeleted = true;
            beer.CreatedOn = DateTime.UtcNow;
            await this.context.SaveChangesAsync();

            return beer.IsDeleted;
        }
        internal async Task<bool> DeleteBeersAsync(ICollection<Beer> beers)
        {
            foreach (var beer in beers)
            {
                beer.IsDeleted = true;
            }
            
            _ = await context.SaveChangesAsync();
            return true;
        }
        async Task<bool> IBeerService.DeleteBeersAsync(ICollection<Beer> beers)
        {
            foreach (var beer in beers)
            {
                beer.IsDeleted = true;
            }
            _ = await context.SaveChangesAsync();
            return true;
        }
    }
}

