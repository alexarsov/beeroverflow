using BeerOverflow.Services.DTOs;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace BeerOverflow.Services.Contracts
{
    public interface IBreweryService
    {
        Task CreateBreweryAsync(BreweryDTO breweryDTO);
        Task<bool> DeleteBreweryAsync(Guid id);
        Task<IEnumerable<BreweryDTO>> GetAllBreweriesAsync();
        Task<BreweryDTO> GetBreweryAsync(Guid id);
        Task UpdateBreweryAsync(Guid id, BreweryDTO breweryDTO);
    }
}