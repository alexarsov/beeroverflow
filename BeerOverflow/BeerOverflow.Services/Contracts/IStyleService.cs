using BeerOverflow.Services.DTOs;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace BeerOverflow.Services.Contracts
{
    public interface IStyleService
    {
      public Task CreateStyleAsync(string styleName);
      public Task<bool> DeleteStyleAsync(Guid id);
      public Task<IEnumerable<StyleDTO>> GetAllStylesAsync();
      public Task<StyleDTO> GetStyleAsync(Guid id);
      public Task UpdateStyleAsync(Guid id, string newName);
    }
}