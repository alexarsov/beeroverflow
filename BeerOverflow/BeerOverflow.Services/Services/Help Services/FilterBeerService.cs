using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using BeerOverflow.Services.Mappers;
using System.Collections.Generic;
using BeerOverflow.Services.DTOs;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace BeerOverflow.Services.Services
{
    public class FilterBeerService : IFilterBeerService
    {
        private readonly BeerOverflowContext context;
        public FilterBeerService(BeerOverflowContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<BeerDTO>> FilterBeersByCountryIdAsync(Guid id)
        {
            var beerDTOs = await context.Beers
                .Where(b => b.CountryId == id && b.IsDeleted == false)
                .Include(b => b.Country)
                .Include(b => b.Style)
                .Include(b => b.Brewery)
                .Include(b => b.ReviewList).ThenInclude(x => x.User)
                .Select(b => b.ToDTO())
                .ToArrayAsync();

            return beerDTOs;
        }
        public async Task<IEnumerable<BeerDTO>> FilterBeersByCountryNameAsync(string countryName)
        {
            var beerDTOs = await context.Beers
                .Include(b => b.Country)
                .Include(b => b.Style)
                .Include(b => b.Brewery)
                .Include(b => b.ReviewList).ThenInclude(x => x.User)
                .Where(b => b.Country.Name == countryName && b.IsDeleted == false)
                .Select(b => b.ToDTO())
                .ToArrayAsync();

            return beerDTOs;
        }
        public async Task<IEnumerable<BeerDTO>> FilterBeersByBreweryIdAsync(Guid id)
        {
            var beerDTOs = await context.Beers
                .Where(b => b.BreweryId == id && b.IsDeleted == false)
                .Include(b => b.Country)
                .Include(b => b.Style)
                .Include(b => b.Brewery)
                .Include(b => b.ReviewList).ThenInclude(x => x.User)
                .Select(b => b.ToDTO())
                .ToArrayAsync();
            return beerDTOs;
        }
        public async Task<IEnumerable<BeerDTO>> FilterBeersByBreweryNameAsync(string breweryName)
        {
            var beerDTOs = await context.Beers
                .Include(b => b.Country)
                .Include(b => b.Style)
                .Include(b => b.Brewery)
                .Include(b => b.ReviewList).ThenInclude(x => x.User)
                .Where(b => b.Brewery.Name == breweryName && b.IsDeleted == false)
                .Select(b => b.ToDTO())
                .ToArrayAsync();
            return beerDTOs;
        }
        public async Task<IEnumerable<BeerDTO>> FilterBeersByStyleIdAsync(Guid id)
        {
            var beerDTOs = await context.Beers
                .Where(b => b.StyleId == id && b.IsDeleted == false)
                .Include(b => b.Country)
                .Include(b => b.Style)
                .Include(b => b.Brewery)
                .Include(b => b.ReviewList).ThenInclude(x => x.User)
                .Select(b => b.ToDTO())
                .ToArrayAsync();
            return beerDTOs;
        }
        public async Task<IEnumerable<BeerDTO>> FilterBeersByStyleNameAsync(string styleName)
        {
            var beerDTOs = await context.Beers
                .Include(b => b.Country)
                .Include(b => b.Style)
                .Include(b => b.Brewery)
                .Include(b => b.ReviewList).ThenInclude(x => x.User)
                .Where(b => b.Style.Name == styleName && b.IsDeleted == false)
                .Select(b => b.ToDTO())
                .ToArrayAsync();
            return beerDTOs;
        }
    }
}
