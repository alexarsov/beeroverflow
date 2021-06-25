using BeerOverflow.Data.DataAccessContext;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services.DTOs;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace BeerOverflow.Services.Services.Main_Services
{
    public class StyleService : IStyleService
    {
        private readonly BeerOverflowContext context;
        public StyleService(BeerOverflowContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<StyleDTO> GetStyleAsync(Guid id)
        {
            var style = await this.context.Styles
           .FirstOrDefaultAsync(s => s.Id == id && s.IsDeleted == false);

            if (style == null)
            {
                throw new ArgumentNullException();
            }

            var styleDTO = style.ToDTO();
            return styleDTO;
        }

        public async Task<IEnumerable<StyleDTO>> GetAllStylesAsync()
        {
            var styles = await this.context.Styles
                 .Where(x => x.IsDeleted == false)
                 .ToArrayAsync();

            var styleDTO = styles.Select(s => s.ToDTO());

            return styleDTO;
        }

        public async Task CreateStyleAsync(string styleName)
        {
            var style = await context.Styles.FirstOrDefaultAsync(x => x.Name == styleName);
            if (style == null)
            {
                style = new Style();
                style.Name = styleName;
                _ = await this.context.Styles.AddAsync(style);
            }
            else if (style.IsDeleted == true)
            {
                style.Name = styleName;
                style.IsDeleted = false;
            }
            else
            {
                throw new ArgumentException();
            }

            style.CreatedOn = DateTime.UtcNow;
            _ = await this.context.SaveChangesAsync();
        }

        public async Task UpdateStyleAsync(Guid id, string newName)
        {
            var style = await this.context.Styles
           .FirstOrDefaultAsync(s => s.Id == id && s.IsDeleted == false);

            if (style == null)
            {
                throw new ArgumentNullException();
            }

            style.Name = newName;
            style.ModifiedOn = DateTime.UtcNow;
            _ = await this.context.SaveChangesAsync();

        }

        public async Task<bool> DeleteStyleAsync(Guid id)
        {
            var style = this.context.Styles
                .Include(s => s.BeerLists)
                .FirstOrDefault(s => s.Id == id);

            if (style == null)
            {
                return false;
            }
            style.IsDeleted = true;
            style.CreatedOn = DateTime.UtcNow;
            _ = await this.context.SaveChangesAsync();

            return true;
        }
    }
}
