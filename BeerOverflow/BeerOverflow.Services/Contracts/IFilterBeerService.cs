using BeerOverflow.Services.DTOs;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace BeerOverflow.Services.Contracts
{
    public interface IFilterBeerService
    {
        Task<IEnumerable<BeerDTO>> FilterBeersByBreweryIdAsync(Guid id);
        Task<IEnumerable<BeerDTO>> FilterBeersByBreweryNameAsync(string breweryName);
        Task<IEnumerable<BeerDTO>> FilterBeersByCountryIdAsync(Guid id);
        Task<IEnumerable<BeerDTO>> FilterBeersByCountryNameAsync(string countryName);
        Task<IEnumerable<BeerDTO>> FilterBeersByStyleIdAsync(Guid id);
        Task<IEnumerable<BeerDTO>> FilterBeersByStyleNameAsync(string styleName);
    }
}