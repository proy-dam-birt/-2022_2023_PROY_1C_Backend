using DAM.Proyecto.Domain.Entities.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.DAL.Interfaces.IServiceProvider
{
    public interface IEventosApiProvider
    {
        Task<IEnumerable<EventoEuskadi>> GetEventosEusData();
    }
}
