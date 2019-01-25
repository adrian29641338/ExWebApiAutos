using ExWebApiAutos.Model.ExWebApiAutos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ExWebApiAutos.Model
{
    public class EFAutoRepository : IAutoRepository
    {
        public IQueryable<TAuto> Autos => context.TAuto;
        private ExWebApiDbContext context;
        public EFAutoRepository(ExWebApiDbContext ctx)
        {
            context = ctx;
        }
        public async Task SaveProject(TAuto auto)
        {
            if (auto.AutoId == Guid.Empty)
            {
                auto.AutoId = Guid.NewGuid();
                context.TAuto.Add(auto);
            }
            else
            {
                TAuto dbEntry = context.TAuto
                .FirstOrDefault(p => p.AutoId == auto.AutoId);
                if (dbEntry != null)
                {
                    dbEntry.AutoId = auto.AutoId;
                    dbEntry.AutoAniofabri = auto.AutoAniofabri;
                    dbEntry.AutoColor = auto.AutoColor;
                    dbEntry.AutoFull = auto.AutoFull;
                    dbEntry.MarcaId = auto.MarcaId;
                    dbEntry.AutoMecanico = auto.AutoMecanico;
                    dbEntry.AutoNroasientos = auto.AutoNroasientos;
                    dbEntry.AutoNroplaca = auto.AutoNroplaca;
                }
            }
            
        await context.SaveChangesAsync();
        }
        public void DeleteProyecto(Guid AutoID)
        {
            TAuto dbEntry = context.TAuto
            .FirstOrDefault(p => p.AutoId == AutoID);
            if (dbEntry != null)
            {
                context.TAuto.Remove(dbEntry);
                context.SaveChanges();
            }
        }
    }
}
