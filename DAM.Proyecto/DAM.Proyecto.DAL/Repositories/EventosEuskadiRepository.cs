using DAM.Proyecto.DAL.Interfaces.IRepositories;
using DAM.Proyecto.Domain.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.DAL.Repositories
{
    /********************************************************************************************************
     * EventosEuskadiRepository
     * 
     * Repositories are classes which implements data access logic. A repository represents a data entity, 
     * common CRUD operations and other special cases. The application layers consumes the APIs provided by 
     * the repository and does not need to care about how is implemented.
     * 
     * *****************************************************************************************************/

    public class EventosEuskadiRepository : GenericRepository<EventoEuskadiTable>, IEventosEuskadiRepository
    {
        public EventosEuskadiRepository(DamDbContext context) : base(context)
        {
        }
    }
}
