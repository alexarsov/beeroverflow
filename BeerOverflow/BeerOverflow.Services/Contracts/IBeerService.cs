using BeerOverflow.Services.DTOs;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using BeerOverflow.Data.Entities;

namespace BeerOverflow.Services.Contracts
{
    public interface IBeerService
    {
        Task CreateBeerAsync(BeerDTO beerDTO);
        Task<bool> DeleteBeerAsync(Guid id);
        Task<IEnumerable<BeerDTO>> GetAllBeersAsync();
        Task<BeerDTO> GetBeerAsync(Guid id);
        Task UpdateBeerAsync(Guid id, BeerDTO beerDTO);
        internal Task<bool> DeleteBeersAsync(ICollection<Beer> beers);
    }
}