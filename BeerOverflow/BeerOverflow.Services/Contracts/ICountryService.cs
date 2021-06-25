using BeerOverflow.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerOverflow.Services.Contracts
{
    public interface ICountryService
    {
        Task CreateCountryAsync(string countryName);
        Task<bool> DeleteCountryAsync(Guid id);
        Task<IEnumerable<CountryDTO>> GetAllCountriesAsync();
        Task<CountryDTO> GetCountryAsync(Guid id);
        Task UpdateCountryAsync(Guid id, string newName);
    }
}
