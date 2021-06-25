using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.Mappers.Contracts
{
    public interface IDTOMapper<TModel, TModelDTO>
    {
        public TModelDTO MapFrom(TModel model);
    }
}
