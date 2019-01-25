using ExWebApiAutos.Model.ExWebApiAutos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExWebApiAutos.Model
{
    public interface IMarcaRepository
    {
        IQueryable<TMarca> Marcas { get; }
        Task SaveProject(TMarca marca);
        void DeleteProyecto(Guid MarcaId);
    }
}
