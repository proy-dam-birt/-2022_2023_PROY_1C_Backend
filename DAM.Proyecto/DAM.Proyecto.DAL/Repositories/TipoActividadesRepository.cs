using DAM.Proyecto.DAL.Interfaces.IRepositories;
using DAM.Proyecto.Domain.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.DAL.Repositories
{
    public class TipoActividadesRepository : GenericRepository<TipoActividadTable>, ITipoActividadRepository
    {
        public TipoActividadesRepository(DamDbContext context) : base(context)
        {
        }
    }
}
