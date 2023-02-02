using DAM.Proyecto.DAL.Interfaces.IRepositories;
using DAM.Proyecto.Domain.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.DAL.Repositories
{
    public class MaestroEventosRepository : GenericRepository<MaestroEventosTable>, IMaestroEventosRepository
    {
        public MaestroEventosRepository(DamDbContext context) : base(context)
        {
        }
    }
}
