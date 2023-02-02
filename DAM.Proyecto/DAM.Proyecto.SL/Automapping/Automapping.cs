using AutoMapper;
using DAM.Proyecto.Domain.Entities.API;
using DAM.Proyecto.Domain.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.SL.Automapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            // mapeo en ambos sentidos, ignora si fantan propiedades
            CreateMap<EventoEuskadi, EventoEuskadiTable>().ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<TipoActividades, TipoActividadTable>().ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<Events, EventsTable>().ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap <GastronomiaEuskadi, GastronomiaEuskadiTable>().ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
