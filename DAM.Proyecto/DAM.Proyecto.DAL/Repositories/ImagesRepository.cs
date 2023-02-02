using DAM.Proyecto.DAL.Interfaces.IRepositories;
using DAM.Proyecto.Domain.Entities.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.DAL.Repositories
{
    public class ImagesRepository : GenericRepository<ImagesTable>, IImagesRepository
    {
        public ImagesRepository(DamDbContext context) : base(context)
        {
            var result = _context.Set<EventoEuskadiTable>().Include(h => h.Images);
        }
    }
}
