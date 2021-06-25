using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.Mappers;
using Microsoft.EntityFrameworkCore;
using BeerOverflow.Services.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace BeerOverflow.Services.Services
{
    public class SortBeerService : ISortBeerService
    {
        private readonly BeerOverflowContext context;

        public SortBeerService(BeerOverflowContext context)
        {
            this.context = context;
        }

        public async System.Threading.Tasks.Task<IEnumerable<BeerDTO>> SortByNameAsync()
        {
            var beers = await context.Beers
                .Include(b => b.Country)
                .Include(b => b.Style)
                .Include(b => b.Brewery)
                .Include(b => b.ReviewList).ThenInclude(x => x.User)
                .Where(b => b.IsDeleted == false)
                .Select(b => b.ToDTO())
               .ToArrayAsync();

            return beers.OrderBy(b => b.Name);
        }

        public async System.Threading.Tasks.Task<IEnumerable<BeerDTO>> SortByRatingAsync()
        {
            var beers = await context.Beers
                .Include(b => b.Country)
                .Include(b => b.Style)
                .Include(b => b.Brewery)
                .Include(b => b.ReviewList).ThenInclude(x => x.User)
                .Where(b => b.IsDeleted == false)
                .Select(b => b.ToDTO())
               .ToArrayAsync();

            return beers.OrderByDescending(b => b.Rating);
        }

        public async System.Threading.Tasks.Task<IEnumerable<BeerDTO>> SortByABVAsync()
        {
            var beers = await context.Beers
                .Include(b => b.Country)
                .Include(b => b.Style)
                .Include(b => b.Brewery)
                .Include(b => b.ReviewList).ThenInclude(x => x.User)
                .Where(b => b.IsDeleted == false)
                .Select(b => b.ToDTO())
               .ToArrayAsync();

            return beers.OrderBy(b => b.ABV);
        }
    }
}
