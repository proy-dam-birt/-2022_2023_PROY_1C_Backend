using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.DAL.Interfaces.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IEventosEuskadiRepository EventosEuskadiRepo { get; }
        ITipoActividadRepository TipoActividadRepo { get; }
        IUserRepository UserRepo { get; }
        IImagesRepository ImagesRepo { get; }
        IEventsRepository EventsRepo { get; }
        IGastronomiaEuskadiRepository GastronomiaEuskadiRepo { get; }
        ITagsRepository TagsRepo { get; }
        IMaestroEventosRepository MaestroEventosRepo { get; }
        IReservaRepository ReservaRepo { get; }
        IFechasEventosRepository FechasEventosRepo { get; }
        Task<int> SaveChanges();
    }
}
