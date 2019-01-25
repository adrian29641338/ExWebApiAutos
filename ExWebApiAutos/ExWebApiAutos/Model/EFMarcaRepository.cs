using ExWebApiAutos.Model.ExWebApiAutos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ExWebApiAutos.Model
{
    public class EFMarcaRepository : IMarcaRepository
    {
        public IQueryable<TMarca> Marcas => context.TMarca;
        private ExWebApiDbContext context;
        public EFMarcaRepository(ExWebApiDbContext ctx)
        {
            context = ctx;
        }
        public async Task SaveProject(TMarca marca)
        {
            if (marca.MarcaId == Guid.Empty)
            {
                marca.MarcaId = Guid.NewGuid();
                context.TMarca.Add(marca);
            }
            else
            {
                TMarca dbEntry = context.TMarca
                .FirstOrDefault(p => p.MarcaId == marca.MarcaId);
                if (dbEntry != null)
                {
                    dbEntry.MarcaId = marca.MarcaId;
                    dbEntry.MarcaNombre = marca.MarcaNombre;
                    
                }
            }

            await context.SaveChangesAsync();
        }
        public void DeleteProyecto(Guid MarcaId)
        {
            TMarca dbEntry = context.TMarca
            .FirstOrDefault(p => p.MarcaId == MarcaId);
            if (dbEntry != null)
            {
                context.TMarca.Remove(dbEntry);
                context.SaveChanges();
            }
        }
    }
}
