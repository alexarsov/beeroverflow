using BeerOverflow.Services.DTOs;
using BeerOverflow.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeerOverflow.Services.Contracts
{
    public interface ISortBeerService
    {
        Task<IEnumerable<BeerDTO>> SortByABVAsync();
        Task<IEnumerable<BeerDTO>> SortByNameAsync();
        Task<IEnumerable<BeerDTO>> SortByRatingAsync();
    }
}
