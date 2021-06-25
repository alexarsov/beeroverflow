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

namespace BeerOverflow.Services
{
    public class CountryService : ICountryService
    {
        private readonly BeerOverflowContext context;

        public CountryService(BeerOverflowContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task CreateCountryAsync(string countryName)
        {
            var country = await context.Countries.FirstOrDefaultAsync(x => x.Name == countryName);
            if (country == null)
            {
                country = new Country();
                country.Name = countryName;
                _ = await this.context.Countries.AddAsync(country);
            }
            else if (country.IsDeleted == true)
            {
                country.IsDeleted = false;
            }
            else
            {
                throw new ArgumentException();
            }
            country.CreatedOn = DateTime.UtcNow;
            _ = await this.context.SaveChangesAsync();

        }
        public async Task<IEnumerable<CountryDTO>> GetAllCountriesAsync()
        {
            var countries = await this.context.Countries
                 .Where(c => c.IsDeleted == false).ToArrayAsync();
            var countryDTOs = countries.Select(c => c.ToDTO());

            return countryDTOs;
        }
        public async Task<CountryDTO> GetCountryAsync(Guid id)
        {
            var country = await this.context.Countries
                .FirstOrDefaultAsync(c => c.Id == id && c.IsDeleted == false);

            if (country == null)
            {
                throw new ArgumentNullException();
            }

            var countryDTO = country.ToDTO();
            return countryDTO;
        }

        public async Task UpdateCountryAsync(Guid id, string newName)
        {
            var country = await this.context.Countries
           .FirstOrDefaultAsync(c => c.Id == id && c.IsDeleted == false);
            if (country == null)
            {
                throw new ArgumentNullException();
            }
            country.Name = newName;
            country.ModifiedOn = DateTime.UtcNow;
            await this.context.SaveChangesAsync();
        }

        public async Task<bool> DeleteCountryAsync(Guid id)
        {
            var country = this.context.Countries
                .Include(x => x.BreweriesList)
                .FirstOrDefault(c => c.Id == id);
            if (country == null)
            {
                return false;
            }
            country.IsDeleted = true;
            country.CreatedOn = DateTime.UtcNow;
            await this.context.SaveChangesAsync();
            return true;
        }
    }
}
